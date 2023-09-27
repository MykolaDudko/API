using MediatR;

namespace API.Application.Consignor;

public record DeleteConsignorCommand(int ConsignorId) : IRequest;
