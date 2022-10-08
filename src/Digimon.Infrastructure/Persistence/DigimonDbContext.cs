using Digimon.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Digimon.Infrastructure.Persistence.Configuration;

namespace Digimon.Infrastructure.Persistence;

public class DigimonDbContext : DbContext, IDigimonDbContext
{
    public DigimonDbContext(DbContextOptions options)
        : base(options)
    {
    }
    
    public DbSet<Domain.Entities.Digimon> Digimon { get; init; } = default!;
    public DbSet<Domain.Entities.DigimonPictures> DigimonPictures { get; init; } = default!;

    public override Task<int> SaveChangesAsync(CancellationToken ct) => ct.IsCancellationRequested ? null : base.SaveChangesAsync();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DigimonConfiguration());
        modelBuilder.ApplyConfiguration(new DigimonPicturesConfiguration());
    }
}