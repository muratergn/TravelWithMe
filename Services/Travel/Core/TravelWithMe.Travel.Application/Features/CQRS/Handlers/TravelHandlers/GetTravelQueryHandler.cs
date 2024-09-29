using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Features.CQRS.Results.TravelDetailResults;
using TravelWithMe.Travel.Application.Features.CQRS.Results.TravelResults;
using TravelWithMe.Travel.Application.Interfaces;
using TravelWithMe.Travel.Domain.Entities;

namespace TravelWithMe.Travel.Application.Features.CQRS.Handlers.TravelHandlers
{
    public class GetTravelQueryHandler
    {
        private readonly IRepository<TravelWithMe.Travel.Domain.Entities.Travel> _repository;

        public GetTravelQueryHandler(IRepository<Domain.Entities.Travel> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTravelQueryResult>> Handle() 
        { 
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTravelQueryResult
            {
                Id = x.Id,
                UserId = x.UserId,
                Destination = x.Destination,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Notes = x.Notes,
                TravelDetails = (List<TravelDetailResult>)x.TravelDetails
            }).ToList();
        }
    }
}
