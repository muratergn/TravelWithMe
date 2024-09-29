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
    public class UpdateTravelCommandHandler : IRequestHandler<UpdateTravelCommand>
    {
        private readonly IRepository<TravelWithMe.Travel.Domain.Entities.Travel> _repository;

        public UpdateTravelCommandHandler(IRepository<Domain.Entities.Travel> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTravelCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.UserId = request.UserId;
            values.Destination = request.Destination;
            values.StartDate = request.StartDate;
            values.EndDate = request.EndDate;
            values.Notes = request.Notes;
            await _repository.UpdateAsync(values);
        }
    }
}
