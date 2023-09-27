using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.Carrier;

public record GetCarrierQuery(int CarrierId) : IRequest<CarrierResponse>;
