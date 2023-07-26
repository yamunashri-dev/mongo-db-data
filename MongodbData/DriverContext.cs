using MongodbData.Model;
using MongoDB.Driver;


namespace MongodbData
{
    public class DriverContext
    {
        private readonly IMongoDatabase _database;

        public DriverContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoDBSettings:ConnectionString").Value;
            var databaseName = configuration.GetSection("MongoDBSettings:DatabaseName").Value;
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
        public IMongoCollection<Driver> Drivers => _database.GetCollection<Driver>("Drivers");
    }
}
