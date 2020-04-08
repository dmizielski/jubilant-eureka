using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SklepMuzyczny.BindingModels;
using SklepMuzyczny.Data.Sql;
using SklepMuzyczny.Data.Sql.DAO;
using SklepMuzyczny.Validation;
using SklepMuzyczny.ViewModels;
using System.Threading.Tasks;

namespace SklepMuzyczny.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/klient")]
    public class KlienciController : Controller
    {
        private readonly SklepMuzycznyDbContext _context;

        public KlienciController(SklepMuzycznyDbContext context)
        {
            _context = context;
        }

        [Route("{idKlienta:min(1)}", Name = "GetKlientById")]
        [HttpGet]
        public async Task<IActionResult> GetKlientById(int idKlienta)
        {
            var klient = await _context.Klienci.FirstOrDefaultAsync(x => x.IdKlienci == idKlienta);

            if (klient != null)
            {
                return Ok(new KlientViewModel
                {
                    IdKlienta = klient.IdKlienci,
                    Imie = klient.Imie,
                    Nazwisko = klient.Nazwisko,
                    Telefon = klient.Telefon,
                    Miejscowosc = klient.Miejscowosc,
                    KodPocztowy = klient.KodPocztowy,
                    Ulica = klient.Ulica,
                    NumerDomu = klient.NumerDomu,
                    NumerMieszkania = klient.NumerMieszkania
                });
            }
            return NotFound();
        }

        [Route("name/{nazwisko}", Name = "GetKlientByNazwisko")]
        [HttpGet]
        public async Task<IActionResult> GetKlientByNazwisko(string nazwisko)
        {
            var klient = await _context.Klienci.FirstOrDefaultAsync(x => x.Nazwisko == nazwisko);

            if (klient != null)
            {
                return Ok(new KlientViewModel
                {
                    IdKlienta = klient.IdKlienci,
                    Imie = klient.Imie,
                    Nazwisko = klient.Nazwisko,
                    Telefon = klient.Telefon,
                    Miejscowosc = klient.Miejscowosc,
                    KodPocztowy = klient.KodPocztowy,
                    Ulica = klient.Ulica,
                    NumerDomu = klient.NumerDomu,
                    NumerMieszkania = klient.NumerMieszkania
                });
            }
            return NotFound();
        }

        //        [Route("create", Name = "CreateUser")]
        [ValidateModel]
        //        [Consumes("application/x-www-form-urlencoded")]
        //        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateKlient createKlienci)
        {
            var klient = new Klienci
            {
                Imie = createKlienci.Imie,
                Nazwisko = createKlienci.Nazwisko,
                Telefon = createKlienci.Telefon,
                Miejscowosc = createKlienci.Miejscowosc,
                KodPocztowy = createKlienci.KodPocztowy,
                Ulica = createKlienci.Ulica,
                NumerDomu = createKlienci.NumerDomu,
                NumerMieszkania = createKlienci.NumerMieszkania
            };
            await _context.AddAsync(klient);
            await _context.SaveChangesAsync();

            return Created(klient.IdKlienci.ToString(), new KlientViewModel
            {
                IdKlienta = klient.IdKlienci,
                Imie = klient.Imie,
                Nazwisko = klient.Nazwisko,
                Telefon = klient.Telefon,
                Miejscowosc = klient.Miejscowosc,
                KodPocztowy = klient.KodPocztowy,
                Ulica = klient.Ulica,
                NumerDomu = klient.NumerDomu,
                NumerMieszkania = klient.NumerMieszkania
            });
        }

        [Route("edit/{idKlienta:min(1)}", Name = "EditKlienci")]
        [ValidateModel]
        [HttpPatch]
        //        public async Task<IActionResult> EditUser([FromBody] EditUser editUser,[FromQuery] int userId)
        public async Task<IActionResult> EditKlienci([FromBody] EditKlient editKlienci, int idKlienta)
        {
            var klient = await _context.Klienci.FirstOrDefaultAsync(x => x.IdKlienci == idKlienta);
            klient.Imie = editKlienci.Imie;
            klient.Nazwisko = editKlienci.Nazwisko;
            klient.Telefon = editKlienci.Telefon;
            klient.Miejscowosc = editKlienci.Miejscowosc;
            klient.KodPocztowy = editKlienci.KodPocztowy;
            klient.Ulica = editKlienci.Ulica;
            klient.NumerDomu = editKlienci.NumerDomu;
            klient.NumerMieszkania = editKlienci.NumerMieszkania;
            await _context.SaveChangesAsync();
            return Ok(new KlientViewModel
            {
                IdKlienta = klient.IdKlienci,
                Imie = klient.Imie,
                Nazwisko = klient.Nazwisko,
                Telefon = klient.Telefon,
                Miejscowosc = klient.Miejscowosc,
                KodPocztowy = klient.KodPocztowy,
                Ulica = klient.Ulica,
                NumerDomu = klient.NumerDomu,
                NumerMieszkania = klient.NumerMieszkania
            });
            return NoContent();
            
        }

        [Route("delete/{idKlienta:min(1)}", Name = "DeleteKlienci")]
        [ValidateModel]
        [HttpDelete]
        public async Task<IActionResult> DeleteKlienci(int idKlienta)
        {
            var klient = await _context.Klienci.FirstOrDefaultAsync(x => x.IdKlienci == idKlienta);
            _context.Klienci.Remove(klient);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
