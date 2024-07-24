using TravelWithMe.Event.Dtos.EventDetailDtos;

namespace TravelWithMe.Event.Services.EventDetailService
{
    public interface IEventDetailService
    {
        Task<List<ResultEventDetailDto>> GetAllEventDetailsAsync();
        Task<ResultEventDetailDto> GetEventDetailByIdAsync(string id);
        Task<ResultEventDetailDto> GetEventDetailByEventIdAsync(string eventId);
        Task CreateEventDetailAsync(CreateEventDetailDto createEventDetailDto);
        Task UpdateEventDetailAsync(UpdateEventDetailDto updateEventDetailDto);
        Task DeleteEventDetailAsync(string id);
    }
}
