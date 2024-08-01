using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TravelWithMe.Event.Entities
{
    public class EventDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventDetailId { get; set; }
        public string Description { get; set; }
        public string Agenda { get; set; }
        public string Notes { get; set; }
        public decimal ParticipantNum { get; set; }
        public decimal ParticipantLimit { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string EventId { get; set; }


        [BsonIgnore]
        public Event Event { get; set; }
    }
}
