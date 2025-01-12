using Auction.Application.Error;
using FluentValidation;

namespace Auction.Application.CQRS.Vehicle.Commands.Validators
{
    public class CreateTruckCommandValidator : AbstractValidator<CreateTruckCommand>
    {
        public CreateTruckCommandValidator()
        {
            Include(new CreateVehicleCommandValidator());

            RuleFor(cmd => cmd.LoadCapacity)
                .InclusiveBetween((short)1, (short)10000)
                .WithMessage(string.Format(ErrorMessage.InclusiveBetween, "{PropertyName}", "{From}", "{To}"));
        }
    }
}
