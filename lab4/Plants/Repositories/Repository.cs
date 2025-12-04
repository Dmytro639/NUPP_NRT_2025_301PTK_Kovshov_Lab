using Plants.REST.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Plants.REST.Repositories
{
public class Repository<T> : IRepository<T> where T : class
{
protected readonly ApplicationDbContext _ctx;
protected readonly DbSet<T> _dbSet;


public Repository(ApplicationDbContext ctx)
{
_ctx = ctx;
_dbSet = ctx.Set<T>();
}


public async Task<bool> CreateAsync(T entity)
{
await _dbSet.AddAsync(entity);
return await SaveAsync();
}


public async Task<T> ReadAsync(Guid id)
{
return await _dbSet.FindAsync(id);
}


public async Task<IEnumerable<T>> ReadAllAsync()
{
return await _dbSet.ToListAsync();
}


public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
{
if (page < 1) page = 1;
return await _dbSet.Skip((page - 1) * amount).Take(amount).ToListAsync();
}


public async Task<bool> UpdateAsync(T entity)
{
_dbSet.Update(entity);
return await SaveAsync();
}


public async Task<bool> RemoveAsync(T entity)
{
_dbSet.Remove(entity);
return await SaveAsync();
}


public async Task<bool> SaveAsync()
{
return await _ctx.SaveChangesAsync() > 0;
}
}
}
