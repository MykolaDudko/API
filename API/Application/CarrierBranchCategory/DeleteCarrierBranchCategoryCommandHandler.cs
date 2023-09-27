using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public class DeleteCarrierBranchCategoryCommandHandler : IRequestHandler<DeleteCarrierBranchCategoryCommand>
{
    private readonly CarrierBranchCategoryRepository _carrierBranchCategoryRepository;

    public DeleteCarrierBranchCategoryCommandHandler(CarrierBranchCategoryRepository carrierBranchCategoryRepository)
    {
        _carrierBranchCategoryRepository = carrierBranchCategoryRepository;
    }

    public async Task Handle(DeleteCarrierBranchCategoryCommand request, CancellationToken ct)
    {
        await _carrierBranchCategoryRepository.DeleteAsync(i => i.Id == request.CarrierBranchCategoryId, ct);
    }
}
