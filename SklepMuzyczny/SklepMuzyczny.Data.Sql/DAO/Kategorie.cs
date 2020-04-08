using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SklepMuzyczny.Data.Sql.DAO
{
    public class Kategorie
    {
        public Kategorie()
        {
            Produktys = new List<Produkty>();
        }
        [Key]
        public int IdKategorie { get; set; }
        public string NazwaKategorii { get; set; }
        public virtual ICollection<Produkty> Produktys { get; set; }
    }
}
