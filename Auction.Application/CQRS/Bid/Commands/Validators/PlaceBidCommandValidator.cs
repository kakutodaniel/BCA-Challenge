using Auction.Application.Error;
using FluentValidation;

namespace Auction.Application.CQRS.Bid.Commands.Validators
{
    public class PlaceBidCommandValidator : AbstractValidator<PlaceBidCommand>
    {
        public PlaceBidCommandValidator()
        {
            RuleFor(cmd => cmd.VehicleId)
               .GreaterThanOrEqualTo(1)
               .WithMessage(string.Format(ErrorMessage.GreaterThanOrEqualTo, "{PropertyName}", "{ComparisonValue}"));

            RuleFor(cmd => cmd.Amount)
               .GreaterThanOrEqualTo(1)
               .WithMessage(string.Format(ErrorMessage.GreaterThanOrEqualTo, "{PropertyName}", "{ComparisonValue}"));
        }
    }
}
