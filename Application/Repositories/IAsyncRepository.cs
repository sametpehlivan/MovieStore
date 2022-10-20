using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Repositories;
public interface IAsyncRepository<T> :IQuery<T> where T : BaseEntity
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetListAsync(
        Expression<Func<T,bool>>? predicate = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTrackin = true,
        CancellationToken cancellationToken = default
    );
    Task<T> AddAsync(T entity);
    Task<T>  UpdateAsync(T entity);
    Task<T>  DeleteAsync(T entity);
}