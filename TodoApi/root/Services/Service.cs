using TodoApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Api.Models;

namespace TodoItemApi.Services;

public class TodoService
{
    private readonly IMongoCollection<TodoItem> Collection;

    public TodoService(
        IOptions<DatabaseSettings> DatabaseSettings)
    {
        var mongoClient = new MongoClient(
            DatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            DatabaseSettings.Value.DatabaseName);

        Collection = mongoDatabase.GetCollection<TodoItem>("todo");
    }

    public async Task<List<TodoItem>> GetAsync() =>
        await Collection.Find(_ => true).ToListAsync();

    public async Task<TodoItem?> GetAsync(string id) =>
        await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(TodoItem newTodoItem) =>
        await Collection.InsertOneAsync(newTodoItem);

    public async Task UpdateAsync(string id, TodoItem updatedTodoItem) =>
        await Collection.ReplaceOneAsync(x => x.Id == id, updatedTodoItem);

    public async Task RemoveAsync(string id) =>
        await Collection.DeleteOneAsync(x => x.Id == id);
}