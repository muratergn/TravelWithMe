using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Domain.Entities;

namespace TravelWithMe.Travel.Application.Interfaces
{
    public interface ITravelRepository
    {
        public List<TravelWithMe.Travel.Domain.Entities.Travel> GetTravelByUserId(string id);
    }
}
