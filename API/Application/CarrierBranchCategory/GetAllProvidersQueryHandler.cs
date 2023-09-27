using ClassLibrary.Providers;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public class GetAllProvidersQueryHandler : IRequestHandler<GetAllProvidersQuery, IReadOnlyList<ICarrierBranchProvider>>
{
    private readonly CarrierBranchProviderService _providerService;
    public GetAllProvidersQueryHandler(CarrierBranchProviderService providerService)
    {
        _providerService = providerService;
    }

    public async Task<IReadOnlyList<ICarrierBranchProvider>> Handle(GetAllProvidersQuery request, CancellationToken ct)
    {
        return _providerService.AvailableProviders;
    }
}
