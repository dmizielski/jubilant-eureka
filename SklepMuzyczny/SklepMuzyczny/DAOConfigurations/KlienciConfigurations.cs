using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SklepMuzyczny.Data.Sql.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SklepMuzyczny.Data.Sql.DAOConfigurations
{
    public class KlienciConfigurations : IEntityTypeConfiguration<Klienci>
    {
        public void Configure(EntityTypeBuilder<Klienci> builder)
        {
            builder.Property(c => c.Imie).IsRequired();
            builder.Property(c => c.Imie).IsUnicode();
            builder.Property(c => c.Nazwisko).IsRequired();
            builder.Property(c => c.Nazwisko).IsUnicode();
            builder.Property(c => c.Telefon).IsRequired();
            builder.Property(c => c.Miejscowosc).IsRequired();
            builder.Property(c => c.Miejscowosc).IsUnicode();
            builder.Property(c => c.KodPocztowy).IsRequired();
            builder.Property(c => c.Ulica).IsRequired();
            builder.Property(c => c.NumerDomu).IsRequired();

            builder.ToTable("Klienci");
        }
    }
}
