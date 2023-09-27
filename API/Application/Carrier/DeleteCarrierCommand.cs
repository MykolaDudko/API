using MediatR;

namespace API.Application.Carrier;

public record DeleteCarrierCommand(int CarrierId) : IRequest;
