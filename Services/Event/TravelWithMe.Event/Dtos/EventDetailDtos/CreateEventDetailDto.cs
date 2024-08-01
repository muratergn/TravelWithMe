namespace TravelWithMe.Event.Dtos.EventDetailDtos
{
    public class CreateEventDetailDto
    {
        public string Description { get; set; }
        public string Agenda { get; set; }
        public string Notes { get; set; }
        public string EventId { get; set; }
        public decimal ParticipantNum { get; set; }
        public decimal ParticipantLimit { get; set; }
    }
}
