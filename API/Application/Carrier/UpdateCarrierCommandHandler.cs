using AutoMapper;
using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.Carrier;

public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommand>
{
    private readonly CarrierRepository _carrierRepository;
    private readonly IMapper _mapper;

    public UpdateCarrierCommandHandler(IMapper mapper, CarrierRepository carrierRepository)
    {
        _carrierRepository = carrierRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCarrierCommand request, CancellationToken ct)
    {
        var query = _carrierRepository.GetEntityLinqQueryable();
        query = query.Where(i => i.Id == request.Id && i.IsDeleted != true);
        var carrier = await _carrierRepository.GetAsync(query, ct);
        _mapper.Map(request.Carrier, carrier);
        await _carrierRepository.UpdateAsync(carrier, ct);
    }
}
