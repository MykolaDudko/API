using ClassLibrary.DTOs;
using MediatR;

namespace API.Application.Consignor;

public record UpdateConsignorCommand(UpdateConsignorRequest Consignor, int Id) : IRequest;
