using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelWithMe.Travel.Application.Features.CQRS.Commands.TravelDetailCommands
{
    public class CreateTravelDetailCommand
    {
        public string TravelId { get; set; }
        public string City { get; set; } 
        public DateTime ArrivalDate { get; set; } 
        public DateTime DepartureDate { get; set; }
        public string? Description { get; set; }
    }
}
