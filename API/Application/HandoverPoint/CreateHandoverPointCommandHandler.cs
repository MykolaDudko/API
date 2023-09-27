using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.HandoverPoint;

public class CreateHandoverPointCommandHandler : IRequestHandler<CreateHandoverPointCommand, int>
{
    private readonly HandoverPointRepository _handoverPointRepository;
    private readonly IMapper _mapper;

    public CreateHandoverPointCommandHandler(IMapper mapper, HandoverPointRepository handoverPointRepository)
    {
        _handoverPointRepository = handoverPointRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateHandoverPointCommand request, CancellationToken ct)
    {
        var entityId = await _handoverPointRepository.AddAsync(_mapper.Map<CreateHandoverPointRequest, HandoverPointModel>(request.HandOverPoint), ct);
        return entityId;
    }
}
