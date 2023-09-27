using ClassLibrary.Context;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClassLibrary.Repositories;

public class CustomerPickupBranchRepository : BaseRepository<CustomerPickUpBranchModel>
{
    private readonly PatramDbContext _dbContext;

    public CustomerPickupBranchRepository(PatramDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task DeleteAsync(Expression<Func<CustomerPickUpBranchModel, bool>> predicate, CancellationToken ct = default)
    {
        var branch = await _dbContext.CustomerPickUpBranches.FirstAsync(predicate, cancellationToken: ct);
        branch.IsEnabled = false;
        await _dbContext.SaveChangesAsync(cancellationToken: ct);
    }
    public async Task PatchAsync(int id, bool isEnabled, CancellationToken ct = default)
    {
        var branch = await _dbContext.CustomerPickUpBranches.FirstAsync(i => i.Id == id, cancellationToken: ct);
        if(branch.IsEnabled != isEnabled)
        {
            branch.IsEnabled = isEnabled;
            await _dbContext.SaveChangesAsync(cancellationToken: ct);
        }
    }

}
