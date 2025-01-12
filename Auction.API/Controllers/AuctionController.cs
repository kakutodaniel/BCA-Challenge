using Auction.Application.CQRS.Auction.Commands;
using Auction.Application.CQRS.Auction.Queries;
using Auction.Application.DTO.Auction;
using Auction.Application.Error;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers
{
    [ApiController]
    [Route("api/auction")]
    public class AuctionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<StartAuctionCommand> _startAuctionCommandValidator;
        private readonly IValidator<StopAuctionCommand> _stopAuctionCommandValidator;

        public AuctionController(
            IMediator mediator,
            IValidator<StartAuctionCommand> startAuctionCommandValidator,
            IValidator<StopAuctionCommand> stopAuctionCommandValidator)
        {
            _mediator = mediator;
            _startAuctionCommandValidator = startAuctionCommandValidator;
            _stopAuctionCommandValidator = stopAuctionCommandValidator;
        }

        [HttpPost("start")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Start([FromBody] StartAuctionCommand command)
        {
            await _startAuctionCommandValidator.ValidateAndThrowAsync(command);
            var id = await _mediator.Send(command);
            return Created($"api/auction/{id}", null);
        }

        [HttpPost("{id}/stop")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Stop([FromRoute] int id)
        {
            var command = new StopAuctionCommand(id);
            await _stopAuctionCommandValidator.ValidateAndThrowAsync(command);
            var result = await _mediator.Send(command);

            return result ? Ok() : NotFound();
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<AuctionResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var query = new AuctionQuery();
            var result = await _mediator.Send(query);

            return !result.Any() ? NotFound() : Ok(result);
        }
    }
}
