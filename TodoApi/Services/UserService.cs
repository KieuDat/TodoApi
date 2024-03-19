using Database.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserApi.Models;

namespace User.Services
{
    public class UserService
    {
        private readonly IMongoCollection<UserItem> Collection;
        public UserService(IOptions<DatabaseSettings> DataBaseSettings)
        {
            var mongoClient = new MongoClient(
                DataBaseSettings.Value.ConnectionString);
            var MongoDataBase = mongoClient.GetDatabase(
                DataBaseSettings.Value.DatabaseName);
            Collection = MongoDataBase.GetCollection<UserItem>(DataBaseSettings.Value.User);
        }
        public async Task<List<UserItem>> GetUsersAsync() =>
        await Collection.Find(_ => true).ToListAsync();

        public async Task<UserItem?> GetAsync(string id) =>
        await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(UserItem newUser) =>
            await Collection.InsertOneAsync(newUser);

        public async Task UpdateAsync(string id, UserItem updatedUser) =>
            await Collection.ReplaceOneAsync(x => x.Id == id, updatedUser);

        public async Task RemoveAsync(string id) =>
            await Collection.DeleteOneAsync(x => x.Id == id);
    }
}
