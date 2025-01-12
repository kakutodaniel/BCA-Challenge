using Auction.Application.Error;
using FluentValidation;

namespace Auction.Application.CQRS.Vehicle.Commands.Validators
{
    public class CreateSuvCommandValidator : AbstractValidator<CreateSuvCommand>
    {
        public CreateSuvCommandValidator()
        {
            Include(new CreateVehicleCommandValidator());

            RuleFor(cmd => cmd.NumberOfSeats)
                .InclusiveBetween((short)4, (short)20)
                .WithMessage(string.Format(ErrorMessage.InclusiveBetween, "{PropertyName}", "{From}", "{To}"));
        }
    }
}
