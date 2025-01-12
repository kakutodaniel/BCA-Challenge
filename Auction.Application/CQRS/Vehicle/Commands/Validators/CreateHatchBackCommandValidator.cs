using Auction.Application.Error;
using FluentValidation;

namespace Auction.Application.CQRS.Vehicle.Commands.Validators
{
    public class CreateHatchBackCommandValidator : AbstractValidator<CreateHatchBackCommand>
    {
        public CreateHatchBackCommandValidator()
        {
            Include(new CreateVehicleCommandValidator());

            RuleFor(cmd => cmd.NumberOfDoors)
                .InclusiveBetween((short)2, (short)10)
                .WithMessage(string.Format(ErrorMessage.InclusiveBetween, "{PropertyName}", "{From}", "{To}"));
        }
    }
}
