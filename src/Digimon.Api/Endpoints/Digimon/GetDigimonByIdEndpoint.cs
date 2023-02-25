using Digimon.Api.Constracts.Requests;
using Digimon.Api.Constracts.Responses;
using Digimon.Api.Common.Mapping;
using Digimon.Application.Digimon.Queries.GetDigimonById;
using MediatR;

namespace Digimon.Api.Endpoints.Digimon;

public class GetDigimonByIdEndpoint : Endpoint<GetSimpleDigimonByIdRequestDto, DigimonResponseDto>
{
    private readonly ILogger<GetDigimonByIdEndpoint> _logger;
    private readonly IMediator _mediator;
    
    public override void Configure()
    {
        Get("/digimon/{id}");
        AllowAnonymous();
        
        Description(b => b
            .Produces<ErrorResponse>(400, "application/json+problem")
            .ProducesProblem(403));
        
        Summary(s =>
        {
            s.Summary = "Get Digimon by Id";
            s.Description = "Get Digimon by Id without authentication";
            s.Response<DigimonResponseDto>(200, "success response");
            s.Response<ErrorResponse>(403, "error response");
            s.ExampleRequest = new GetSimpleDigimonByIdRequestDto() { Id = 1 };
        });
    }

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
    /// <param name="mediator"><see cref="IMediator"/></param>
    public GetDigimonByIdEndpoint(ILogger<GetDigimonByIdEndpoint> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    ///     Get a Digimon by id
    /// </summary>
    /// <param name="request"><see cref="GetSimpleDigimonByIdRequestDto"/></param>
    /// <param name="ct"><see cref="CancellationToken"/></param>
    /// <returns><see cref="DigimonResponseDto"/></returns>
    public override async Task HandleAsync(GetSimpleDigimonByIdRequestDto request, CancellationToken ct)
    {
        try
        {
            _logger.LogDebug("Start GetSimpleDigimonByIdEndpoint");
            var result = await _mediator.Send(
                new GetDigimonByIdQuery(request.Id), 
                cancellationToken: ct
            );

            await SendOkAsync(
                result.FromEntity(), 
                cancellation: ct
            );
            _logger.LogDebug("End GetSimpleDigimonByIdEndpoint");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error at GetSimpleDigimonByIdEndpoint");
            throw;
        }
    }
}