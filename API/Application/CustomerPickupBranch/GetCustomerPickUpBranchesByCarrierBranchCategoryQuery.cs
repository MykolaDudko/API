using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.CustomerPickUpBranch;

public record GetCustomerPickUpBranchesByCarrierBranchCategoryQuery(int CategoryId) : IRequest<List<CustomerPickUpBranchResponse>>;