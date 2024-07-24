using AutoMapper;
using MongoDB.Driver;
using TravelWithMe.Event.Dtos.EventDetailDtos;
using TravelWithMe.Event.Entities;
using TravelWithMe.Event.Settings;

namespace TravelWithMe.Event.Services.EventDetailService
{
    public class EventDetailService : IEventDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<EventDetail> _eventDetailCollection;

        public EventDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _eventDetailCollection = database.GetCollection<EventDetail>(databaseSettings.EventDetailCollectionName);
            _mapper = mapper;
        }

        public async Task<List<ResultEventDetailDto>> GetAllEventDetailsAsync()
        {
            var eventDetails = await _eventDetailCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<ResultEventDetailDto>>(eventDetails);
        }

        public async Task<ResultEventDetailDto> GetEventDetailByIdAsync(string id)
        {
            var eventDetail = await _eventDetailCollection.Find(e => e.EventDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultEventDetailDto>(eventDetail);
        }

        public async Task<ResultEventDetailDto> GetEventDetailByEventIdAsync(string eventId)
        {
            var eventDetail = await _eventDetailCollection.Find(e => e.EventId == eventId).FirstOrDefaultAsync();
            return _mapper.Map<ResultEventDetailDto>(eventDetail);
        }

        public async Task CreateEventDetailAsync(CreateEventDetailDto createEventDetailDto)
        {
            var eventDetail = _mapper.Map<EventDetail>(createEventDetailDto);
            await _eventDetailCollection.InsertOneAsync(eventDetail);
        }

        public async Task UpdateEventDetailAsync(UpdateEventDetailDto updateEventDetailDto)
        {
            var eventDetail = _mapper.Map<EventDetail>(updateEventDetailDto);
            await _eventDetailCollection.ReplaceOneAsync(e => e.EventDetailId == eventDetail.EventDetailId, eventDetail);
        }

        public async Task DeleteEventDetailAsync(string id)
        {
            await _eventDetailCollection.DeleteOneAsync(e => e.EventDetailId == id);
        }
    }
}
