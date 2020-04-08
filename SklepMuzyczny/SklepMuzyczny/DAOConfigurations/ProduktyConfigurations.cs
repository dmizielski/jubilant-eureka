using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SklepMuzyczny.Data.Sql.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SklepMuzyczny.Data.Sql.DAOConfigurations
{
    public class ProduktyConfigurations : IEntityTypeConfiguration<Produkty>
    {
        public void Configure(EntityTypeBuilder<Produkty> builder)
        {
            builder.Property(c => c.IdZamowienia).IsRequired();
            builder.Property(c => c.IdKategorie).IsRequired();
            builder.Property(c => c.Nazwa).IsRequired();
            builder.Property(c => c.Opis).IsRequired();
            builder.Property(c => c.Opis).IsUnicode();
            builder.Property(c => c.Cena).IsRequired();
            builder.Property(c => c.Zdjecie).IsRequired();
            builder.Property(c => c.NrSeryjny).IsRequired();

            builder.HasOne(x => x.Zamowienia)
                .WithMany(x => x.Produktys)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.IdZamowienia);

            builder.HasOne(x => x.Kategorie)
                .WithMany(x => x.Produktys)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.IdKategorie);

            builder.ToTable("Produkty");
        }
    }
}
