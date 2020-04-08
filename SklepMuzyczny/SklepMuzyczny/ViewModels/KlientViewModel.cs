using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SklepMuzyczny.ViewModels
{
    public class KlientViewModel
    {
        public int IdKlienta { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
        public string Miejscowosc { get; set; }
        public string KodPocztowy { get; set; }
        public string Ulica { get; set; }
        public string NumerDomu { get; set; }
        public string NumerMieszkania { get; set; }
    }
}
