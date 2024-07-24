using AutoMapper;
using MongoDB.Driver;
using TravelWithMe.Event.Dtos.ParticipantDtos;
using TravelWithMe.Event.Entities;
using TravelWithMe.Event.Settings;

namespace TravelWithMe.Event.Services.ParticipantServices
{
    public class ParticipantService : IParticipantService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Participant> _participantCollection;

        public ParticipantService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _participantCollection = database.GetCollection<Participant>(databaseSettings.ParticipantCollectionName);
            _mapper = mapper;
        }

        public async Task<List<ResultParticipantDto>> GetAllParticipantsAsync()
        {
            var participants = await _participantCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<ResultParticipantDto>>(participants);
        }

        public async Task<ResultParticipantDto> GetParticipantByIdAsync(string id)
        {
            var participant = await _participantCollection.Find(p => p.ParticipantId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultParticipantDto>(participant);
        }

        public async Task<List<ResultParticipantDto>> GetParticipantsByEventIdAsync(string eventId)
        {
            var participants = await _participantCollection.Find(p => p.EventId == eventId).ToListAsync();
            return _mapper.Map<List<ResultParticipantDto>>(participants);
        }

        public async Task<List<ResultParticipantDto>> GetParticipantsByUserIdAsync(string userId)
        {
            var participants = await _participantCollection.Find(p => p.UserId == userId).ToListAsync();
            return _mapper.Map<List<ResultParticipantDto>>(participants);
        }

        public async Task CreateParticipantAsync(CreateParticipantDto createParticipantDto)
        {
            var participant = _mapper.Map<Participant>(createParticipantDto);
            await _participantCollection.InsertOneAsync(participant);
        }

        public async Task UpdateParticipantAsync(UpdateParticipantDto updateParticipantDto)
        {
            var participant = _mapper.Map<Participant>(updateParticipantDto);
            await _participantCollection.ReplaceOneAsync(p => p.ParticipantId == participant.ParticipantId, participant);
        }

        public async Task DeleteParticipantAsync(string id)
        {
            await _participantCollection.DeleteOneAsync(p => p.ParticipantId == id);
        }
    }
}
