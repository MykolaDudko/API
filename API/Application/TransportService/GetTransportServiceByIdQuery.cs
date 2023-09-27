using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.TransportService;

public record GetTransportServiceByIdQuery(int Id) : IRequest<TransportServiceResponse>;
