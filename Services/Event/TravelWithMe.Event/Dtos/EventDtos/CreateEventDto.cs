namespace GezginBulusma.Event.Dtos
{
    public class CreateEventDto
    {
        public string Title { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string MeetingPoint { get; set; }
        public string OrganizerId { get; set; }
        public string EventDetailId { get; set; }
    }
}
