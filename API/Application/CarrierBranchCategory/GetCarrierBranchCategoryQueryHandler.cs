using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public class GetCarrierBranchCategoryQueryHandler : IRequestHandler<GetCarrierBranchCategoryQuery, Response<CarrierBranchCategoryResponse>>
{
    private readonly CarrierBranchCategoryRepository _carrierBranchCategoryRepository;
    private readonly IMapper _mapper;

    public GetCarrierBranchCategoryQueryHandler(IMapper mapper, CarrierBranchCategoryRepository carrierBranchCategoryRepository)
    {
        _carrierBranchCategoryRepository = carrierBranchCategoryRepository;
        _mapper = mapper;
    }

    public async Task<Response<CarrierBranchCategoryResponse>> Handle(GetCarrierBranchCategoryQuery request, CancellationToken ct)
    {
        var query = _carrierBranchCategoryRepository.GetEntityLinqQueryable();
        if (request.Filter.CarrierId != null)
        {
            query = query.Where(i => i.CarrierId == request.Filter.CarrierId);
        }
        if (request.Filter.IsDeleted != null)
        {
            query = query.Where(i => i.IsDeleted == request.Filter.IsDeleted);
        }
        if (request.Filter.ProviderId != null)
        {
            query = query.Where(i => i.ProviderId == request.Filter.ProviderId);
        }
        var carrierBranchCategoryResponse = await _carrierBranchCategoryRepository.FilterAsync(query, request.Filter.Limit, request.Filter.Offset, ct);
        return new Response<CarrierBranchCategoryResponse>(carrierBranchCategoryResponse.TotalItemsCount,
            _mapper.Map<List<CarrierBranchCategoryResponse>>(carrierBranchCategoryResponse.Items));
    }
}
