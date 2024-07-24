using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelWithMe.Event.Dtos.EventDtos;
using TravelWithMe.Event.Services.EventServices;

namespace TravelWithMe.Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> EventList()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(string id)
        {
            var eventItem = await _eventService.GetEventByIdAsync(id);
            return Ok(eventItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDto createEventDto)
        {
            await _eventService.CreateEventAsync(createEventDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent(UpdateEventDto updateEventDto)
        {
            await _eventService.UpdateEventAsync(updateEventDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(string id)
        {
            await _eventService.DeleteEventAsync(id);
            return Ok();
        }
    }
}
