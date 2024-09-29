using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelWithMe.Travel.Application.Features.CQRS.Queries.TravelDetailQueries
{
    public class GetTravelDetailByIdQuery
    {
        public string Id { get; set; }

        public GetTravelDetailByIdQuery(string id)
        {
            Id = id;
        }
    }
}
