using ClassLibrary.DTOs;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using MediatR;

namespace API.Application.CustomerPickUpBranch;

public record GetCustomerPickUpBranchQuery(GetCustomerPickUpBranchFilter Filter) : IRequest<Response<CustomerPickUpBranchResponse>>;
