using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using TravelWithMe.Travel.Application.Features.CQRS.Queries.TravelQueries;
using TravelWithMe.Travel.Application.Features.CQRS.Results.TravelDetailResults;
using TravelWithMe.Travel.Application.Features.CQRS.Results.TravelResults;
using TravelWithMe.Travel.Application.Interfaces;
using TravelWithMe.Travel.Domain.Entities;

namespace TravelWithMe.Travel.Application.Features.CQRS.Handlers.TravelHandlers
{
    public class GetTravelByIdQueryHandler
    {
        private readonly IRepository<TravelWithMe.Travel.Domain.Entities.Travel> _repository;

        public GetTravelByIdQueryHandler(IRepository<TravelWithMe.Travel.Domain.Entities.Travel> repository)
        {
            _repository = repository;
        }

        public async Task<GetTravelByIdQueryResult> Handle(GetTravelByIdQuery request)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetTravelByIdQueryResult
            {
                Id = values.Id,
                UserId = values.UserId,
                Destination = values.Destination,
                StartDate = values.StartDate,
                EndDate = values.EndDate,
                Notes = values.Notes,
                TravelDetails = (List<TravelDetailResult>)values.TravelDetails,
            };
        }

    }
}
