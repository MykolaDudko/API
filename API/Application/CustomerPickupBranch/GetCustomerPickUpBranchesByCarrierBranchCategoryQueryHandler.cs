using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.CustomerPickUpBranch;

public class GetCustomerPickUpBranchesByCarrierBranchCategoryQueryHandler : IRequestHandler<GetCustomerPickUpBranchesByCarrierBranchCategoryQuery, List<CustomerPickUpBranchResponse>>
{
    private readonly CustomerPickupBranchRepository _customerPickUpBranchRepository;
    private readonly IMapper _mapper;

    public GetCustomerPickUpBranchesByCarrierBranchCategoryQueryHandler(IMapper mapper, CustomerPickupBranchRepository customerPickUpBranchRepository)
    {
        _customerPickUpBranchRepository = customerPickUpBranchRepository;
        _mapper = mapper;
    }

    public async Task<List<CustomerPickUpBranchResponse>> Handle(GetCustomerPickUpBranchesByCarrierBranchCategoryQuery request, CancellationToken ct)
    {
        var query = _customerPickUpBranchRepository.GetEntityLinqQueryable();
        query = query.Where(i => i.CarrierBranchCategoryId == request.CategoryId && i.IsExists == true && i.IsEnabled == true);
        var customerPickUpBranches = await _customerPickUpBranchRepository.GetListAsync(query, ct);
        return _mapper.Map<List<CustomerPickUpBranchModel>, List<CustomerPickUpBranchResponse>>(customerPickUpBranches);
    }
}
