using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelWithMe.Event.Dtos.EventImageDtos;
using TravelWithMe.Event.Services.EventImageServices;

namespace TravelWithMe.Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventImagesController : ControllerBase
    {
        private readonly IEventImageService _eventImageService;

        public EventImagesController(IEventImageService eventImageService)
        {
            _eventImageService = eventImageService;
        }

        [HttpGet]
        public async Task<IActionResult> EventImageList()
        {
            var eventImages = await _eventImageService.GetAllEventImagesAsync();
            return Ok(eventImages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventImageById(string id)
        {
            var eventImage = await _eventImageService.GetEventImageByIdAsync(id);
            return Ok(eventImage);
        }

        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetEventImageByEventId(string eventId)
        {
            var eventImage = await _eventImageService.GetEventImageByEventIdAsync(eventId);
            return Ok(eventImage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEventImage(CreateEventImageDto createEventImageDto)
        {
            await _eventImageService.CreateEventImageAsync(createEventImageDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEventImage(UpdateEventImageDto updateEventImageDto)
        {
            await _eventImageService.UpdateEventImageAsync(updateEventImageDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventImage(string id)
        {
            await _eventImageService.DeleteEventImageAsync(id);
            return Ok();
        }
    }
}
