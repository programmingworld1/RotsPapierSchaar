using FluentValidation;
using RotsPapierSchaar.Contracts.Requests;

namespace RotsPapierSchaar.Api.Validators;

public class SpeelRondeRequestValidator : AbstractValidator<SpeelRondeRequest>
{
    public SpeelRondeRequestValidator()
    {
        RuleFor(x => x.SpelerZet)
            .NotEmpty()
            .WithMessage("SpelerZet is verplicht.");
    }
}
