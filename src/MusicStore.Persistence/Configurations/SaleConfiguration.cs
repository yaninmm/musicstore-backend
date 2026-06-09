using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Persistence.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(x => x.OperationNumber)
                .IsUnicode(false)
                .HasMaxLength(20);

            builder.Property(x => x.SaleDate)
                .HasColumnType("date")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.Total)
                .HasColumnType("decimal(10,2)");

            builder.ToTable(nameof(Sale), schema: "Musicales");
        }
    }
}
