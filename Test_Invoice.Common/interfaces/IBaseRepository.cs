using System.Linq.Expressions;

namespace Test_Invoice.Common.interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Remove(T entity);
    IQueryable<T> Get(Expression<Func<T, bool>>? where = null, string includeProperties = "");
    IQueryable<T> Get(params string[] including);
}