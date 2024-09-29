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
    public class UpdateTravelDetailCommandHandler
    {
        private readonly IRepository<TravelDetail> _repository;

        public UpdateTravelDetailCommandHandler(IRepository<TravelDetail> repository)
        {
            _repository = repository;
        }

        public async Task<TravelDetail> Handle(UpdateTravelDetailCommand request)
        {
            var travelDetail = await _repository.GetByIdAsync(request.TravelId);

            if (travelDetail == null)
            {
                throw new Exception("Travel Detail not found");
            }

            travelDetail.TravelId = request.TravelId;
            travelDetail.City = request.City;
            travelDetail.ArrivalDate = request.ArrivalDate;
            travelDetail.DepartureDate = request.DepartureDate;
            travelDetail.Description = request.Description;

            await _repository.UpdateAsync(travelDetail);

            return travelDetail;
        }
    }
}
