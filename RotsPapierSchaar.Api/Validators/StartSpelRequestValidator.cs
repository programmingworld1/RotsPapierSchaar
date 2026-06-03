using FluentValidation;
using RotsPapierSchaar.Contracts.Requests;

namespace RotsPapierSchaar.Api.Validators;

public class StartSpelRequestValidator : AbstractValidator<StartSpelRequest>
{
    public StartSpelRequestValidator()
    {
        RuleFor(x => x.AantalRondes)
            .NotNull()
            .WithMessage("AantalRondes is verplicht.");
    }
}
