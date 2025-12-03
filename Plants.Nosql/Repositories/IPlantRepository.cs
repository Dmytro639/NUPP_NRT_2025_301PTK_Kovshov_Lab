using Plants.Nosql.Models;

namespace Plants.Nosql.Repositories;

public interface IPlantRepository
{
    Task<Plant> GetByIdAsync(string id);
    Task<IEnumerable<Plant>> GetAllAsync();
    Task AddAsync(Plant plant);
    Task UpdateAsync(Plant plant);
    Task DeleteAsync(string id);
}
