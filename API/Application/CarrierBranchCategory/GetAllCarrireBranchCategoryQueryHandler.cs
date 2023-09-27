using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public class GetAllCarrireBranchCategoryQueryHandler : IRequestHandler<GetAllCarrireBranchCategoriesQuery, List<CarrierBranchCategoryResponse>>
{
    private readonly CarrierBranchCategoryRepository _carrierBranchCategoryRepository;
    private readonly IMapper _mapper;

    public GetAllCarrireBranchCategoryQueryHandler(IMapper mapper, CarrierBranchCategoryRepository carrierBranchCategoryRepository)
    {
        _carrierBranchCategoryRepository = carrierBranchCategoryRepository;
        _mapper = mapper;
    }

    public async Task<List<CarrierBranchCategoryResponse>> Handle(GetAllCarrireBranchCategoriesQuery request, CancellationToken ct)
    {
        var carrierBranchCategories = await _carrierBranchCategoryRepository.GetAllAsync(ct);
        return _mapper.Map<List<CarrierBranchCategoryModel>, List<CarrierBranchCategoryResponse>>(carrierBranchCategories);
    }
}