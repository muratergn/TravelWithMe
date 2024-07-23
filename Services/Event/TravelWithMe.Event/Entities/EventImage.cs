using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GezginBulusma.Event.Entities
{
    public class EventImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventImageId { get; set; }
        public string ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
        public string? ImageUrl3 { get; set; }
        public string? ImageUrl4 { get; set; }
        public string Caption { get; set; }


        [BsonRepresentation(BsonType.ObjectId)]
        public string EventId { get; set; }


        [BsonIgnore]
        public Event Event { get; set; }
    }
}
