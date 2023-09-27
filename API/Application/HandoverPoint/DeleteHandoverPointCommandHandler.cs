using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.HandoverPoint;

public class DeleteHandoverPointCommandHandler : IRequestHandler<DeleteHandoverPointCommand>
{
    private readonly HandoverPointRepository _handoverPointRepository;

    public DeleteHandoverPointCommandHandler(HandoverPointRepository handoverPointRepository)
    {
        _handoverPointRepository = handoverPointRepository;
    }

    public async Task Handle(DeleteHandoverPointCommand request, CancellationToken ct)
    {
        await _handoverPointRepository.DeleteAsync(i => i.Id == request.HandoverPointId && i.IsDeleted != true, ct);
    }
}
