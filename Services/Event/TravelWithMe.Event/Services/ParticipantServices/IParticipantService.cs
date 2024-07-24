using TravelWithMe.Event.Dtos.ParticipantDtos;

namespace TravelWithMe.Event.Services.ParticipantServices
{
    public interface IParticipantService
    {
        Task<List<ResultParticipantDto>> GetAllParticipantsAsync();
        Task<ResultParticipantDto> GetParticipantByIdAsync(string id);
        Task<List<ResultParticipantDto>> GetParticipantsByEventIdAsync(string eventId);
        Task<List<ResultParticipantDto>> GetParticipantsByUserIdAsync(string userId);
        Task CreateParticipantAsync(CreateParticipantDto createParticipantDto);
        Task UpdateParticipantAsync(UpdateParticipantDto updateParticipantDto);
        Task DeleteParticipantAsync(string id);
    }
}
