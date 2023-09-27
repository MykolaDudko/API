using AutoMapper;
using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public class UpdateCarrierBranchCategoryCommandHandler : IRequestHandler<UpdateCarrierBranchCategoryCommand>
{
    private readonly CarrierBranchCategoryRepository _carrierBranchCategoryRepository;
    private readonly IMapper _mapper;

    public UpdateCarrierBranchCategoryCommandHandler(IMapper mapper, CarrierBranchCategoryRepository carrierBranchCategoryRepository)
    {
        _carrierBranchCategoryRepository = carrierBranchCategoryRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCarrierBranchCategoryCommand request, CancellationToken ct)
    {
        var query = _carrierBranchCategoryRepository.GetEntityLinqQueryable();
        query = query.Where(i => i.Id == request.Id && i.IsDeleted != true);
        var carrierBranchCategory = await _carrierBranchCategoryRepository.GetAsync(query, ct);
        _mapper.Map(request.CarrierBranchCategory, carrierBranchCategory);
        await _carrierBranchCategoryRepository.UpdateAsync(carrierBranchCategory, ct);
    }
}
