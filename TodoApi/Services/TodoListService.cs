
using Database.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TodoListApi.Models;

namespace TodoListApi.Services
{
    public class TodoListService
    {
        private readonly IMongoCollection<TodoListItem> Collection;
        public TodoListService(
            IOptions<DatabaseSettings> DatabaseSettings) 
        {
            var mongoClient = new MongoClient(
                DatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                DatabaseSettings.Value.DatabaseName);

            Collection = mongoDatabase.GetCollection<TodoListItem>(DatabaseSettings.Value.TodoList);
        }
        public async Task<List<TodoListItem>> GetAsync() => 
            await Collection.Find(_ => true).ToListAsync();
     
    }
}
