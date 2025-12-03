using MongoDB.Driver;
using Plants.Nosql.Models;

namespace Plants.Nosql.Repositories;

public class PlantRepository : IPlantRepository
{
    private readonly IMongoCollection<Plant> _plants;

    public PlantRepository(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _plants = database.GetCollection<Plant>("Plants");
    }

    public async Task AddAsync(Plant plant) => 
        await _plants.InsertOneAsync(plant);

    public async Task DeleteAsync(string id) =>
        await _plants.DeleteOneAsync(p => p.Id == id);

    public async Task<IEnumerable<Plant>> GetAllAsync() =>
        await _plants.Find(_ => true).ToListAsync();

    public async Task<Plant> GetByIdAsync(string id) =>
        await _plants.Find(p => p.Id == id).FirstOrDefaultAsync() ?? throw new Exception("Not found");

    public async Task UpdateAsync(Plant plant) =>
        await _plants.ReplaceOneAsync(p => p.Id == plant.Id, plant);
}
