using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public record GetAllCarrireBranchCategoriesQuery : IRequest<List<CarrierBranchCategoryResponse>>;
