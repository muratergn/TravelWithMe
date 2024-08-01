﻿using System.Data;

namespace TravelWithMe.InviteCode.Dtos
{
    public class UpdateInviteCodeDto
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