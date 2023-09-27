using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

using ClassLibrary.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.TransportService;

public class GetTransportServiceQueryHandler : IRequestHandler<GetTransportServiceQuery, Response<TransportServiceResponse>>
{
    private readonly TransportRepository _transportServiceRepository;
    private readonly IMapper _mapper;

    public GetTransportServiceQueryHandler(IMapper mapper, TransportRepository transportServiceRepository)
    {
        _transportServiceRepository = transportServiceRepository;
        _mapper = mapper;
    }

    public async Task<Response<TransportServiceResponse>> Handle(GetTransportServiceQuery request, CancellationToken ct)
    {
        var query = _transportServiceRepository.GetEntityLinqQueryable();
        if (request.Filter.CarrierId != null)
        {
            query = query.Where(i => i.CarrierId == request.Filter.CarrierId);
        }
        if (request.Filter.ConsignorId != null)
        {
            query = query.Where(i => i.ConsignorId == request.Filter.ConsignorId);
        }
        if (request.Filter.Name != null)
        {
            query = query.Where(i => i.Name == request.Filter.Name);
        }
        if (request.Filter.SelectabilityStatus != null)
        {
            query = query.Where(i => i.SelectabilityStatusId == request.Filter.SelectabilityStatus);
        }

        query = query.Where(i => i.IsDeleted != true);
        var transportServicesResponse = await _transportServiceRepository.FilterAsync(query, request.Filter.Limit, request.Filter.Offset, ct);
        return new Response<TransportServiceResponse>(transportServicesResponse.TotalItemsCount,
            _mapper.Map<List<TransportServiceResponse>>(transportServicesResponse.Items));
    }
}
