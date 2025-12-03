using Microsoft.EntityFrameworkCore;
using Plants.Infrastructure.Data;


namespace Plants.Infrastructure.Repositories;


public class EfRepository<T> : IRepository<T> where T : class
{
private readonly PlantsContext _context;
private readonly DbSet<T> _set;


public EfRepository(PlantsContext context)
{
_context = context;
_set = context.Set<T>();
}


public async Task<List<T>> GetAllAsync() =>
await _set.ToListAsync();


public async Task<T?> GetByIdAsync(int id) =>
await _set.FindAsync(id);


public async Task<T> AddAsync(T entity)
{
_set.Add(entity);
await _context.SaveChangesAsync();
return entity;
}


public async Task UpdateAsync(T entity)
{
_set.Update(entity);
await _context.SaveChangesAsync();
}


public async Task DeleteAsync(int id)
{
var entity = await _set.FindAsync(id);
if (entity != null)
{
_set.Remove(entity);
await _context.SaveChangesAsync();
}
}
}
