using AutoMapper;

using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.TransportService;

public class UpdateTransportServiceCommandHandler : IRequestHandler<UpdateTransportServiceCommand>
{
    private readonly TransportRepository _transportServiceRepository;
    private readonly IMapper _mapper;

    public UpdateTransportServiceCommandHandler(IMapper mapper, TransportRepository transportServiceRepository)
    {
        _transportServiceRepository = transportServiceRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateTransportServiceCommand request, CancellationToken ct)
    {
        var query = _transportServiceRepository.GetEntityLinqQueryable();
        query = query.Where(i => i.Id == request.Id && i.IsDeleted != true);
        var transportService = await _transportServiceRepository.GetAsync(query, ct);
        _mapper.Map(request.TransportService, transportService);
        await _transportServiceRepository.UpdateAsync(transportService, ct);
    }
}
