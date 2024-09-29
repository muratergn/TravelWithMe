using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Features.CQRS.Commands.TravelCommands;
using TravelWithMe.Travel.Application.Features.CQRS.Results.TravelDetailResults;
using TravelWithMe.Travel.Application.Interfaces;
using TravelWithMe.Travel.Domain.Entities;

namespace TravelWithMe.Travel.Application.Features.CQRS.Handlers.TravelHandlers
{
    public class CreateTravelCommandHandler
    {
        private readonly IRepository<TravelWithMe.Travel.Domain.Entities.Travel> _repository;

        public CreateTravelCommandHandler(IRepository<Domain.Entities.Travel> repository)
        {
            _repository = repository;
        }

        public async Task<TravelWithMe.Travel.Domain.Entities.Travel> Handle(CreateTravelCommand request)
        {
            var travel = new TravelWithMe.Travel.Domain.Entities.Travel
            {
                UserId = request.UserId,
                Destination = request.Destination,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Notes = request.Notes,
                TravelDetails = request.TravelDetails.Select(detail => new TravelDetail
                {
                    Id = detail.Id,
                    TravelId = detail.TravelId,
                    City = detail.City,
                    ArrivalDate = detail.ArrivalDate,
                    DepartureDate = detail.DepartureDate,
                    Description = detail.Description
                }).ToList()
            };

            await _repository.CreateAsync(travel);

            return travel;
        }

    }
}
