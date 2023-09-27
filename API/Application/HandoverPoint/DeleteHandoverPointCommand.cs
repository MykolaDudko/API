using MediatR;

namespace API.Application.HandoverPoint;

public record DeleteHandoverPointCommand(int HandoverPointId) : IRequest;
