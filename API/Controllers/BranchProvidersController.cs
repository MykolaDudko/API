using API.Application.CarrierBranchCategory;
using API.Helpers;
using ClassLibrary.DTOs;
using ClassLibrary.Exceptions;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using ClassLibrary.Providers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize(Policy = PolicyConstants.RequireViewRole)]
public class BranchProvidersController : ControllerBase
{
    private readonly ISender _mediator;

    public BranchProvidersController(ISender mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<ICarrierBranchProvider>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> GetAllProviders(CancellationToken ct)
    {
        var query = new GetAllProvidersQuery();
        var carrierBranchCategory = await _mediator.Send(query, cancellationToken: ct);
        return Ok(carrierBranchCategory);
    }

    [HttpGet("{providerId}/fetch")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<CustomerPickUpBranchResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> LoadDataFromProvider(string providerId, [FromQuery] LoadCustomerPickupBranchFromProviderFilter filter, CancellationToken ct)
    {
        var query = new LoadDataFromProviderQuery(providerId, filter);
        var branches = await _mediator.Send(query, cancellationToken: ct);
        return Ok(branches);
    }

    [HttpPatch("{categoryId}")]
    //[Authorize(Policy = PolicyConstants.RequireEditRole)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> FetchByCategoryId(int categoryId, CancellationToken ct)
    {
        var command = new FetchCustomerPickupBranchesByCategoryIdCommand(categoryId);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }
}
