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
    public class GetTravelByUserIdQueryHandler : IRequestHandler<GetTravelByUserIdQuery, List<GetTravelByUserIdQueryResult>>
    {
        private readonly ITravelRepository _repository;

        public GetTravelByUserIdQueryHandler(ITravelRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTravelByUserIdQueryResult>> Handle(GetTravelByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetTravelByUserId(request.UserId);
            return values.Select(x => new GetTravelByUserIdQueryResult
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
