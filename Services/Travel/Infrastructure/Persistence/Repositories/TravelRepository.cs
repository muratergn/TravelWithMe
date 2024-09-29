using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Application.Interfaces;
using TravelWithMe.Travel.Persistence.Context;

namespace TravelWithMe.Travel.Persistence.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private readonly TravelContext _context;

        public TravelRepository(TravelContext context)
        {
            _context = context;
        }

        public List<Domain.Entities.Travel> GetTravelByUserId(string id)
        {
            var values = _context.Travels.Where(x => x.UserId == id).ToList();
            return values;
        }
    }
}
