using ApiMongoDB.Database;
using ApiMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace ApiMongoDB.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly AppDb _appDb;
    
    public EmployeeController(AppDb appDb)
    {
        _appDb = appDb;
    }
    [HttpPost]
    public async Task<IActionResult> Post(Employee employee)
    {
        employee.Id = null;
        
        var collection = _appDb.MongoDatabase.GetCollection<Employee>("Employees");

        await collection.InsertOneAsync(employee);
        return Ok(employee);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var EmpCollection = _appDb.MongoDatabase.GetCollection<Employee>("Employees");

        var employees = await EmpCollection.Find(_ => true)
            .ToListAsync();

        return Ok(employees);
    }
}
