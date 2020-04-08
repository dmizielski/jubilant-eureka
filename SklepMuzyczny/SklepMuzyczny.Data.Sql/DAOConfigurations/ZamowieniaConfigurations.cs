using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SklepMuzyczny.Data.Sql.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SklepMuzyczny.Data.Sql.DAOConfigurations
{
    public class ZamowieniaConfigurations : IEntityTypeConfiguration<Zamowienia>
    {
        public void Configure(EntityTypeBuilder<Zamowienia> builder)
        {
            builder.Property(c => c.DataZlozeniaZamowienia).IsRequired();
            builder.Property(c => c.CzyPrzyjetoZamowienie).IsRequired().HasColumnType("tinyint(1)");
            builder.Property(c => c.ZaplataZGory).IsRequired().HasColumnType("tinyint(1)");
            builder.Property(c => c.ZaplataZaPobraniem).IsRequired().HasColumnType("tinyint(1)");
            builder.Property(c => c.FormaDostawy).IsRequired();
            builder.Property(c => c.CzyZrealizowano).IsRequired().HasColumnType("tinyint(1)");
            builder.Property(c => c.DataDostarczenia).IsRequired();

            builder.HasOne(x => x.Klienci)
               .WithMany(x => x.Zamowienias)
               .OnDelete(DeleteBehavior.Restrict)
               .HasForeignKey(x => x.IdKlienci);

            builder.ToTable("Zamowienia");
        }
    }
}
