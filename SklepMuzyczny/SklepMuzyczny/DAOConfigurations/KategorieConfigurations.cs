using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SklepMuzyczny.Data.Sql.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SklepMuzyczny.Data.Sql.DAOConfigurations
{
    public class KategorieConfigurations : IEntityTypeConfiguration<Kategorie>
    {
        public void Configure(EntityTypeBuilder<Kategorie> builder)
        {
            builder.Property(c => c.IdKategorie).IsRequired();
            builder.Property(c => c.NazwaKategorii).IsRequired();
            builder.Property(c => c.NazwaKategorii).IsUnicode();

            builder.ToTable("Kategorie");
        }
    }
}
