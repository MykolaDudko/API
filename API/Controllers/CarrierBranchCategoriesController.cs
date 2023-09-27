using API.Application.CarrierBranchCategory;
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
public class CarrierBranchCategoriesController : ControllerBase
{
    private readonly ISender _mediator;

    public CarrierBranchCategoriesController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<CarrierBranchCategoryResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> GetCarrierBranchCategory([FromQuery] GetCarrierBranchCategoryFilter filter, CancellationToken ct)
    {
        var query = new GetCarrierBranchCategoryQuery(filter);
        var carrierBranchCategory = await _mediator.Send(query, cancellationToken: ct);
        return Ok(carrierBranchCategory);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarrierBranchCategoryResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    public async Task<IActionResult> GetCarrierBranchCategory(int id, CancellationToken ct)
    {
        var query = new GetCarrierBranchCategoryByIdQuery(id);
        var carrierBranchCategory = await _mediator.Send(query, cancellationToken: ct);
        return Ok(carrierBranchCategory);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
    //[Authorize(Policy = PolicyConstants.RequireEditRole)]
    public async Task<IActionResult> AddCarrierBranchCategory(CreateCarrierBranchCategoryRequest CarrierBranchCategory, CancellationToken ct)
    {
        var command = new CreateCarrierBranchCategoryCommand(CarrierBranchCategory);
        var AddedCarrierBranchCategoryId = await _mediator.Send(command, cancellationToken: ct);
        return CreatedAtAction(nameof(AddCarrierBranchCategory), AddedCarrierBranchCategoryId);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[Authorize(Policy = PolicyConstants.RequireEditRole)]
    public async Task<IActionResult> DeleteCarrierBranchCategory(int id, CancellationToken ct)
    {
        var command = new DeleteCarrierBranchCategoryCommand(id);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }

    [HttpPut("{id}")]
    //[Authorize(Policy = PolicyConstants.RequireEditRole)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ExceptionDefinition))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCarrierBranchCategory(UpdateCarrierBranchCategoryRequest carrierBranchCategory, int id, CancellationToken ct)
    {
        var command = new UpdateCarrierBranchCategoryCommand(carrierBranchCategory, id);
        await _mediator.Send(command, cancellationToken: ct);
        return Ok();
    }
}
