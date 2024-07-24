using AutoMapper;
using MongoDB.Driver;
using TravelWithMe.Event.Dtos.EventImageDtos;
using TravelWithMe.Event.Settings;
using TravelWithMe.Event.Entities;

namespace TravelWithMe.Event.Services.EventImageServices
{
    public class EventImageService : IEventImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<EventImage> _eventImageCollection;

        public EventImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _eventImageCollection = database.GetCollection<EventImage>(databaseSettings.EventImageCollectionName);
            _mapper = mapper;
        }

        public async Task<List<ResultEventImageDto>> GetAllEventImagesAsync()
        {
            var eventImages = await _eventImageCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<ResultEventImageDto>>(eventImages);
        }

        public async Task<ResultEventImageDto> GetEventImageByIdAsync(string id)
        {
            var eventImage = await _eventImageCollection.Find(e => e.EventImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultEventImageDto>(eventImage);
        }

        public async Task<ResultEventImageDto> GetEventImageByEventIdAsync(string eventId)
        {
            var eventImage = await _eventImageCollection.Find(e => e.EventId == eventId).FirstOrDefaultAsync();
            return _mapper.Map<ResultEventImageDto>(eventImage);
        }

        public async Task CreateEventImageAsync(CreateEventImageDto createEventImageDto)
        {
            var eventImage = _mapper.Map<EventImage>(createEventImageDto);
            await _eventImageCollection.InsertOneAsync(eventImage);
        }

        public async Task UpdateEventImageAsync(UpdateEventImageDto updateEventImageDto)
        {
            var eventImage = _mapper.Map<EventImage>(updateEventImageDto);
            await _eventImageCollection.ReplaceOneAsync(e => e.EventImageId == eventImage.EventImageId, eventImage);
        }

        public async Task DeleteEventImageAsync(string id)
        {
            await _eventImageCollection.DeleteOneAsync(e => e.EventImageId == id);
        }
    }
}
