using System;


namespace Lab2Plants
{
public class Plant : IEntity
{
public Guid Id { get; set; }
public string Name { get; set; }
public int HeightCm { get; set; }
public int LeafCount { get; set; }
public int ToxicLevel { get; set; } // 0..10


public Plant() { }


public static Plant CreateNew()
{
var rnd = ThreadSafeRandom.Instance;
return new Plant
{
Id = Guid.NewGuid(),
Name = $"Plant_" + Guid.NewGuid().ToString("N").Substring(0, 6),
HeightCm = rnd.Next(5, 300),
LeafCount = rnd.Next(0, 500),
ToxicLevel = rnd.Next(0, 11)
};
}


public override string ToString() => $"{Name} (Id={Id}) H={HeightCm}cm Leaves={LeafCount} Toxic={ToxicLevel}";
}
}
