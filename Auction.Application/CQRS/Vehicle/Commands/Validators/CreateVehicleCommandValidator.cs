using Auction.Application.Error;
using FluentValidation;

namespace Auction.Application.CQRS.Vehicle.Commands.Validators
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
        {
            RuleFor(cmd => cmd.Identifier)
                .NotNull()
                .WithMessage(string.Format(ErrorMessage.NotNull, "{PropertyName}"))
                .MinimumLength(2)
                .WithMessage(string.Format(ErrorMessage.MinimumLength, "{PropertyName}", "{MinLength}"))
                .MaximumLength(50)
                .WithMessage(string.Format(ErrorMessage.MaximumLength, "{PropertyName}", "{MaxLength}"));

            RuleFor(cmd => cmd.Manufacturer)
                .NotNull()
                .WithMessage(string.Format(ErrorMessage.NotNull, "{PropertyName}"))
                .MinimumLength(2)
                .WithMessage(string.Format(ErrorMessage.MinimumLength, "{PropertyName}", "{MinLength}"))
                .MaximumLength(50)
                .WithMessage(string.Format(ErrorMessage.MaximumLength, "{PropertyName}", "{MaxLength}"));

            RuleFor(cmd => cmd.Model)
                .NotNull()
                .WithMessage(string.Format(ErrorMessage.NotNull, "{PropertyName}"))
                .MinimumLength(2)
                .WithMessage(string.Format(ErrorMessage.MinimumLength, "{PropertyName}", "{MinLength}"))
                .MaximumLength(50)
                .WithMessage(string.Format(ErrorMessage.MaximumLength, "{PropertyName}", "{MaxLength}"));

            RuleFor(cmd => cmd.Year)
                .InclusiveBetween((short)1900, (short)DateTime.UtcNow.Year)
                .WithMessage(string.Format(ErrorMessage.InclusiveBetween, "{PropertyName}", "{From}", "{To}"));

            RuleFor(cmd => cmd.StartingBid)
                .GreaterThanOrEqualTo(1)
                .WithMessage(string.Format(ErrorMessage.GreaterThanOrEqualTo, "{PropertyName}", "{ComparisonValue}"));
        }
    }
}
