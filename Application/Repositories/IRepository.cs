using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Repositories;
public interface IRepository<T> :IQuery<T> where T : BaseEntity
{
    T? Get(Expression<Func<T,bool>> predicate);
    List<T> GetList(
        Expression<Func<T,bool>>? predicate = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTrackin = true
    );
    T Add(T entity);
    T Update(T entity);
    T Delete(T entity);
}