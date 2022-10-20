namespace Application.Repositories;
public interface IQuery<T>
{
    IQueryable<T> Query();
}