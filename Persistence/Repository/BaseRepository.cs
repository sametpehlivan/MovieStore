using System.Linq.Expressions;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Persistence.Repository;
public class BaseRepository<TEntity, TContext> : IAsyncRepository<TEntity>, IRepository<TEntity> where TEntity : BaseEntity where TContext : DbContext
{
    protected TContext Context{get;}
    public BaseRepository(TContext context)
    {
        this.Context = context;
    }
    public  TEntity Add(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        Context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        Context.SaveChanges();
        return entity;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();
        if(!enableTracking) queryable = queryable.AsNoTracking();
        if(include != null) queryable = include(queryable);
        if(predicate != null) queryable.Where(predicate);
        if(orderBy != null) return await orderBy(queryable).ToListAsync(cancellationToken).ConfigureAwait(false);
        
        return await queryable.ToListAsync(cancellationToken).ConfigureAwait(false);

    }

    public List<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query();
        if(!enableTracking) queryable = queryable.AsNoTracking();
        if(include != null) queryable = include(queryable);
        if(predicate != null) queryable.Where(predicate);
        if(orderBy != null) return  orderBy(queryable).ToList();
        return queryable.ToList();
    }

    public IQueryable<TEntity> Query()
    {
       return Context.Set<TEntity>();
    }

    public TEntity Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
        return entity;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        await Context.SaveChangesAsync();
        return entity;
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().FirstOrDefault(predicate);
    }
}