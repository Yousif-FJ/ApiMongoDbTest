using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ApiMongoDB.Models;

public class Employee
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Department> Departments { get; set; } = Array.Empty<Department>();
}
