using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelWithMe.Travel.Application.Features.Mediator.Commands.TravelCommands
{
    public class RemoveTravelCommand : IRequest
    {
        public string Id { get; set; }

        public RemoveTravelCommand(string id)
        {
            Id = id;
        }
    }
}
