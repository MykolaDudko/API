using ClassLibrary.DTOs;
using ClassLibrary.Models;
using MediatR;

namespace API.Application.CarrierBranchCategory;

public record FetchCustomerPickupBranchesByCategoryIdCommand(int Id) : IRequest;
