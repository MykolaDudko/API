using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.Carrier;

public class GetCarriersByFilterQueryHandler : IRequestHandler<GetCarriersByFilterQuery, Response<CarrierResponse>>
{
    private readonly CarrierRepository _carrierRepository;
    private readonly IMapper _mapper;

    public GetCarriersByFilterQueryHandler(IMapper mapper, CarrierRepository carrierRepository)
    {
        _carrierRepository = carrierRepository;
        _mapper = mapper;
    }

    public async Task<Response<CarrierResponse>> Handle(GetCarriersByFilterQuery request, CancellationToken ct)
    {
        var query = _carrierRepository.GetEntityLinqQueryable();
        if (request.Filter.Text != null)
        {
            query = query.Where(i => i.Name.ToLower().Contains(request.Filter.Text.ToLower()));
        }
        if (request.Filter.IsDeleted != null)
        {
            query = query.Where(i => i.IsDeleted == request.Filter.IsDeleted);
        }
        var carrierResponse = await _carrierRepository.FilterAsync(query, request.Filter.Limit, request.Filter.Offset, ct);
        return new Response<CarrierResponse>(carrierResponse.TotalItemsCount, _mapper.Map<List<CarrierResponse>>(carrierResponse.Items!.ToList()));
    }
}
