using API.Application.HandoverPoint;
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
[Authorize(Policy = PolicyConstants.RequireViewRole)]
public class HandoverPointsController : ControllerBase
{
    private readonly ISender _mediator;

    public HandoverPointsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<HandoverPointResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> GetHandoverPoint([FromQuery] GetByIdFilter filter, CancellationToken ct)
    {
        var query = new GetHandoverPointQuery(filter);
        var handoverPoint = await _mediator.Send(query, cancellationToken: ct);
        return Ok(handoverPoint);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
    [Authorize(Policy = PolicyConstants.RequireEditRole)]
    public async Task<IActionResult> AddHandoverPoint(CreateHandoverPointRequest handoverPoint, CancellationToken ct)
    {
        var command = new CreateHandoverPointCommand(handoverPoint);
        var AddedHandoverPointId = await _mediator.Send(command, cancellationToken: ct);
        return CreatedAtAction(nameof(AddHandoverPoint), AddedHandoverPointId);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = PolicyConstants.RequireEditRole)]
    public async Task<IActionResult> DeleteHandoverPoint(int id, CancellationToken ct)
    {
        var command = new DeleteHandoverPointCommand(id);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = PolicyConstants.RequireEditRole)]
    public async Task<IActionResult> UpdateHandoverPoint(UpdateHandoverPointRequest handoverPoint, int id, CancellationToken ct)
    {
        var command = new UpdateHandoverPointCommand(handoverPoint, id);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }
}
