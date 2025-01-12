using Auction.Application.CQRS.Vehicle.Commands;
using Auction.Application.CQRS.Vehicle.Queries;
using Auction.Application.DTO.Vehicle;
using Auction.Application.Error;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers
{
    [ApiController]
    [Route("api/vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateHatchBackCommand> _createHatchBackCommandValidator;
        private readonly IValidator<CreateSedanCommand> _createSedanCommandValidator;
        private readonly IValidator<CreateSuvCommand> _createSuvCommandValidator;
        private readonly IValidator<CreateTruckCommand> _createTruckCommandValidator;

        public VehicleController(
            IMediator mediator, 
            IValidator<CreateHatchBackCommand> createHatchBackCommandValidator, 
            IValidator<CreateSedanCommand> createSedanCommandValidator, 
            IValidator<CreateSuvCommand> createSuvCommandValidator, 
            IValidator<CreateTruckCommand> createTruckCommandValidator)
        {
            _mediator = mediator;
            _createHatchBackCommandValidator = createHatchBackCommandValidator;
            _createSedanCommandValidator = createSedanCommandValidator;
            _createSuvCommandValidator = createSuvCommandValidator;
            _createTruckCommandValidator = createTruckCommandValidator;
        }

        [HttpPost("hatchback")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateHatchBack([FromBody] CreateHatchBackCommand command)
        {
            await _createHatchBackCommandValidator.ValidateAndThrowAsync(command);
            var id = await _mediator.Send(command);
            return Created($"api/vehicle/{id}", null);
        }

        [HttpPost("sedan")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSedan([FromBody] CreateSedanCommand command)
        {
            await _createSedanCommandValidator.ValidateAndThrowAsync(command);
            var id = await _mediator.Send(command);
            return Created($"api/vehicle/{id}", null);
        }

        [HttpPost("suv")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSuv([FromBody] CreateSuvCommand command)
        {
            await _createSuvCommandValidator.ValidateAndThrowAsync(command);
            var id = await _mediator.Send(command);
            return Created($"api/vehicle/{id}", null);
        }

        [HttpPost("truck")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTruck([FromBody] CreateTruckCommand command)
        {
            await _createTruckCommandValidator.ValidateAndThrowAsync(command);
            var id = await _mediator.Send(command);
            return Created($"api/vehicle/{id}", null);
        }

        [HttpGet("search")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<VehicleSearchResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Search([FromQuery] VehicleSearchQuery query)
        {
            var result = await _mediator.Send(query);
            return !result.Any() ? NotFound() : Ok(result); ;
        }
    }
}
