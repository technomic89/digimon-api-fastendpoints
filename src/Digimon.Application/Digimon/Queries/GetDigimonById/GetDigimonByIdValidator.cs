using FluentValidation;

namespace Digimon.Application.Digimon.Queries.GetDigimonById;

public class GetDigimonByIdValidator : AbstractValidator<GetDigimonByIdQuery>
{
    public GetDigimonByIdValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}