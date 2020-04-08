using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SklepMuzyczny.BindingModels
{
    public class EditKlient
    {
        [Display]
        public string Imie { get; set; }

        [Display]
        public string Nazwisko { get; set; }

        [Display]
        public string Telefon { get; set; }

        [Display]
        public string Miejscowosc { get; set; }

        [Display]
        public string KodPocztowy { get; set; }

        [Display]
        public string Ulica { get; set; }

        [Display]
        public string NumerDomu { get; set; }

        [Display]
        public string NumerMieszkania { get; set; }

        public class EditKlientValidator : AbstractValidator<EditKlient>
        {
            public EditKlientValidator()
            {
                RuleFor(x => x.Imie).NotNull();
                RuleFor(x => x.Nazwisko).NotNull();
                RuleFor(x => x.Telefon).NotNull();
                RuleFor(x => x.Miejscowosc).NotNull();
                RuleFor(x => x.KodPocztowy).NotNull();
                RuleFor(x => x.Ulica).NotNull();
                RuleFor(x => x.NumerDomu).NotNull();
                RuleFor(x => x.NumerMieszkania).NotNull();
            }
        }
    }
}
