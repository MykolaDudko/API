using ClassLibrary.Context;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClassLibrary.Repositories;

public class TransportRepository : BaseRepository<TransportServiceModel>
{
    private readonly PatramDbContext _dbContext;

    public TransportRepository(PatramDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
