using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digimon.Infrastructure.Persistence.Configuration;

public class DigimonConfiguration : IEntityTypeConfiguration<Domain.Entities.Digimon>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Digimon> builder)
    {
        builder.ToTable("tbl_digimon");
        
        builder.Property(e => e.Id)
            .HasColumnName("id");
        
        builder.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(255);

        builder.Property(e => e.LevelId)
            .HasColumnName("level_id");
        
        builder.Property(e => e.Size)
            .HasColumnName("size")
            .HasMaxLength(50);
    }
}