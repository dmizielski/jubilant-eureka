using Microsoft.EntityFrameworkCore;
using SklepMuzyczny.Data.Sql.DAO;
using SklepMuzyczny.Data.Sql.DAOConfigurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SklepMuzyczny.Data.Sql
{
   public class SklepMuzycznyDbContext : DbContext
    {
        public SklepMuzycznyDbContext(DbContextOptions<SklepMuzycznyDbContext> options) : base(options) { }

        public virtual DbSet<Kategorie> Kategorie { get; set; }
        public virtual DbSet<Klienci> Klienci { get; set; }
        public virtual DbSet<Produkty> Produkty { get; set; }
        public virtual DbSet<Zamowienia> Zamowienia { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new KategorieConfigurations());
            builder.ApplyConfiguration(new KlienciConfigurations());
            builder.ApplyConfiguration(new ProduktyConfigurations());
            builder.ApplyConfiguration(new ZamowieniaConfigurations());
        }
    }
}
