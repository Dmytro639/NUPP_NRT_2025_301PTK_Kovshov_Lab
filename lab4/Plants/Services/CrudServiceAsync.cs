using Plants.REST.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Plants.REST.Services
{
public class CrudServiceAsync<T> : ICrudServiceAsync<T> where T : class
{
private readonly IRepository<T> _repo;


public CrudServiceAsync(IRepository<T> repo)
{
_repo = repo;
}


public Task<bool> CreateAsync(T element) => _repo.CreateAsync(element);
public Task<T> ReadAsync(Guid id) => _repo.ReadAsync(id);
public Task<IEnumerable<T>> ReadAllAsync() => _repo.ReadAllAsync();
public Task<IEnumerable<T>> ReadAllAsync(int page, int amount) => _repo.ReadAllAsync(page, amount);
public Task<bool> UpdateAsync(T element) => _repo.UpdateAsync(element);
public Task<bool> RemoveAsync(T element) => _repo.RemoveAsync(element);
public Task<bool> SaveAsync() => _repo.SaveAsync();
}
}
