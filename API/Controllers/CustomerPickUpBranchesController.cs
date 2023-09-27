using API.Application.CustomerPickUpBranch;
using API.Helpers;
using ClassLibrary.DTOs;
using ClassLibrary.Exceptions;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Policy = PolicyConstants.RequireViewRole)]
public class CustomerPickUpBranchesController : ControllerBase
{
    private readonly ISender _mediator;

    public CustomerPickUpBranchesController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<CustomerPickUpBranchResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> GetCustomerPickUpBranch([FromQuery] GetCustomerPickUpBranchFilter filter, CancellationToken ct)
    {
        var query = new GetCustomerPickUpBranchQuery(filter);
        var customerPickUpBranch = await _mediator.Send(query, cancellationToken: ct);
        return Ok(customerPickUpBranch);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<CustomerPickUpBranchResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> GetCustomerPickUpBranchesById(string id, [FromQuery] BaseFilter filter, CancellationToken ct)
    {
        var query = new GetCustomerPickUpBranchesFromDbQuery(id, filter);
        var customerPickUpBranch = await _mediator.Send(query, cancellationToken: ct);
        return Ok(customerPickUpBranch);
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = PolicyConstants.RequireEditRole)]
    public async Task<IActionResult> TurnOffCustomerPickUpBranch(int id, [Required][FromBody] bool IsEnabled, CancellationToken ct)
    {
        var command = new UpdateCustomerPickUpBranchIsEnabledCommand(id, IsEnabled);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }
}
