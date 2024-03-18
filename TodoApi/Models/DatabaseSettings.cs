using TodoApi.Models;

namespace Api.Models;

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CollectionName { get; set; } = null!;

    internal Task<List<TodoItem>> GetAsync(string id)
    {
        throw new NotImplementedException();
    }
}