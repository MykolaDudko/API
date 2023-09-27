using ClassLibrary.Context;
using ClassLibrary.Filter;
using ClassLibrary.Models;

using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories;

public class ConsignorRepository : BaseRepository<ConsignorModel>
{
    public ConsignorRepository(PatramDbContext dbContext) : base(dbContext)
    {
    }
}
