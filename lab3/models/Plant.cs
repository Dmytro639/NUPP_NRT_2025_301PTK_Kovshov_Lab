namespace Plants.Infrastructure.Models;


public class Plant
{
public int Id { get; set; }
public string Name { get; set; } = string.Empty;
public string Description { get; set; } = string.Empty;


public PlantDetail? Detail { get; set; }
public ICollection<PlantTag>? PlantTags { get; set; }
}
