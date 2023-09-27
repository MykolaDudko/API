using ClassLibrary.Repositories;
using MediatR;

namespace API.Application.Consignor;

public class DeleteConsignorCommandHandler : IRequestHandler<DeleteConsignorCommand>
{
    private readonly ConsignorRepository _consignorRepository;

    public DeleteConsignorCommandHandler(ConsignorRepository consignorRepository)
    {
        _consignorRepository = consignorRepository;
    }

    public async Task Handle(DeleteConsignorCommand request, CancellationToken ct)
    {
        await _consignorRepository.DeleteAsync(i => i.Id == request.ConsignorId && i.IsDeleted != true, ct);
    }
}
