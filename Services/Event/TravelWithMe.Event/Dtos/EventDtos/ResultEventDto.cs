namespace TravelWithMe.Event.Dtos.EventDtos
{
    public class ResultEventDto
    {
        public string EventId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string MeetingPoint { get; set; }
        public string OrganizerId { get; set; }
    }
}
