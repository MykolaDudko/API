using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.CustomerPickUpBranch;

public class GetCustomerPickUpBranchQueryHandler : IRequestHandler<GetCustomerPickUpBranchQuery, Response<CustomerPickUpBranchResponse>>
{
    private readonly CustomerPickupBranchRepository _customerPickUpBranchRepository;
    private readonly TransportRepository _transportRepository;
    private readonly IMapper _mapper;

    public GetCustomerPickUpBranchQueryHandler(IMapper mapper, CustomerPickupBranchRepository customerPickUpBranchRepository, TransportRepository transportRepository)
    {
        _customerPickUpBranchRepository = customerPickUpBranchRepository;
        _mapper = mapper;
        _transportRepository = transportRepository;
    }

    public async Task<Response<CustomerPickUpBranchResponse>> Handle(GetCustomerPickUpBranchQuery request, CancellationToken ct)
    {
        var query = _customerPickUpBranchRepository.GetEntityLinqQueryable();
        if (request.Filter.CategoryBranchId != null)
        {
            query = query.Where(i => i.CarrierBranchCategoryId == request.Filter.CategoryBranchId);
        }
        if (request.Filter.InternalId != null)
        {
            query = query.Where(i => i.CarrierBranchId == request.Filter.InternalId);
        }
        if (request.Filter.TransportServiceId != null)
        {
            var transprortServiceQuery = _transportRepository.GetEntityLinqQueryable();
            transprortServiceQuery = transprortServiceQuery.Where(i => i.Id == request.Filter.TransportServiceId)
                .Select(i => new TransportServiceModel { CarrierBranchCategoryId = i.CarrierBranchCategoryId });
            var transprortService = await _transportRepository.GetAsync(transprortServiceQuery, ct);
            query = query.Where(i => i.CarrierBranchCategoryId == transprortService.CarrierBranchCategoryId);
        }
        if (request.Filter.CarrierId != null)
        {
            query = query.Where(i => i.CarrierId == request.Filter.CarrierId);
        }
        if (request.Filter.ProviderId != null)
        {
            query = query.Where(i => i.CarrierBranchCategory.ProviderId.ToLower() == request.Filter.ProviderId.ToLower());
        }
        if (request.Filter.IsEnabled != null)
        {
            query = query.Where(i => i.IsEnabled == request.Filter.IsEnabled);
        }
        query = query.Where(i => i.IsDeleted != true);
        var customerPickUpBranchResponse = await _customerPickUpBranchRepository.FilterAsync(query, request.Filter.Limit, request.Filter.Offset, ct);
        return new Response<CustomerPickUpBranchResponse>(customerPickUpBranchResponse.TotalItemsCount, _mapper.Map<List<CustomerPickUpBranchResponse>>(customerPickUpBranchResponse.Items));
    }
}
