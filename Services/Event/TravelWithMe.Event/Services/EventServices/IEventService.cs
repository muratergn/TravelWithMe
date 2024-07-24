using TravelWithMe.Event.Dtos.EventDtos;

namespace TravelWithMe.Event.Services.EventServices
{
    public interface IEventService
    {
        Task<List<ResultEventDto>> GetAllEventsAsync();
        Task<ResultEventDto> GetEventByIdAsync(string id);
        Task CreateEventAsync(CreateEventDto createEventDto);
        Task UpdateEventAsync(UpdateEventDto updateEventDto);
        Task DeleteEventAsync(string id);
    }
}
