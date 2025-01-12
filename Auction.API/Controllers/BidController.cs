using Auction.Application.CQRS.Bid.Commands;
using Auction.Application.DTO.Bid;
using Auction.Application.Error;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers
{
    [ApiController]
    [Route("api/bid")]
    public class BidController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<PlaceBidCommand> _placeBidCommandValidator;

        public BidController(IMediator mediator, IValidator<PlaceBidCommand> placeBidCommandValidator)
        {
            _mediator = mediator;
            _placeBidCommandValidator = placeBidCommandValidator;
        }

        [HttpPost("vehicle/{vehicleId}/place")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Bid([FromRoute] int vehicleId, [FromBody] PlaceBidDto dto)
        {
            var command = new PlaceBidCommand(vehicleId, dto.Amount);

            await _placeBidCommandValidator.ValidateAndThrowAsync(command);

            var result = await _mediator.Send(command);

            return result ? Ok() : NotFound();
        }
    }
}
