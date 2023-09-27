using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.TransportService;

public class CreateTransportServiceCommandHandler : IRequestHandler<CreateTransportServiceCommand, int>
{
    private readonly TransportRepository _transportServiceRepository;
    private readonly IMapper _mapper;

    public CreateTransportServiceCommandHandler(IMapper mapper, TransportRepository transportServiceRepository)
    {
        _transportServiceRepository = transportServiceRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateTransportServiceCommand request, CancellationToken ct)
    {
        var entityId = await _transportServiceRepository.AddAsync(_mapper.Map<CreateTransportServiceRequest, TransportServiceModel>(request.TransportService), ct);
        return entityId;
    }
}
