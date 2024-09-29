using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Features.CQRS.Results.TravelDetailResults;

namespace TravelWithMe.Travel.Application.Features.Mediator.Results.TravelResult
{
    public class GetTravelQueryResult
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Notes { get; set; }
    }
}
