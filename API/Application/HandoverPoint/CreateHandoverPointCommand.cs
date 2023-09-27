using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.HandoverPoint;

public record CreateHandoverPointCommand(CreateHandoverPointRequest HandOverPoint) : IRequest<int>;
