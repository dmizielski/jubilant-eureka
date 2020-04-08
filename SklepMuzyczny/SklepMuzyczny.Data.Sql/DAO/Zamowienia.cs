using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SklepMuzyczny.Data.Sql.DAO
{
    public class Zamowienia
    {
        public Zamowienia()
        {
            Produktys = new List<Produkty>();
            Kliencis = new List<Klienci>();
        }
        [Key]
        public int IdZamowienia { get; set; }
        public int IdKlienci { get; set; }
        public DateTime DataZlozeniaZamowienia { get; set; }
        public bool CzyPrzyjetoZamowienie { get; set; }
        public bool ZaplataZGory { get; set; }
        public bool ZaplataZaPobraniem { get; set; }
        public string FormaDostawy { get; set; }
        public bool CzyZrealizowano { get; set; }
        public DateTime DataDostarczenia { get; set; }
        public virtual Klienci Klienci { get; set; }
        public virtual ICollection<Klienci> Kliencis { get; set; }
        public virtual ICollection<Produkty> Produktys { get; set; }
    }
}
