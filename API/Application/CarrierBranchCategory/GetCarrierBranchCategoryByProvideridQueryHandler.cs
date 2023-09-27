using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public class GetCarrierBranchCategoryByProvideridHandler : IRequestHandler<GetCarrierBranchCategoryByProviderIdQuery, List<CarrierBranchCategoryResponse>>
{
    private readonly CarrierBranchCategoryRepository _carrierBranchCategoryRepository;
    private readonly IMapper _mapper;

    public GetCarrierBranchCategoryByProvideridHandler(IMapper mapper, CarrierBranchCategoryRepository carrierBranchCategoryRepository)
    {
        _carrierBranchCategoryRepository = carrierBranchCategoryRepository;
        _mapper = mapper;
    }

    public async Task<List<CarrierBranchCategoryResponse>> Handle(GetCarrierBranchCategoryByProviderIdQuery request, CancellationToken ct)
    {
        var query = _carrierBranchCategoryRepository.GetEntityLinqQueryable();
        query = query.Where(i => i.ProviderId == request.ProviderId);
        var carrierBranchCategories = await _carrierBranchCategoryRepository.GetListAsync(query, ct);
        return _mapper.Map<List<CarrierBranchCategoryModel>, List<CarrierBranchCategoryResponse>>(carrierBranchCategories);
    }
}
