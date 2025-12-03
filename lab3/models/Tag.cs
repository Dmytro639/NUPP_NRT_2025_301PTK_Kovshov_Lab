namespace Plants.Infrastructure.Models;


public class Tag
{
public int Id { get; set; }
public string Name { get; set; } = string.Empty;


public ICollection<PlantTag>? PlantTags { get; set; }
}
