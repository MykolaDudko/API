using ClassLibrary.Filter;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using Library.Models;
using MediatR;

namespace API.Application.Carrier;

public class DeleteCarrierCommandHandler : IRequestHandler<DeleteCarrierCommand>
{
    private readonly CarrierRepository _carrierRepository;

    public DeleteCarrierCommandHandler(CarrierRepository carrierRepository)
    {
        _carrierRepository = carrierRepository;
    }

    public async Task Handle(DeleteCarrierCommand request, CancellationToken ct)
    {
        await _carrierRepository.DeleteAsync(i=>i.Id == request.CarrierId && i.IsDeleted != true, ct);
    }
}
