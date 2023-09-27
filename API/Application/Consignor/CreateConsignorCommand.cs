using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.Consignor;

public record CreateConsignorCommand(CreateConsignorRequest Consignor) : IRequest<int>;
