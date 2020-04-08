using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SklepMuzyczny.BindingModels;
using SklepMuzyczny.Data.Sql;
using SklepMuzyczny.Data.Sql.Migrations;
using SklepMuzyczny.Middlewares;
using static SklepMuzyczny.BindingModels.EditKlient;

namespace SklepMuzyczny
{
    public class Startup
    {
        //Reprezentuje zestaw właściwości konfiguracyjnych aplikacji klucz / wartość. (np z pliku appsettings.json)
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Póki co nieobowiązkowa treść, ale warto się zapoznać
        //metoda odpowiadająca za rejestrację serwisów w kontenerze IoC
        //zanim przejdą Państwo do kontenerów Dependency Injection (wstrzykwiania zależności)
        //warto zapoznać się z SOLIDem
        //SOLID - http://www.pzielinski.com/?s=ZASADY+S.O.L.I.D
        //oraz z Inversion of Control (link zawiera również wyjaśnienie Dependency Injection
        //https://www.c-sharpcorner.com/UploadFile/cda5ba/dependency-injection-di-and-inversion-of-control-ioc/
        public void ConfigureServices(IServiceCollection services)
        {
            //rejestracja DbContextu, użycie providera MySQL i pobranie danych o bazie z appsettings.json
            services.AddDbContext<SklepMuzycznyDbContext>(options => options
                .UseMySQL(Configuration.GetConnectionString("SklepMuzycznyDbContext")));
            services.AddTransient<DatabaseSeed>();
            services.AddScoped<IValidator<EditKlient>, EditKlientValidator>();
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation();
            services.AddApiVersioning(o => o.ReportApiVersions = true);
        }

        // Metoda w której konfiguruje się pipeline (potok) żądań HTTP.
        //Ja użyłem tej metody do upewnienia się, że baza którą chce utworzyć nie istnieje,
        //a następnie do utworzenia bazy danych i utworzenia testowych danych
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<SklepMuzycznyDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                databaseSeed.Seed();
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMvc();
        }
    }
}
