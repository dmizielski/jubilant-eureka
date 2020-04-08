using SklepMuzyczny.Data.Sql.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SklepMuzyczny.Data.Sql.Migrations
{
    public class DatabaseSeed
    {
        private readonly SklepMuzycznyDbContext _context;

        public DatabaseSeed(SklepMuzycznyDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            #region UtworzKlienci
            var klienciList = BuildKlienciList();
            _context.Klienci.AddRange(klienciList);
            _context.SaveChanges();
            #endregion

            #region UtworzKategorie
            var kategorieList = BuildKategorieList();
            _context.Kategorie.AddRange(kategorieList);
            _context.SaveChanges();
            #endregion

            #region UtworzZamowienia
            var zamowieniaList = BuildZamowieniaList(klienciList);
            _context.Zamowienia.AddRange(zamowieniaList);
            _context.SaveChanges();
            #endregion

            #region UtworzProdukty
            var produktyList = BuildProduktyList(kategorieList, zamowieniaList);
            _context.Produkty.AddRange(produktyList);
            _context.SaveChanges();
            #endregion

        }

        private IEnumerable<Klienci> BuildKlienciList()
        {
            Random x = new Random(DateTime.Now.Millisecond);
            var klienciList = new List<Klienci>();
            {
                var uzytkownik = new Klienci()
                {
                    Imie = "Janusz",
                    Nazwisko = "Kowalski",
                    Telefon = x.Next(10000, 99999).ToString() + x.Next(1000, 9999),
                    Miejscowosc = "Warszawa",
                    KodPocztowy = x.Next(1, 99).ToString() + "-" + x.Next(100, 999).ToString(),
                    Ulica = "Nowy świat",
                    NumerDomu = x.Next(1, 100).ToString(),
                    NumerMieszkania = x.Next(1, 20).ToString(),
                };
                klienciList.Add(uzytkownik);

                var uzytkownik1 = new Klienci()
                {
                    Imie = "Marek",
                    Nazwisko = "Markowski",
                    Telefon = x.Next(10000, 99999).ToString() + x.Next(1000, 9999),
                    Miejscowosc = "Opole",
                    KodPocztowy = x.Next(1, 99).ToString() + "-" + x.Next(100, 999).ToString(),
                    Ulica = "Opolska",
                    NumerDomu = x.Next(1, 100).ToString(),
                    NumerMieszkania = x.Next(1, 20).ToString(),
                };
                klienciList.Add(uzytkownik1);
            }
            return klienciList;
        }

        private IEnumerable<Kategorie> BuildKategorieList()
        {
            var kategorieList = new List<Kategorie>()
            {
                new Kategorie
                {
                    NazwaKategorii="Słuchawki"
                },

                new Kategorie
                {
                    NazwaKategorii="Głośniki"
                }
            };

            return kategorieList;
        }

        private IEnumerable<Zamowienia> BuildZamowieniaList(IEnumerable<Klienci> klienciList)
        {
            Random x = new Random(DateTime.Now.Millisecond);
            string[] przesylka = { "Poczta", "Kurier", "Paczkomat" };
            var zamowieniaList = new List<Zamowienia>();
            var zamowienia = new Zamowienia()
            {
                IdKlienci = 1,
                DataZlozeniaZamowienia = LosowaData(),
                CzyPrzyjetoZamowienie = true,
                ZaplataZGory = true,
                ZaplataZaPobraniem = false,
                FormaDostawy = przesylka[x.Next(0, przesylka.Length)],
                CzyZrealizowano = true,
                DataDostarczenia = LosowaData(),
            };
            zamowieniaList.Add(zamowienia);

            var zamowienia1 = new Zamowienia()
            {
                IdKlienci = 2,
                DataZlozeniaZamowienia = LosowaData(),
                CzyPrzyjetoZamowienie = true,
                ZaplataZGory = false,
                ZaplataZaPobraniem = true,
                FormaDostawy = przesylka[x.Next(0, przesylka.Length)],
                CzyZrealizowano = true,
                DataDostarczenia = LosowaData(),
            };
            zamowieniaList.Add(zamowienia1);

            return zamowieniaList;
        }

   

        private IEnumerable<Produkty> BuildProduktyList(IEnumerable<Kategorie> kategorieList,
            IEnumerable<Zamowienia> zamowieniaList)
        {
            Random x = new Random(DateTime.Now.Millisecond);

            var Produkty = new List<Produkty>();

            var pozycja = new Produkty()
            {
                IdZamowienia = 1,
                IdKategorie = 1,
                Nazwa = "HiFiMAN HE-400i",
                Opis = "Słuchawki przewodowe, audiofilskie, planarne, ortodynamiczne.",
                NrSeryjny = x.Next(10000, 99999).ToString(),
                Zdjecie = "https://image.ceneostatic.pl/data/products/31240831/i-hifiman-he-400i.jpg",
            };
            Produkty.Add(pozycja);

            var pozycja2 = new Produkty()
            {
                IdZamowienia = 2,
                IdKategorie = 2,
                Nazwa = "BOWERS & WILKINS 685 S2",
                Opis = "Wszechstronny nowy model 685 w domowym zaciszu ma swoje miejsce na podstawce lub na półce.",
                NrSeryjny = x.Next(10000, 99999).ToString(),
                Zdjecie = "https://cdn.mos.cms.futurecdn.net/FNj8BFYjdNfbSiQa4LqeXK-480-80.jpg",
            };
            Produkty.Add(pozycja2);

            return Produkty;
        }

        private DateTime LosowaData()
        {
            int rok, miesiac, dzien;
            Random x = new Random(DateTime.Now.Millisecond);
            rok = x.Next(2000, DateTime.Now.Year + 1);
            if (rok != DateTime.Now.Year)
            {
                miesiac = x.Next(1, 13);
            }
            else
            {
                miesiac = x.Next(1, DateTime.Now.Month + 1);
            }

            dzien = x.Next(1, DateTime.DaysInMonth(rok, miesiac));

            var data = new DateTime(rok, miesiac, dzien, x.Next(0, 24), x.Next(0, 60), x.Next(0, 60));
            return data;
        }
    }
}
