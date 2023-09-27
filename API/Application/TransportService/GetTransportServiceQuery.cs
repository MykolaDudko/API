using ClassLibrary.DTOs;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using MediatR;

namespace API.Application.TransportService;

public record GetTransportServiceQuery(TransportServiceFilter Filter) : IRequest<Response<TransportServiceResponse>>;
