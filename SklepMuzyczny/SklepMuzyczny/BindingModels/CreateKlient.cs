using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SklepMuzyczny.BindingModels
{
    public class CreateKlient
    {
        [Required]
        [Display(Name = "Imie")]
        public string Imie { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [Required]
        [Display(Name = "Telefon")]
        public string Telefon { get; set; }

        [Required]
        [Display(Name = "Miejscowosc")]
        public string Miejscowosc { get; set; }

        [Required]
        [Display(Name = "KodPocztowy")]
        public string KodPocztowy { get; set; }

        [Required]
        [Display(Name = "Ulica")]
        public string Ulica { get; set; }

        [Required]
        [Display(Name = "NumerDomu")]
        public string NumerDomu { get; set; }

        [Required]
        [Display(Name = "NumerMieszkania")]
        public string NumerMieszkania { get; set; }
    }
}
