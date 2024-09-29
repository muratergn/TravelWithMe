using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Features.CQRS.Commands.TravelCommands;
using TravelWithMe.Travel.Application.Interfaces;

namespace TravelWithMe.Travel.Application.Features.CQRS.Handlers.TravelHandlers
{
    public class RemoveTravelCommandHandler
    {
        private readonly IRepository<TravelWithMe.Travel.Domain.Entities.Travel> _repository;

        public RemoveTravelCommandHandler(IRepository<TravelWithMe.Travel.Domain.Entities.Travel> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTravelCommand request)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
