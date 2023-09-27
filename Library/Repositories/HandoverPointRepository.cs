using ClassLibrary.Context;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories;

public class HandoverPointRepository : BaseRepository<HandoverPointModel>
{
    public HandoverPointRepository(PatramDbContext dbContext) : base(dbContext)
    {
    }
}
