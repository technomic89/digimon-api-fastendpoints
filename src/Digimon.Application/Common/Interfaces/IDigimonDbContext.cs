using Microsoft.EntityFrameworkCore;

namespace Digimon.Application.Common.Interfaces;

public interface IDigimonDbContext
{
    DbSet<Domain.Entities.Digimon> Digimon { get; }

    Task<int>? SaveChangesAsync(CancellationToken cancellationToken);
}