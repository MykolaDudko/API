using AutoMapper;

using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.Consignor;

public class UpdateConsignorCommandHandler : IRequestHandler<UpdateConsignorCommand>
{
    private readonly ConsignorRepository _consignorRepository;
    private readonly IMapper _mapper;

    public UpdateConsignorCommandHandler(IMapper mapper, ConsignorRepository consignorRepository)
    {
        _consignorRepository = consignorRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateConsignorCommand request, CancellationToken ct)
    {
        var query = _consignorRepository.GetEntityLinqQueryable();
        query = query.Where(i => i.Id == request.Id && i.IsDeleted != true);
        var consignor = await _consignorRepository.GetAsync(query, ct);
        _mapper.Map(request.Consignor, consignor);
        await _consignorRepository.UpdateAsync(consignor, ct);
    }
}
