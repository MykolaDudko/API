using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.CustomerPickUpBranch;

public class UpdateCustomerPickUpBranchIsEnabledCommandHandler : IRequestHandler<UpdateCustomerPickUpBranchIsEnabledCommand>
{
    private readonly CustomerPickupBranchRepository _customerPickUpBranchRepository;

    public UpdateCustomerPickUpBranchIsEnabledCommandHandler(CustomerPickupBranchRepository customerPickUpBranchRepository)
    {
        _customerPickUpBranchRepository = customerPickUpBranchRepository;
    }

    public async Task Handle(UpdateCustomerPickUpBranchIsEnabledCommand request, CancellationToken ct)
    {
        await _customerPickUpBranchRepository.PatchAsync(request.CustomerPickUpBranchId, request.IsEnabled, ct);
    }
}
