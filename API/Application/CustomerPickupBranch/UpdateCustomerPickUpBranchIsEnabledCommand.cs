using MediatR;

namespace API.Application.CustomerPickUpBranch;

public record UpdateCustomerPickUpBranchIsEnabledCommand(int CustomerPickUpBranchId, bool IsEnabled) : IRequest;
