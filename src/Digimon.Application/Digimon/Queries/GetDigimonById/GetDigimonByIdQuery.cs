using Digimon.Application.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Digimon.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace Digimon.Application.Digimon.Queries.GetDigimonById;

public record GetDigimonByIdQuery(int Id) : IRequest<Domain.Entities.Digimon>;

public class GetDigimonByIdQueryHandler : IRequestHandler<GetDigimonByIdQuery, Domain.Entities.Digimon>
{
    private readonly ILogger<GetDigimonByIdQueryHandler> _logger;
    private readonly IDigimonDbContext _digimonDbContext;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
    /// <param name="digimonDbContext"><see cref="IDigimonDbContext"/></param>
    public GetDigimonByIdQueryHandler(
        ILogger<GetDigimonByIdQueryHandler> logger, IDigimonDbContext digimonDbContext)
    {
        _logger = logger;
        _digimonDbContext = digimonDbContext;
    }

    public async Task<Domain.Entities.Digimon> Handle(GetDigimonByIdQuery query, CancellationToken ct)
    {
        var digimon = await _digimonDbContext.Digimon
            .Include(p => p.DigimonPictures)
            .FirstOrDefaultAsync(d => d.Id == query.Id, ct);

        if (digimon is not null) return digimon;
        
        _logger.LogError("Error at {@This}. {Query}", this, query);
        throw new NotFoundException($"Could not found a Entry with the id = {query.Id}");
    }
}