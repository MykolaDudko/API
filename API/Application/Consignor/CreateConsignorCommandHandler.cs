using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.Consignor;

public class CreateConsignorCommandHandler : IRequestHandler<CreateConsignorCommand, int>
{
    private readonly ConsignorRepository _consignorRepository;
    private readonly IMapper _mapper;

    public CreateConsignorCommandHandler(IMapper mapper, ConsignorRepository consignorRepository)
    {
        _consignorRepository = consignorRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateConsignorCommand request, CancellationToken ct)
    {
        var entityId = await _consignorRepository.AddAsync(_mapper.Map<CreateConsignorRequest, ConsignorModel>(request.Consignor), ct);
        return entityId;
    }
}
