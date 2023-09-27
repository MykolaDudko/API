using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.Consignor;

public class GetConsignorQueryHandler : IRequestHandler<GetConsignorQuery, Response<ConsignorResponse>>
{
    private readonly ConsignorRepository _consignorRepository;
    private readonly IMapper _mapper;

    public GetConsignorQueryHandler(IMapper mapper, ConsignorRepository consignorRepository)
    {
        _consignorRepository = consignorRepository;
        _mapper = mapper;
    }

    public async Task<Response<ConsignorResponse>> Handle(GetConsignorQuery request, CancellationToken ct)
    {
        var query = _consignorRepository.GetEntityLinqQueryable();
        if (request.Filter.Id != 0)
        {
            query = query.Where(consignor => consignor.Id == request.Filter.Id);
        }
        query = query.Where(i => i.IsDeleted != true);
        var consignorResponse = await _consignorRepository.FilterAsync(query, request.Filter.Limit, request.Filter.Offset, ct);
        return new Response<ConsignorResponse>(consignorResponse.TotalItemsCount, _mapper.Map<List<ConsignorResponse>>(consignorResponse.Items));
    }
}
