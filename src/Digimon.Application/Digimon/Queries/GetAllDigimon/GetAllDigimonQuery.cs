using Digimon.Application.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Digimon.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace Digimon.Application.Digimon.Queries.GetAllDigimon;

public record GetAllDigimonQuery : IRequest<IEnumerable<Domain.Entities.Digimon>>;

public class GetAllDigimonQueryHandler : IRequestHandler<GetAllDigimonQuery, IEnumerable<Domain.Entities.Digimon>>
{
    private readonly ILogger<GetAllDigimonQueryHandler> _logger;
    private readonly IDigimonDbContext _digimonDbContext;
    
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
    /// <param name="digimonDbContext"><see cref="IDigimonDbContext"/></param>
    public GetAllDigimonQueryHandler(ILogger<GetAllDigimonQueryHandler> logger, IDigimonDbContext digimonDbContext)
    {
        _logger = logger;
        _digimonDbContext = digimonDbContext;
    }
    
    /// <summary>
    ///     Get all Digimon
    /// </summary>
    /// <param name="query"><see cref="GetAllDigimonQuery"/></param>
    /// <param name="ct"><see cref="CancellationToken"/></param>
    /// <returns><see cref="IEnumerable{T}"/><see cref="Domain.Entities.Digimon"/></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<IEnumerable<Domain.Entities.Digimon>> Handle(GetAllDigimonQuery query, CancellationToken ct)
    {
        var digimon = await _digimonDbContext.Digimon
            .Include(p => p.DigimonPictures)
            .ToListAsync(ct);

        if (digimon.Count > 0) return digimon;
        
        _logger.LogError("Error at {@This}. {Query}", this, query);
        throw new NotFoundException($"Could't found entries");
    }
}