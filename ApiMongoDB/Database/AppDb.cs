using MongoDB.Driver;

namespace ApiMongoDB.Database;

public class AppDb
{
    public IMongoDatabase MongoDatabase { get; }
    public AppDb()
	{
        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://mongo:U99jCSqUj8Y9l5LS@cluster0.dawys7q.mongodb.net/?retryWrites=true&w=majority");
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
            
        MongoDatabase = client.GetDatabase("EmployeesDb");
    }

}
