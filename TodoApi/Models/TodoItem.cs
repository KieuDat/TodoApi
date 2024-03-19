using MongoDB.Bson.Serialization.Attributes;

namespace TodoApi.Models
{
    [BsonIgnoreExtraElements]
    public class TodoItem
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? UserId { get; set; }
        public bool IsComplete { get; set; }
        public string[] listItem { get; set; }

    }
}
