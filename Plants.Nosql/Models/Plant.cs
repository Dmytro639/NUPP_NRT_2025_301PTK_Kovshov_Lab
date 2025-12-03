using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Plants.Nosql.Models;

public class Plant
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public List<string> TagIds { get; set; } = new();
}
