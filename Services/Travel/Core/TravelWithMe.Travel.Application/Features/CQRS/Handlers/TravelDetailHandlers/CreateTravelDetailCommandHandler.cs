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
    public class CreateTravelDetailCommandHandler
    {
        private readonly IRepository<TravelDetail> _repository;

        public CreateTravelDetailCommandHandler(IRepository<TravelDetail> repository)
        {
            _repository = repository;
        }

        public async Task<TravelDetail> Handle(CreateTravelDetailCommand request)
        {

            var travelDetail = new TravelDetail
            {
                TravelId = request.TravelId,
                City = request.City,
                ArrivalDate = request.ArrivalDate,
                DepartureDate = request.DepartureDate,
                Description = request.Description
            };

            await _repository.CreateAsync(travelDetail);

            return travelDetail;
        }
    }
}
