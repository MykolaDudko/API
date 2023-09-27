using ClassLibrary.DTOs;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public record GetCarrierBranchCategoryQuery(GetCarrierBranchCategoryFilter Filter) : IRequest<Response<CarrierBranchCategoryResponse>>;
