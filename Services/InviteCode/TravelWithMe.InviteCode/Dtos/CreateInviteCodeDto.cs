namespace TravelWithMe.InviteCode.Dtos
{
    public class CreateInviteCodeDto
    {
        public string Code { get; set; }
        public string UserId { get; set; }
        public string EventId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
