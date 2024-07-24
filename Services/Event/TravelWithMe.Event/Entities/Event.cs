using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using TravelWithMe.Event.Entities;

namespace TravelWithMe.Event.Entities
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string MeetingPoint { get; set; }


        [BsonRepresentation(BsonType.ObjectId)]
        public string OrganizerId { get; set; }


        [BsonIgnore]
        public User Organizer { get; set; }


        /*[BsonRepresentation(BsonType.ObjectId)]
        public string EventDetailId { get; set; }


        [BsonIgnore]
        public EventDetail Details { get; set; }


        [BsonIgnore]
        public List<EventImage> Images { get; set; }*/

    }
}
