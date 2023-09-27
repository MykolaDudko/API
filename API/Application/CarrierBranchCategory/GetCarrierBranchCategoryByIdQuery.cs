using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public record GetCarrierBranchCategoryByIdQuery(int Id) : IRequest<CarrierBranchCategoryResponse>;
