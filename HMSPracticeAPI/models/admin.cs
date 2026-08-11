using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HMSPracticeAPI.Models
{
    public class Admin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}