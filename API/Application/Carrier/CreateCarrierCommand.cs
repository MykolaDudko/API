using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.Carrier;

public record CreateCarrierCommand(CreateCarrierRequest Carrier) : IRequest<int>;
