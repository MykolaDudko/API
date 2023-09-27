using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public record UpdateCarrierBranchCategoryCommand(UpdateCarrierBranchCategoryRequest CarrierBranchCategory, int Id) : IRequest;
