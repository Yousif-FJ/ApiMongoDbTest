using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiMongoDB.Models;

public class Department
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
}
