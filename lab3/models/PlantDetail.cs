namespace Plants.Infrastructure.Models;


public class PlantDetail
{
public int Id { get; set; }
public string Origin { get; set; } = string.Empty;
public string Climate { get; set; } = string.Empty;


public int PlantId { get; set; }
public Plant? Plant { get; set; }
}
