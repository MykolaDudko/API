using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.HandoverPoint;

public record UpdateHandoverPointCommand(UpdateHandoverPointRequest HandoverPoint, int Id) : IRequest;
