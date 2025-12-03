namespace Plants.Infrastructure.Services;


public interface ICrudServiceAsync<T> where T : class
{
Task<List<T>> GetAllAsync();
Task<T?> GetAsync(int id);
Task<T> CreateAsync(T entity);
Task UpdateAsync(T entity);
Task DeleteAsync(int id);
}
