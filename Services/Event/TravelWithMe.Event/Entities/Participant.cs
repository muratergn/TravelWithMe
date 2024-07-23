using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TravelWithMe.Event.Entities
{
    public class Participant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ParticipantId { get; set; }


        [BsonRepresentation(BsonType.ObjectId)]
        public string EventId { get; set; }


        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }


        public bool IsApproved { get; set; }
    }
}
