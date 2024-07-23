using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TravelWithMe.Event.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
