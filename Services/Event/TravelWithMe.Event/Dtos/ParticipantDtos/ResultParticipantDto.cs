﻿namespace TravelWithMe.Event.Dtos.ParticipantDtos
{
    public class ResultParticipantDto
    {
        public string ParticipantId { get; set; }
        public string EventId { get; set; }
        public string UserId { get; set; }
        public bool IsApproved { get; set; }
    }
}