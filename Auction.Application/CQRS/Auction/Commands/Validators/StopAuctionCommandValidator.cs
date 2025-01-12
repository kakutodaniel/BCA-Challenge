using Auction.Application.Error;
using FluentValidation;

namespace Auction.Application.CQRS.Auction.Commands.Validators
{
    public class StopAuctionCommandValidator : AbstractValidator<StopAuctionCommand>
    {
        public StopAuctionCommandValidator()
        {
            RuleFor(cmd => cmd.AuctionId)
               .GreaterThanOrEqualTo(1)
               .WithMessage(string.Format(ErrorMessage.GreaterThanOrEqualTo, "{PropertyName}", "{ComparisonValue}"));
        }
    }
}
