using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using Library.Models;
using MediatR;

namespace API.Application.Carrier;

public class CreateCarrierCommandHandler : IRequestHandler<CreateCarrierCommand, int>
{
    private readonly CarrierRepository _carrierRepository;
    private readonly IMapper _mapper;

    public CreateCarrierCommandHandler(IMapper mapper, CarrierRepository carrierRepository)
    {
        _carrierRepository = carrierRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCarrierCommand request, CancellationToken ct)
    {
        var product = await _carrierRepository.AddAsync(_mapper.Map<CreateCarrierRequest, CarrierModel>(request.Carrier), ct);
        return product;
    }
}
