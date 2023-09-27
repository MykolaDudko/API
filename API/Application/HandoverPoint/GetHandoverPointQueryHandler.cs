using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.HandoverPoint;

public class GetHandoverPointQueryHandler : IRequestHandler<GetHandoverPointQuery, Response<HandoverPointResponse>>
{
    private readonly HandoverPointRepository _handoverPointRepository;
    private readonly IMapper _mapper;

    public GetHandoverPointQueryHandler(IMapper mapper, HandoverPointRepository handoverPointRepository)
    {
        _handoverPointRepository = handoverPointRepository;
        _mapper = mapper;
    }

    public async Task<Response<HandoverPointResponse>> Handle(GetHandoverPointQuery request, CancellationToken ct)
    {
        var query = _handoverPointRepository.GetEntityLinqQueryable();
        if (request.Filter.Id != 0)
        {
            query = query.Where(i => i.Id == request.Filter.Id);
        }
        query = query.Where(i => i.IsDeleted != true);
        var handoverPointResponse = await _handoverPointRepository.FilterAsync(query, request.Filter.Limit, request.Filter.Offset, ct);
        return new Response<HandoverPointResponse>(handoverPointResponse.TotalItemsCount, _mapper.Map<List<HandoverPointResponse>>(handoverPointResponse.Items));
    }
}
