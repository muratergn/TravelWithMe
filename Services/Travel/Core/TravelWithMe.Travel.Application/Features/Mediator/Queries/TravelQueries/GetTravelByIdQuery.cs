using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Features.Mediator.Results.TravelResult;

namespace TravelWithMe.Travel.Application.Features.Mediator.Queries.TravelQueries
{
    public class GetTravelByIdQuery : IRequest<GetTravelByIdQueryResult>
    {
        public string Id { get; set; }

        public GetTravelByIdQuery(string id)
        {
            Id = id;
        }
    }
}
