using Auction.Application.Error;
using FluentValidation;

namespace Auction.Application.CQRS.Auction.Commands.Validators
{
    public class StartAuctionCommandValidator : AbstractValidator<StartAuctionCommand>
    {
        public StartAuctionCommandValidator()
        {
            RuleFor(cmd => cmd.VehicleIds)
                .NotNull()
                .WithMessage(string.Format(ErrorMessage.NotNull, "{PropertyName}"))
                .NotEmpty()
                .WithMessage(string.Format(ErrorMessage.NotEmpty, "{PropertyName}"));
        }
    }
}
