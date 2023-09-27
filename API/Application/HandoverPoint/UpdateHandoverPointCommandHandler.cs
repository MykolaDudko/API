using AutoMapper;

using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.HandoverPoint;

public class UpdateHandoverPointCommandHandler : IRequestHandler<UpdateHandoverPointCommand>
{
    private readonly HandoverPointRepository _handoverPointRepository;
    private readonly IMapper _mapper;

    public UpdateHandoverPointCommandHandler(IMapper mapper, HandoverPointRepository handoverPointRepository)
    {
        _handoverPointRepository = handoverPointRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateHandoverPointCommand request, CancellationToken ct)
    {
        var query = _handoverPointRepository.GetEntityLinqQueryable();
        query = query.Where(i => i.Id == request.Id && i.IsDeleted != true);
        var handoverPoint = await _handoverPointRepository.GetAsync(query, ct);
        _mapper.Map(request.HandoverPoint, handoverPoint);
        await _handoverPointRepository.UpdateAsync(handoverPoint, ct);
    }
}
