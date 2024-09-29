using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Features.CQRS.Queries.TravelDetailQueries;
using TravelWithMe.Travel.Application.Features.CQRS.Results.TravelDetailResults;
using TravelWithMe.Travel.Application.Interfaces;
using TravelWithMe.Travel.Domain.Entities;

namespace TravelWithMe.Travel.Application.Features.CQRS.Handlers.TravelDetailHandlers
{
    public class GetTravelDetailByIdQueryHandler
    {
        private readonly IRepository<TravelDetail> _repository;

        public GetTravelDetailByIdQueryHandler(IRepository<TravelDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetTravelDetailByIdQueryResult> Handle(GetTravelDetailByIdQuery request)
        {
            var values =  await _repository.GetByIdAsync(request.Id);

            return new GetTravelDetailByIdQueryResult
            {
                Id = values.Id,
                TravelId = values.TravelId,
                City = values.City,
                ArrivalDate = values.ArrivalDate,
                DepartureDate = values.DepartureDate,
                Description = values.Description
            };

        }
    }
}
