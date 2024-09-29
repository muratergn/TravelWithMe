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
    public class RemoveTravelCommandHandler : IRequestHandler<RemoveTravelCommand>
    {
        private readonly IRepository<TravelWithMe.Travel.Domain.Entities.Travel> _repository;

        public RemoveTravelCommandHandler(IRepository<Domain.Entities.Travel> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTravelCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
