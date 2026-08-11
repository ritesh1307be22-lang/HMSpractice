using MongoDB.Driver;
using Microsoft.Extensions.Options;
using HMSPracticeAPI.Models;

namespace HMSPracticeAPI.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            _database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        }

        public IMongoDatabase Database => _database;
    }
}