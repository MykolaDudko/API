using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.TransportService;

public record CreateTransportServiceCommand(CreateTransportServiceRequest TransportService) : IRequest<int>;
