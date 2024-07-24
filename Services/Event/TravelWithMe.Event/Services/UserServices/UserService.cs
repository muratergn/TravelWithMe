using AutoMapper;
using MongoDB.Driver;
using TravelWithMe.Event.Dtos.UserDtos;
using TravelWithMe.Event.Entities;
using TravelWithMe.Event.Settings;

namespace TravelWithMe.Event.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<User> _userCollection;
        private readonly IMongoCollection<Participant> _participantCollection;

        public UserService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _userCollection = database.GetCollection<User>(databaseSettings.UserCollectionName);
            _participantCollection = database.GetCollection<Participant>(databaseSettings.ParticipantCollectionName);
            _mapper = mapper;
        }

        public async Task<List<ResultUserDto>> GetAllUsersAsync()
        {
            var users = await _userCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<ResultUserDto>>(users);
        }

        public async Task<ResultUserDto> GetUserByIdAsync(string id)
        {
            var user = await _userCollection.Find(u => u.UserId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultUserDto>(user);
        }

        public async Task<List<ResultUserDto>> GetUsersByEventIdAsync(string eventId)
        {
            var participants = await _participantCollection.Find(p => p.EventId == eventId).ToListAsync();
            var userIds = participants.Select(p => p.UserId).ToList();
            var users = await _userCollection.Find(u => userIds.Contains(u.UserId)).ToListAsync();
            return _mapper.Map<List<ResultUserDto>>(users);
        }

        public async Task CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            await _userCollection.InsertOneAsync(user);
        }

        public async Task UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var user = _mapper.Map<User>(updateUserDto);
            await _userCollection.ReplaceOneAsync(u => u.UserId == user.UserId, user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userCollection.DeleteOneAsync(u => u.UserId == id);
        }
    }
}
