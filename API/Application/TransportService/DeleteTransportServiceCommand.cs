using MediatR;

namespace API.Application.TransportService;

public record DeleteTransportServiceCommand(int TransportServiceId) : IRequest;
