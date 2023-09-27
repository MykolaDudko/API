using ClassLibrary.Context;
using ClassLibrary.Filter;
using ClassLibrary.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories;

public class CarrierRepository : BaseRepository<CarrierModel>
{
    public CarrierRepository(PatramDbContext dbContext) : base(dbContext)
    {
    }
}
