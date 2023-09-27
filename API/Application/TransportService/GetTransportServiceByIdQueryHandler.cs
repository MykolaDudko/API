using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.TransportService;

public class GetTransportServiceByIdQueryHandler : IRequestHandler<GetTransportServiceByIdQuery, TransportServiceResponse>
{
    private readonly TransportRepository _transportServiceRepository;
    private readonly IMapper _mapper;

    public GetTransportServiceByIdQueryHandler(IMapper mapper, TransportRepository transportServiceRepository)
    {
        _transportServiceRepository = transportServiceRepository;
        _mapper = mapper;
    }

    public async Task<TransportServiceResponse> Handle(GetTransportServiceByIdQuery request, CancellationToken ct)
    {
        var query = _transportServiceRepository.GetEntityLinqQueryable();
        query = query.Where(i => i.Id == request.Id && i.IsDeleted != true);
        var transportService = await _transportServiceRepository.GetAsync(query, ct);
        return _mapper.Map<TransportServiceModel, TransportServiceResponse>(transportService);
    }
}
