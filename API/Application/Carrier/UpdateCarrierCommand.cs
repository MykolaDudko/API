using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.Carrier;

public record UpdateCarrierCommand(UpdateCarrierRequest Carrier, int Id) : IRequest;
