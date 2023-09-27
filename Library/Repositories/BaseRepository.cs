using ClassLibrary.Context;
using ClassLibrary.Filters;
using ClassLibrary.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClassLibrary.Repositories;
public abstract class BaseRepository<TEntity> where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _set;
    private readonly PatramDbContext _dbContext;
    public BaseRepository(PatramDbContext dbContext)
    {
        _dbContext = dbContext;
        _set = _dbContext.Set<TEntity>();
    }

    public virtual async Task<int> AddAsync(TEntity entity, CancellationToken ct = default)
    {
        await _set.AddAsync(entity, cancellationToken: ct);
        await _dbContext.SaveChangesAsync(cancellationToken: ct);
        return entity.Id;
    }
    public virtual async Task AddListAsync(List<TEntity> entity, CancellationToken ct = default)
    {
        await _set.AddRangeAsync(entity, cancellationToken: ct);
        await _dbContext.SaveChangesAsync(cancellationToken: ct);
    }
    public virtual async Task<TEntity> GetAsync(IQueryable<TEntity> query, CancellationToken ct = default)
    {
        var entity = await query.FirstAsync(cancellationToken: ct);
        return entity;
    }
    public virtual async Task<List<TEntity>> GetListAsync(IQueryable<TEntity> query, CancellationToken ct = default)
    {
        var entity = await query.ToListAsync(cancellationToken: ct);
        return entity;
    }
    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken ct = default)
    {
        var entity = await _set.AsNoTracking().ToListAsync(cancellationToken: ct);
        return entity;
    }

    public async Task<Response<TEntity>> FilterAsync(IQueryable<TEntity> query, int limit, int offset, CancellationToken ct = default)
    {
        var count = await query.CountAsync(cancellationToken: ct);
        var items = await query.Skip(offset).Take(limit).ToListAsync(cancellationToken: ct);

        return new Response<TEntity>(count, items);
    }


    public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
    {
        var entity = await _set.Where(predicate).FirstAsync(cancellationToken: ct);
        entity.IsDeleted = true;
        await _dbContext.SaveChangesAsync(cancellationToken: ct);
    }
    public virtual async Task UpdateAsync(TEntity entity, CancellationToken ct = default)
    {
        _set.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken: ct);
    }
    public async Task UpdateRangeAsync(List<TEntity> entity, CancellationToken ct = default)
    {
        _set.UpdateRange(entity);
        await _dbContext.SaveChangesAsync(cancellationToken: ct);
    }

    public IQueryable<TEntity> GetEntityLinqQueryable(bool asNoTracking = true)
    {
        if (asNoTracking)
            return _set.AsNoTracking();

        return _set;
    }
    public async Task<bool> AnyRecordExists(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
    {
        var existence = await _set.AnyAsync(predicate, cancellationToken: ct);
        return existence;
    }
    public async Task<TEntity?> GetNullableAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
    {
        var entity = await _set.AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken: ct);
        return entity;
    }

}
