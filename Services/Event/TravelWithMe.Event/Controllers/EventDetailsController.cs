using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelWithMe.Event.Dtos.EventDetailDtos;
using TravelWithMe.Event.Services.EventDetailService;

namespace TravelWithMe.Event.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventDetailsController : ControllerBase
    {
        private readonly IEventDetailService _eventDetailService;

        public EventDetailsController(IEventDetailService eventDetailService)
        {
            _eventDetailService = eventDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> EventDetailList()
        {
            var eventDetails = await _eventDetailService.GetAllEventDetailsAsync();
            return Ok(eventDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventDetailById(string id)
        {
            var eventDetail = await _eventDetailService.GetEventDetailByIdAsync(id);
            return Ok(eventDetail);
        }

        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetEventDetailByEventId(string eventId)
        {
            var eventDetail = await _eventDetailService.GetEventDetailByEventIdAsync(eventId);
            return Ok(eventDetail);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEventDetail(CreateEventDetailDto createEventDetailDto)
        {
            await _eventDetailService.CreateEventDetailAsync(createEventDetailDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEventDetail(UpdateEventDetailDto updateEventDetailDto)
        {
            await _eventDetailService.UpdateEventDetailAsync(updateEventDetailDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventDetail(string id)
        {
            await _eventDetailService.DeleteEventDetailAsync(id);
            return Ok();
        }
    }
}
