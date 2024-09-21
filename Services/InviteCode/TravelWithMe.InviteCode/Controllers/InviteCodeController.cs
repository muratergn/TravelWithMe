using Microsoft.AspNetCore.Mvc;
using TravelWithMe.InviteCode.Dtos;
using TravelWithMe.InviteCode.Services;

namespace TravelWithMe.InviteCode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InviteCodeController : ControllerBase
    {
        private readonly IInviteCodeServices _inviteCodeServices;

        public InviteCodeController(IInviteCodeServices inviteCodeServices)
        {
            _inviteCodeServices = inviteCodeServices;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInviteCode(CreateInviteCodeDto createInviteCodeDto)
        {
            await _inviteCodeServices.CreateInviteCodeAsync(createInviteCodeDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInviteCode(int id)
        {
            await _inviteCodeServices.DeleteInviteCodeAsync(id);
            return NoContent();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllInviteCodes()
        {
            var inviteCodes = await _inviteCodeServices.GetAllCodesAsync();
            return Ok(inviteCodes);
        }

        [HttpGet("get-by-code/{code}")]
        public async Task<IActionResult> GetInviteCodeByCode(string code)
        {
            var inviteCode = await _inviteCodeServices.GetByCodeInviteCodeAsync(code);
            if (inviteCode == null)
            {
                return NotFound();
            }
            return Ok(inviteCode);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateInviteCode(UpdateInviteCodeDto updateInviteCodeDto)
        {
            await _inviteCodeServices.UpdateInviteCodeAsync(updateInviteCodeDto);
            return NoContent();
        }
    }
}
