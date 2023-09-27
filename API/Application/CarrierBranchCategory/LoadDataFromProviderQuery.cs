using ClassLibrary.DTOs;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public record LoadDataFromProviderQuery(string ProviderId, LoadCustomerPickupBranchFromProviderFilter Filter) : IRequest<Response<CustomerPickUpBranchResponse>>;
