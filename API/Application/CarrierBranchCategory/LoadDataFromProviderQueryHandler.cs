using ClassLibrary.DTOs;
using ClassLibrary.Extensions;
using ClassLibrary.Models;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public class LoadDataFromProviderQueryHandler : IRequestHandler<LoadDataFromProviderQuery, Response<CustomerPickUpBranchResponse>>
{
    private readonly СustomerPickUpBranchManager _manager;

    public LoadDataFromProviderQueryHandler(СustomerPickUpBranchManager manager)
    {
        _manager = manager;
    }

    public async Task<Response<CustomerPickUpBranchResponse>> Handle(LoadDataFromProviderQuery request, CancellationToken ct)
    {
        var branches = await _manager.LoadDataFromProviderAsync(request.ProviderId, request.Filter, ct);
        return new Response<CustomerPickUpBranchResponse>(branches.Count, branches);
    }
}
