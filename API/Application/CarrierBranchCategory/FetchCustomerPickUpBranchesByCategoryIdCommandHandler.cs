using ClassLibrary.DTOs;
using ClassLibrary.Extensions;
using ClassLibrary.Models;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public class FetchCustomerPickUpBranchesByCategoryIdCommandHandler : IRequestHandler<FetchCustomerPickupBranchesByCategoryIdCommand>
{
    private readonly СustomerPickUpBranchManager _manager;

    public FetchCustomerPickUpBranchesByCategoryIdCommandHandler(СustomerPickUpBranchManager manager)
    {
        _manager = manager;
    }

    public async Task Handle(FetchCustomerPickupBranchesByCategoryIdCommand request, CancellationToken ct)
    {
        await _manager.FetchByCategoryIdAsync(request.Id, ct);
    }
}
