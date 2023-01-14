using ApiMongoDB.Database;
using ApiMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Driver;

namespace ApiMongoDB.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DepartementController : ControllerBase
{
    private readonly AppDb _appDb;

    public DepartementController(AppDb appDb)
    {
        _appDb = appDb;
    }
    [HttpPost]
    public async Task<IActionResult> Post(Department department)
    {
        department.Id = null;
        var collection = _appDb.MongoDatabase.GetCollection<Department>("Departments");
        
        await collection.InsertOneAsync(department);
        return Ok(department);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var collection = _appDb.MongoDatabase.GetCollection<Department>("Departments");

        return Ok(await collection.Find(_ => true).ToListAsync());
    }
}
