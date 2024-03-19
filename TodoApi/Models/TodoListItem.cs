using MongoDB.Bson.Serialization.Attributes;

namespace TodoListApi.Models
{
    [BsonIgnoreExtraElements]
    public class TodoListItem
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? UserId { get; set; }
        public string IsComplete { get; set; }
    }

}
