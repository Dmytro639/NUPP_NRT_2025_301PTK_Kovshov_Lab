namespace Plants.Infrastructure.Models;


public class Watering
{
public int Id { get; set; }
public int PlantId { get; set; }
public Plant? Plant { get; set; }


public DateTime Date { get; set; }
}
