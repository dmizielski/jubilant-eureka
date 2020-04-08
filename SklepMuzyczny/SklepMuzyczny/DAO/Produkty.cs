using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SklepMuzyczny.Data.Sql.DAO
{
    public class Produkty
    {
        [Key]
        public int IdProduktu { get; set; }
        public int IdZamowienia { get; set; }
        public int IdKategorie { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }
        public string NrSeryjny { get; set; }
        public string Zdjecie { get; set; }
        public virtual Zamowienia Zamowienia { get; set; }
        public virtual Kategorie Kategorie { get; set; }
    }
}
