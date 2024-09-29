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
    public class GetTravelByIdQueryHandler : IRequestHandler<GetTravelByIdQuery,GetTravelByIdQueryResult>
    {
        private readonly IRepository<TravelWithMe.Travel.Domain.Entities.Travel> _repository;

        public GetTravelByIdQueryHandler(IRepository<Domain.Entities.Travel> repository)
        {
            _repository = repository;
        }

        public async Task<GetTravelByIdQueryResult> Handle(GetTravelByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetTravelByIdQueryResult {
                Id = values.Id,
                UserId = values.UserId,
                Destination = values.Destination,
                StartDate = values.StartDate,
                EndDate = values.EndDate,
                Notes = values.Notes
            };
        }
       
    }
}
