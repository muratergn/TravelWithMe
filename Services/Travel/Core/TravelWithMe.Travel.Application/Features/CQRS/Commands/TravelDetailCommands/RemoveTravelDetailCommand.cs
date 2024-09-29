using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelWithMe.Travel.Application.Features.CQRS.Commands.TravelDetailCommands
{
    public class RemoveTravelDetailCommand
    {
        public string Id { get; set; }

        public RemoveTravelDetailCommand(string id)
        {
            Id = id;
        }
    }
}
