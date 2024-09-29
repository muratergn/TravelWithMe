using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Features.Mediator.Results.TravelResult;

namespace TravelWithMe.Travel.Application.Features.Mediator.Queries.TravelQueries
{
    public class GetTravelQuery : IRequest<List<GetTravelQueryResult>>
    {
    }
}
