using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public record GetCarrierBranchCategoryByProviderIdQuery(string ProviderId) : IRequest<List<CarrierBranchCategoryResponse>>;
