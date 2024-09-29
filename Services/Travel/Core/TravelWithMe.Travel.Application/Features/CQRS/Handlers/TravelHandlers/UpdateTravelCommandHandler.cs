using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Features.CQRS.Commands.TravelCommands;
using TravelWithMe.Travel.Application.Interfaces;
using TravelWithMe.Travel.Domain.Entities;

namespace TravelWithMe.Travel.Application.Features.CQRS.Handlers.TravelHandlers
{
    public class UpdateTravelCommandHandler
    {
        private readonly IRepository<TravelWithMe.Travel.Domain.Entities.Travel> _repository;

        public UpdateTravelCommandHandler(IRepository<TravelWithMe.Travel.Domain.Entities.Travel> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTravelCommand request)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            if (value == null)
            {
                throw new KeyNotFoundException($"Bu {request.Id} ID'ye sahip gezi planı bulanamadı.");
            }

            value.UserId = request.UserId;
            value.Destination = request.Destination;
            value.StartDate = request.StartDate;
            value.EndDate = request.EndDate;
            value.Notes = request.Notes;

            value.TravelDetails = request.TravelDetails.Select(detail => new TravelDetail
            {
                Id = detail.Id,
                TravelId = detail.TravelId,
                City = detail.City,
                ArrivalDate = detail.ArrivalDate,
                DepartureDate = detail.DepartureDate,
                Description = detail.Description
            }).ToList();

            await _repository.UpdateAsync(value);
        }

    }
}
