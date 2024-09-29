using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelWithMe.Travel.Application.Features.Mediator.Commands.TravelCommands
{
    public class UpdateTravelCommand : IRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Notes { get; set; }
    }
}
