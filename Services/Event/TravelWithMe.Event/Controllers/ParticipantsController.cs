using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelWithMe.Event.Dtos.ParticipantDtos;
using TravelWithMe.Event.Services.ParticipantServices;

namespace TravelWithMe.Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantsController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet]
        public async Task<IActionResult> ParticipantList()
        {
            var participants = await _participantService.GetAllParticipantsAsync();
            return Ok(participants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantById(string id)
        {
            var participant = await _participantService.GetParticipantByIdAsync(id);
            return Ok(participant);
        }

        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetParticipantsByEventId(string eventId)
        {
            var participants = await _participantService.GetParticipantsByEventIdAsync(eventId);
            return Ok(participants);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetParticipantsByUserId(string userId)
        {
            var participants = await _participantService.GetParticipantsByUserIdAsync(userId);
            return Ok(participants);
        }

        [HttpPost]
        public async Task<IActionResult> CreateParticipant(CreateParticipantDto createParticipantDto)
        {
            await _participantService.CreateParticipantAsync(createParticipantDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateParticipant(UpdateParticipantDto updateParticipantDto)
        {
            await _participantService.UpdateParticipantAsync(updateParticipantDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(string id)
        {
            await _participantService.DeleteParticipantAsync(id);
            return Ok();
        }
    }
}
