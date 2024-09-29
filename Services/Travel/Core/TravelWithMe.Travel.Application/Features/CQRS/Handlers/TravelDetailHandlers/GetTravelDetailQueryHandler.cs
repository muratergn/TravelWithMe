using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Features.CQRS.Results.TravelDetailResults;
using TravelWithMe.Travel.Application.Interfaces;
using TravelWithMe.Travel.Domain.Entities;

namespace TravelWithMe.Travel.Application.Features.CQRS.Handlers.TravelDetailHandlers
{
    public class GetTravelDetailQueryHandler
    {
        private readonly IRepository<TravelDetail> _repository;

        public GetTravelDetailQueryHandler(IRepository<TravelDetail> travelDetailRepository)
        {
            _repository = travelDetailRepository;
        }

        public async Task<List<GetTravelDetailQueryResult>> Handle()
        {
            var travelDetail = await _repository.GetAllAsync();

            return travelDetail.Select(x => new GetTravelDetailQueryResult
            {
                Id = x.Id,
                TravelId = x.TravelId,
                City = x.City,
                ArrivalDate = x.ArrivalDate,
                DepartureDate = x.DepartureDate,
                Description = x.Description
            }).ToList();
            
           
        }
    }
}
