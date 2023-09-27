using MediatR;

namespace API.Application.CarrierBranchCategory;

public record DeleteCarrierBranchCategoryCommand(int CarrierBranchCategoryId) : IRequest;
