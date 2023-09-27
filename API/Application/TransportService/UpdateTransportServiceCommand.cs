using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.TransportService;

public record UpdateTransportServiceCommand(UpdateTransportServiceRequest TransportService, int Id) : IRequest;
