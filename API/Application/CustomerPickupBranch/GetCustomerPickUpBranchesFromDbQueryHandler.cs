using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.CustomerPickUpBranch;

public class GetCustomerPickUpBranchesFromDbQueryHandler : IRequestHandler<GetCustomerPickUpBranchesFromDbQuery, Response<CustomerPickUpBranchResponse>>
{
    private readonly CustomerPickupBranchRepository _customerPickUpBranchRepository;
    private readonly IMapper _mapper;

    public GetCustomerPickUpBranchesFromDbQueryHandler(IMapper mapper, CustomerPickupBranchRepository customerPickUpBranchRepository)
    {
        _customerPickUpBranchRepository = customerPickUpBranchRepository;
        _mapper = mapper;
    }

    public async Task<Response<CustomerPickUpBranchResponse>> Handle(GetCustomerPickUpBranchesFromDbQuery request, CancellationToken ct)
    {
        var query = _customerPickUpBranchRepository.GetEntityLinqQueryable();
        query = query.Where(i => i.CarrierBranchId == request.Id && i.IsExists == true && i.IsEnabled == true)
            .Skip(request.Filter.Offset).Take(request.Filter.Limit);
        var customerPickUpBranches = await _customerPickUpBranchRepository.GetListAsync(query, ct);
        return new Response<CustomerPickUpBranchResponse>(customerPickUpBranches.Count, _mapper.Map<List<CustomerPickUpBranchModel>, List<CustomerPickUpBranchResponse>>(customerPickUpBranches));
    }
}
