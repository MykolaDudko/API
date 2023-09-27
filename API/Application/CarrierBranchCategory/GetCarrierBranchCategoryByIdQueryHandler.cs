using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public class GetCarrierBranchCategoryByIdQueryHandler : IRequestHandler<GetCarrierBranchCategoryByIdQuery, CarrierBranchCategoryResponse>
{
    private readonly CarrierBranchCategoryRepository _carrierBranchCategoryRepository;
    private readonly IMapper _mapper;

    public GetCarrierBranchCategoryByIdQueryHandler(IMapper mapper, CarrierBranchCategoryRepository carrierBranchCategoryRepository)
    {
        _carrierBranchCategoryRepository = carrierBranchCategoryRepository;
        _mapper = mapper;
    }

    public async Task<CarrierBranchCategoryResponse> Handle(GetCarrierBranchCategoryByIdQuery request, CancellationToken ct)
    {
        var query = _carrierBranchCategoryRepository.GetEntityLinqQueryable();
        query = query.Where(i => i.Id == request.Id && i.IsDeleted != true);
        var carrierBranchCategory = await _carrierBranchCategoryRepository.GetAsync(query, ct);
        return _mapper.Map<CarrierBranchCategoryModel, CarrierBranchCategoryResponse>(carrierBranchCategory);
    }
}
