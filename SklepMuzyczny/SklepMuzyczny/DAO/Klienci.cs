using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SklepMuzyczny.Data.Sql.DAO
{
    public class Klienci
    {
        public Klienci()
        {
            Zamowienias = new List<Zamowienia>();
        }
        [Key]
        public int IdKlienci { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
        public string Miejscowosc { get; set; }
        public string KodPocztowy { get; set; }
        public string Ulica { get; set; }
        public string NumerDomu { get; set; } 
        public string NumerMieszkania { get; set; }
        public virtual ICollection<Zamowienia> Zamowienias { get; set; }
    }
}
