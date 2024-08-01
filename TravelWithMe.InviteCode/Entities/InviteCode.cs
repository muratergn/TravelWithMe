using System.ComponentModel.DataAnnotations.Schema;

namespace TravelWithMe.InviteCode.Entities
{

    public class InviteCode
    {
        public int InviteCodeId { get; set; }
        public string Code { get; set; }
        public string UserId { get; set; }
        public string EventId { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ValidDate { get; set; }
    }
}
