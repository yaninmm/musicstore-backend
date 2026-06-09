using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Entities;


namespace MusicStore.Persistence.Configurations
{
    public class ConcertConfiguration : IEntityTypeConfiguration<Concert>
    {
        public void Configure(EntityTypeBuilder<Concert> builder)
        {
            builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Place).HasMaxLength(100);
            builder.Property(c => c.DateEvent)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");
            builder.Property(c=> c.Imageurl).HasMaxLength(100).IsUnicode(false);
            builder.HasIndex(c => c.Title);
            builder.ToTable("Concert", "Musicales");

        }
    }
}
