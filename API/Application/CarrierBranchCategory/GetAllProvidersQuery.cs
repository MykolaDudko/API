using ClassLibrary.Providers;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public record GetAllProvidersQuery : IRequest<IReadOnlyList<ICarrierBranchProvider>>;
