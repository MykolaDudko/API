using ClassLibrary.DTOs;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using MediatR;

namespace API.Application.CustomerPickUpBranch;

public record GetCustomerPickUpBranchesFromDbQuery(string Id, BaseFilter Filter) : IRequest<Response<CustomerPickUpBranchResponse>>;
