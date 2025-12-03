using Plants.Infrastructure.Repositories;


namespace Plants.Infrastructure.Services;


public class CrudServiceAsync<T> : ICrudServiceAsync<T> where T : class
{
private readonly IRepository<T> _repository;


public CrudServiceAsync(IRepository<T> repository)
{
_repository = repository;
}


public Task<List<T>> GetAllAsync() => _repository.GetAllAsync();


public Task<T?> GetAsync(int id) => _repository.GetByIdAsync(id);


public Task<T> CreateAsync(T entity) => _repository.AddAsync(entity);


public Task UpdateAsync(T entity) => _repository.UpdateAsync(entity);


public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}
