using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Features.CQRS.Results.TravelDetailResults;
using TravelWithMe.Travel.Domain.Entities;

namespace TravelWithMe.Travel.Application.Features.CQRS.Commands.TravelCommands
{
    public class UpdateTravelCommand
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Notes { get; set; }

        public List<TravelDetailResult> TravelDetails { get; set; }
    }
}
