using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelWithMe.Travel.Application.Features.Mediator.Commands.TravelCommands;
using TravelWithMe.Travel.Application.Features.Mediator.Queries.TravelQueries;


namespace TravelWithMe.Travel.WebApi.Controllers
{
    public class TravelController : Controller
    {
        private readonly IMediator _mediator;

        public TravelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTravelList()
        {
            var result = await _mediator.Send( new GetTravelQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTravelById(string id)
        {
            var result = await _mediator.Send(new GetTravelByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("GetTravelByUserId/{id}")]
        public async Task<IActionResult> GetTravelByUserId(string id)
        {
            var result = await _mediator.Send(new GetTravelByUserIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTravel(CreateTravelCommand command)
        {
            await _mediator.Send(command);
            return Ok("Gezi planı başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTravel(UpdateTravelCommand command)
        {
            await _mediator.Send(command);
            return Ok("Gezi planı başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTravel(string id)
        {
            await _mediator.Send(new RemoveTravelCommand(id));
            return Ok("Gezi planı başarıyla silindi");
        }
    }
}
