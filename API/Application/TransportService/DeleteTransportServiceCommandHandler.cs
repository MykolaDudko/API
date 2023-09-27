using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.TransportService;

public class DeleteTransportServiceCommandHandler : IRequestHandler<DeleteTransportServiceCommand>
{
    private readonly TransportRepository _transportServiceRepository;

    public DeleteTransportServiceCommandHandler(TransportRepository transportServiceRepository)
    {
        _transportServiceRepository = transportServiceRepository;
    }

    public async Task Handle(DeleteTransportServiceCommand request, CancellationToken ct)
    {
        await _transportServiceRepository.DeleteAsync(i => i.Id == request.TransportServiceId && i.IsDeleted != true, ct);
    }
}
