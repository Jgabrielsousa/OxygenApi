using FluentValidation;
using Oxygen.Application.UseCases.Client.V1.Create;

namespace Oxygen.Application.Validations.UseCases.V1.Create
{
    public class CreateCommandValidation : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidation()
        {
            RuleFor(c => c).NotNull().WithMessage("Invalid request");
            RuleFor(r => r.Nome).NotEmpty().WithMessage("Nome can not be Empty");
            RuleFor(r => r.Idade).GreaterThan(0).WithMessage("Idade Needs to be greater than 0");
        }
    }
}
