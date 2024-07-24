using AutoMapper;
using MongoDB.Driver;
using TravelWithMe.Event.Dtos.EventDtos;
using TravelWithMe.Event.Settings;

namespace TravelWithMe.Event.Services.EventServices
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<TravelWithMe.Event.Entities.Event> _eventCollection;

        public EventService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _eventCollection = database.GetCollection<TravelWithMe.Event.Entities.Event>(databaseSettings.EventCollectionName);
            _mapper = mapper;
        }

        public async Task CreateEventAsync(CreateEventDto createEventDto)
        {
            var eventItem = _mapper.Map<TravelWithMe.Event.Entities.Event>(createEventDto);
            await _eventCollection.InsertOneAsync(eventItem);
        }

        public async Task DeleteEventAsync(string id)
        {
            await _eventCollection.DeleteOneAsync(e => e.EventId == id);
        }

        public async Task<List<ResultEventDto>> GetAllEventsAsync()
        {
            var events = await _eventCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<ResultEventDto>>(events);
        }

        public async Task<ResultEventDto> GetEventByIdAsync(string id)
        {
            var eventItem = await _eventCollection.Find(e => e.EventId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultEventDto>(eventItem);
        }

        public async Task UpdateEventAsync(UpdateEventDto updateEventDto)
        {
            var eventItem = _mapper.Map<TravelWithMe.Event.Entities.Event>(updateEventDto);
            await _eventCollection.ReplaceOneAsync(e => e.EventId == eventItem.EventId, eventItem);
        }
    }
}
