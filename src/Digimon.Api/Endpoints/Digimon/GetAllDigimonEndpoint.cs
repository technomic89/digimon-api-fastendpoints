using Digimon.Api.Constracts.Requests;
using Digimon.Api.Constracts.Responses;
using Digimon.Api.Common.Mapping;
using Digimon.Application.Digimon.Queries.GetAllDigimon;
using Digimon.Application.Digimon.Queries.GetDigimonById;
using MediatR;

namespace Digimon.Api.Endpoints.Digimon;

public class GetAllDigimonEndpoint : EndpointWithoutRequest<IEnumerable<DigimonResponseDto>>
{
    private readonly ILogger<GetAllDigimonEndpoint> _logger;
    private readonly IMediator _mediator;
    
    public override void Configure()
    {
        Get("/digimon");
        AllowAnonymous();
        
        Description(b => b
            .Produces<ErrorResponse>(400, "application/json+problem")
            .ProducesProblem(403));
        
        Summary(s =>
        {
            s.Summary = "Get all Digimon";
            s.Description = "Get all Digimon without authentication";
            s.Response<IEnumerable<DigimonResponseDto>>(200, "success response");
            s.Response<ErrorResponse>(403, "error response");
        });
    }
    
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
    /// <param name="mediator"><see cref="IMediator"/></param>
    public GetAllDigimonEndpoint(ILogger<GetAllDigimonEndpoint> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    /// <summary>
    ///     Get a Digimon by id
    /// </summary>
    /// <param name="ct"><see cref="CancellationToken"/></param>
    /// /// <returns><see cref="IEnumerable{T}"/> <see cref="DigimonResponseDto"/></returns>
    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            _logger.LogDebug("Start GetAllDigimonEndpoint");
            var result = await _mediator.Send(
                new GetAllDigimonQuery(), 
                cancellationToken: ct
            );
            
            await SendOkAsync(
                result.FromListEntity(), 
                cancellation: ct
            );
            _logger.LogDebug("End GetAllDigimonEndpoint");
        }
        catch (Exception e)
        {
            _logger.LogError("Error at GetAllDigimonEndpoint. {E}", e);
            throw;
        }
    }
}