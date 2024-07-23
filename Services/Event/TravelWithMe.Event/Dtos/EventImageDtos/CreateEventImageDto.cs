namespace TravelWithMe.Event.Dtos.EventImageDtos
{
    public class CreateEventImageDto
    {
        public string ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
        public string? ImageUrl3 { get; set; }
        public string? ImageUrl4 { get; set; }
        public string Caption { get; set; }
        public string EventId { get; set; }
    }
}
