using MongoDB.Driver;

namespace ApiMongoDB.Database;

public class AppDb
{
    public IMongoDatabase MongoDatabase { get; }
    public AppDb(IConfiguration configuration)
	{
        var connectionString = configuration["MongoDbTestConnectionString"];
        var settings = MongoClientSettings.FromConnectionString(connectionString);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
            
        MongoDatabase = client.GetDatabase("EmployeesDb");
    }

}
