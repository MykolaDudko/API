using API.Application.Carrier;
using API.Helpers;
using ClassLibrary.DTOs;
using ClassLibrary.Exceptions;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize(Policy = PolicyConstants.RequireViewRole)]

public class CarriersController : ControllerBase
{
    private readonly ISender _mediator;

    public CarriersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarrierResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCarriers(int id, CancellationToken ct)
    {
        var query = new GetCarrierQuery(id);
        var carrier = await _mediator.Send(query, cancellationToken: ct);
        return Ok(carrier);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<CarrierResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCarriers([FromQuery] GetCarriersFilter filter, CancellationToken ct)
    {
        var query = new GetCarriersByFilterQuery(filter);
        var carriers = await _mediator.Send(query, cancellationToken: ct);
        return Ok(carriers);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
    //[Authorize(Policy = PolicyConstants.RequireEditRole)]
    public async Task<IActionResult> AddCarrier(CreateCarrierRequest carrier, CancellationToken ct)
    {
        var command = new CreateCarrierCommand(carrier);
        var AddedCarrierId = await _mediator.Send(command, cancellationToken: ct);
        return CreatedAtAction(nameof(AddCarrier), AddedCarrierId);
    }

    [HttpDelete("{id}")]
    //[Authorize(Policy = PolicyConstants.RequireEditRole)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteCarrier(int id, CancellationToken ct)
    {
        var command = new DeleteCarrierCommand(id);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }

    [HttpPut("{id}")]
    //[Authorize(Policy = PolicyConstants.RequireEditRole)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCarrier(UpdateCarrierRequest carrier, int id, CancellationToken ct)
    {
        var command = new UpdateCarrierCommand(carrier, id);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }
}
