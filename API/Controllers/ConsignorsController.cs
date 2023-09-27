using API.Application.Consignor;
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
public class ConsignorsController : ControllerBase
{
    private readonly ISender _mediator;

    public ConsignorsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<ConsignorResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> GetConsignorAsync([FromQuery] GetByIdFilter filter, CancellationToken ct)
    {
        var query = new GetConsignorQuery(filter);
        var consignor = await _mediator.Send(query, cancellationToken: ct);
        return Ok(consignor);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
    //[Authorize(Policy = PolicyConstants.RequireEditRole)]
    public async Task<IActionResult> AddConsignor(CreateConsignorRequest consignor, CancellationToken ct)
    {
        var command = new CreateConsignorCommand(consignor);
        var AddedConsignorId = await _mediator.Send(command, cancellationToken: ct);
        return CreatedAtAction(nameof(AddConsignor), AddedConsignorId);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[Authorize(Policy = PolicyConstants.RequireEditRole)]
    public async Task<IActionResult> DeleteConsignor(int id, CancellationToken ct)
    {
        var command = new DeleteConsignorCommand(id);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[Authorize(Policy = PolicyConstants.RequireEditRole)]
    public async Task<IActionResult> UpdateConsignor(UpdateConsignorRequest consignor, int id, CancellationToken ct)
    {
        var command = new UpdateConsignorCommand(consignor, id);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }
}
