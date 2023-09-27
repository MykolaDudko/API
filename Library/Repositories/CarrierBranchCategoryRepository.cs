using ClassLibrary.Context;
using ClassLibrary.Filter;
using ClassLibrary.Models;

using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories;

public class CarrierBranchCategoryRepository : BaseRepository<CarrierBranchCategoryModel>
{

    public CarrierBranchCategoryRepository(PatramDbContext dbContext) : base(dbContext)
    {
    }

}
