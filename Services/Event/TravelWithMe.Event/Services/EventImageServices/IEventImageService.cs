using TravelWithMe.Event.Dtos.EventImageDtos;

namespace TravelWithMe.Event.Services.EventImageServices
{
    public interface IEventImageService
    {
        Task<List<ResultEventImageDto>> GetAllEventImagesAsync();
        Task<ResultEventImageDto> GetEventImageByIdAsync(string id);
        Task<ResultEventImageDto> GetEventImageByEventIdAsync(string eventId);
        Task CreateEventImageAsync(CreateEventImageDto createEventImageDto);
        Task UpdateEventImageAsync(UpdateEventImageDto updateEventImageDto);
        Task DeleteEventImageAsync(string id);
    }
}
