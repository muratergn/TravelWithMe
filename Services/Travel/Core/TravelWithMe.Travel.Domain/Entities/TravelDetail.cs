using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelWithMe.Travel.Domain.Entities
{
    public class TravelDetail
    {
        public string Id { get; set; }
        public string TravelId { get; set; }
        public string City { get; set; } 
        public DateTime ArrivalDate { get; set; } 
        public DateTime DepartureDate { get; set; }
        public string? Description { get; set; } 

        
        public virtual Travel Travel { get; set; }
    }
}
