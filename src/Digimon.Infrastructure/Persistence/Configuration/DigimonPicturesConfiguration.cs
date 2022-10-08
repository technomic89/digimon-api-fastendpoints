using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digimon.Infrastructure.Persistence.Configuration;

public class DigimonPicturesConfiguration : IEntityTypeConfiguration<Domain.Entities.DigimonPictures>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.DigimonPictures> builder)
    {
        builder.ToTable("tblkett_digimon_pictures");
        
        builder.Property(e => e.Id)
            .HasColumnName("id");
        
        builder.Property(e => e.DigimonId)
            .HasColumnName("tbl_digimon_id");
        
        builder.Property(e => e.Picture)
            .HasColumnName("picture");

        builder.HasOne(d => d.Digimon)
            .WithMany(p => p.DigimonPictures)
            .HasForeignKey(d => d.DigimonId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}