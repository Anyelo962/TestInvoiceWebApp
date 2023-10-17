using System.Linq.Expressions;
using LinqKit.Core;
using Microsoft.EntityFrameworkCore;
using Test_Invoice.Common.interfaces;
using Test_Invoice.Infrastructure.DbContextConfig;

namespace Test_Invoice.Infrastructure.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly TestInvoiceContext _context;
    private DbSet<T> _entities;

    public BaseRepository(TestInvoiceContext context)
    {
        this._context = context;
        _entities = _context.Set<T>();
    }
    public async   Task<List<T>> GetAll() => await _entities.AsNoTracking().ToListAsync();

    public async Task<T> GetById(int id) => await _entities.FindAsync(id);

    public async Task Add(T entity)
    {
       await _entities.AddAsync(entity);
       await _context.SaveChangesAsync();
    }

    public async Task<bool> Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        var result = await _context.SaveChangesAsync();
        
        return result > 0 ? true : false;
    }

    public async Task<bool> Remove(T entity)
    {
    //  var entity_data =   await _entities.FindAsync(entity);

      _entities.Remove(entity);

      var result = await _context.SaveChangesAsync();


      return result > 0 ? true : false;

    }

    public IQueryable<T> Get(Expression<Func<T, bool>>? where = null, string includeProperties = "")
    {
        throw new NotImplementedException();
    }
    
    public IQueryable<T> Get(params string[] including)
    {
        var query = _entities.AsQueryable();
        
        including!.ToList().ForEach(include =>
        {
            if (!string.IsNullOrEmpty(include))
                query = query.Include(include).AsExpandable();
        });
        
        return query;
    }
}