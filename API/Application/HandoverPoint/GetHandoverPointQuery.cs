using ClassLibrary.DTOs;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using MediatR;

namespace API.Application.HandoverPoint;

public record GetHandoverPointQuery(GetByIdFilter Filter) : IRequest<Response<HandoverPointResponse>>;
