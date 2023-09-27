using ClassLibrary.DTOs;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using MediatR;

namespace API.Application.Consignor;

public record GetConsignorQuery(GetByIdFilter Filter) : IRequest<Response<ConsignorResponse>>;
