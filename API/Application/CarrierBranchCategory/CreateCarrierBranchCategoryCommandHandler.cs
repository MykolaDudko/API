using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public class CreateCarrierBranchCategoryCommandHandler : IRequestHandler<CreateCarrierBranchCategoryCommand, int>
{
    private readonly CarrierBranchCategoryRepository _carrierBranchCategoryRepository;
    private readonly IMapper _mapper;

    public CreateCarrierBranchCategoryCommandHandler(IMapper mapper, CarrierBranchCategoryRepository carrierBranchCategoryRepository)
    {
        _carrierBranchCategoryRepository = carrierBranchCategoryRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCarrierBranchCategoryCommand request, CancellationToken ct)
    {
        var entityId = await _carrierBranchCategoryRepository.AddAsync(_mapper.Map<CreateCarrierBranchCategoryRequest,
            CarrierBranchCategoryModel>(request.CreateCarrierBranchCategory), ct);
        return entityId;
    }
}
