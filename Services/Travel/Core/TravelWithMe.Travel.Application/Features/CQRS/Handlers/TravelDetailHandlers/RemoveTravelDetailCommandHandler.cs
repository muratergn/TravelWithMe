using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Features.CQRS.Commands.TravelDetailCommands;
using TravelWithMe.Travel.Application.Interfaces;
using TravelWithMe.Travel.Domain.Entities;

namespace TravelWithMe.Travel.Application.Features.CQRS.Handlers.TravelDetailHandlers
{
    public class RemoveTravelDetailCommandHandler
    {
        private readonly IRepository<TravelDetail> _repository;

        public RemoveTravelDetailCommandHandler(IRepository<TravelDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTravelDetailCommand request)
        {
            var travelDetail = await _repository.GetByIdAsync(request.Id);

            if (travelDetail == null)
            {
                throw new Exception("Travel Detail not found");
            }

            await _repository.DeleteAsync(travelDetail);
        }
    }
}
