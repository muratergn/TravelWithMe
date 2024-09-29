using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Features.Mediator.Commands.TravelCommands;
using TravelWithMe.Travel.Application.Interfaces;

namespace TravelWithMe.Travel.Application.Features.Mediator.Handlers.TravelHandlers
{
    public class CreateTravelCommandHandler : IRequestHandler<CreateTravelCommand>
    {
        private readonly IRepository<TravelWithMe.Travel.Domain.Entities.Travel> _repository;

        public CreateTravelCommandHandler(IRepository<Domain.Entities.Travel> repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateTravelCommand request, CancellationToken cancellationToken)
        {
            var travel = new Domain.Entities.Travel
            {
                UserId = request.UserId,
                Destination = request.Destination,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Notes = request.Notes
            };

            _repository.CreateAsync(travel);

            return Task.CompletedTask;        
        }
    }
}
