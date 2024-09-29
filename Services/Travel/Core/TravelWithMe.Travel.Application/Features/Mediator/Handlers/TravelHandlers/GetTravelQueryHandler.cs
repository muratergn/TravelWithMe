using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Features.Mediator.Queries.TravelQueries;
using TravelWithMe.Travel.Application.Features.Mediator.Results.TravelResult;
using TravelWithMe.Travel.Application.Interfaces;

namespace TravelWithMe.Travel.Application.Features.Mediator.Handlers.TravelHandlers
{
    internal class GetTravelQueryHandler : IRequestHandler<GetTravelQuery, List<GetTravelQueryResult>>
    {
        private readonly IRepository<TravelWithMe.Travel.Domain.Entities.Travel> _repository;

        public GetTravelQueryHandler(IRepository<Domain.Entities.Travel> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTravelQueryResult>> Handle(GetTravelQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTravelQueryResult
            {
                UserId = x.UserId,
                Id = x.Id,
                Destination = x.Destination,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Notes = x.Notes
            }).ToList();
        }
    }
}
