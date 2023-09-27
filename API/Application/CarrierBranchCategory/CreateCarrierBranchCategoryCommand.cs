using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public record CreateCarrierBranchCategoryCommand(CreateCarrierBranchCategoryRequest CreateCarrierBranchCategory) : IRequest<int>;
