using ClassLibrary.DTOs;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using MediatR;

namespace API.Application.Carrier;

public record GetCarriersByFilterQuery(GetCarriersFilter Filter) : IRequest<Response<CarrierResponse>>;
