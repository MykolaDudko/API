using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using Library.Models;
using MediatR;

namespace API.Application.Carrier;

public class GetCarrierQueryHandler : IRequestHandler<GetCarrierQuery, CarrierResponse>
{
    private readonly CarrierRepository _carrierRepository;
    private readonly IMapper _mapper;

    public GetCarrierQueryHandler(IMapper mapper, CarrierRepository carrierRepository)
    {
        _carrierRepository = carrierRepository;
        _mapper = mapper;
    }

    public async Task<CarrierResponse> Handle(GetCarrierQuery request, CancellationToken ct)
    {
        var query = _carrierRepository.GetEntityLinqQueryable();
        query = query.Where(i => i.Id == request.CarrierId && i.IsDeleted != true);
        var carrier = await _carrierRepository.GetAsync(query, ct);
        return _mapper.Map<CarrierModel, CarrierResponse>(carrier);
    }
}
