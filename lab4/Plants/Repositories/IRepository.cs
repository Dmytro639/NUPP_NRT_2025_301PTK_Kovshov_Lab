using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Plants.REST.Repositories
{
public interface IRepository<T> where T : class
{
Task<bool> CreateAsync(T entity);
Task<T> ReadAsync(Guid id);
Task<IEnumerable<T>> ReadAllAsync();
Task<IEnumerable<T>> ReadAllAsync(int page, int amount);
Task<bool> UpdateAsync(T entity);
Task<bool> RemoveAsync(T entity);
Task<bool> SaveAsync();
}
}
