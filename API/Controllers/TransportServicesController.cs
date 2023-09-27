using API.Application.TransportService;
using API.Helpers;
using ClassLibrary.DTOs;
using ClassLibrary.Exceptions;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize(Policy = PolicyConstants.RequireViewRole)]
public class TransportServicesController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMemoryCache _memoryCache;

    public TransportServicesController(ISender mediator, IMemoryCache memoryCache)
    {
        _mediator = mediator;
        _memoryCache = memoryCache;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<TransportServiceResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTransportService([FromQuery] TransportServiceFilter filter, CancellationToken ct)
    {
        var query = new GetTransportServiceQuery(filter);
        var transportService = await _mediator.Send(query, cancellationToken: ct);
        return Ok(transportService);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransportServiceResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetTransportServiceById(int id, CancellationToken ct)
    {
        var query = new GetTransportServiceByIdQuery(id);
        var transportService = await _mediator.Send(query, cancellationToken: ct);
        return Ok(transportService);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
    //[Authorize(Policy = PolicyConstants.RequireEditRole)]
    public async Task<IActionResult> AddTransportService(CreateTransportServiceRequest transportService, CancellationToken ct)
    {
        var command = new CreateTransportServiceCommand(transportService);
        var AddedTransportServiceId = await _mediator.Send(command, cancellationToken: ct);
        return CreatedAtAction(nameof(AddTransportService), AddedTransportServiceId);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[Authorize(Policy = PolicyConstants.RequireEditRole)]
    public async Task<IActionResult> DeleteTransportService(int id, CancellationToken ct)
    {
        var command = new DeleteTransportServiceCommand(id);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[Authorize(Policy = PolicyConstants.RequireEditRole)]
    public async Task<IActionResult> UpdateTransportService(UpdateTransportServiceRequest transportService, int id, CancellationToken ct)
    {
        var command = new UpdateTransportServiceCommand(transportService, id);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }
}
