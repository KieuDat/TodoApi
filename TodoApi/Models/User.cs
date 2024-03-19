using MongoDB.Bson.Serialization.Attributes;

namespace UserApi.Models
{
    [BsonIgnoreExtraElements]
    public class UserItem
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
