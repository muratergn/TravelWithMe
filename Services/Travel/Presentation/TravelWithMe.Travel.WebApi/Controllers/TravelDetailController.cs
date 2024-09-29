using Microsoft.AspNetCore.Mvc;
using TravelWithMe.Travel.Application.Features.CQRS.Commands.TravelDetailCommands;
using TravelWithMe.Travel.Application.Features.CQRS.Handlers.TravelDetailHandlers;
using TravelWithMe.Travel.Application.Features.CQRS.Queries.TravelDetailQueries;

namespace TravelWithMe.Travel.WebApi.Controllers
{
    public class TravelDetailController : Controller
    {
        private readonly CreateTravelDetailCommandHandler _createTravelDetailCommandHandler;
        private readonly GetTravelDetailByIdQueryHandler _getTravelDetailByIdQueryHandler;
        private readonly GetTravelDetailQueryHandler _getTravelDetailsQueryHandler;
        private readonly UpdateTravelDetailCommandHandler _updateTravelDetailCommandHandler;
        private readonly RemoveTravelDetailCommandHandler _removeTravelDetailCommandHandler;

        public TravelDetailController(CreateTravelDetailCommandHandler createTravelDetailCommandHandler, GetTravelDetailByIdQueryHandler getTravelDetailByIdQueryHandler, GetTravelDetailQueryHandler getTravelDetailsQueryHandler, UpdateTravelDetailCommandHandler updateTravelDetailCommandHandler, RemoveTravelDetailCommandHandler removeTravelDetailCommandHandler)
        {
            _createTravelDetailCommandHandler = createTravelDetailCommandHandler;
            _getTravelDetailByIdQueryHandler = getTravelDetailByIdQueryHandler;
            _getTravelDetailsQueryHandler = getTravelDetailsQueryHandler;
            _updateTravelDetailCommandHandler = updateTravelDetailCommandHandler;
            _removeTravelDetailCommandHandler = removeTravelDetailCommandHandler;
        }

        [HttpGet]
        public IActionResult GetTravelDetailList()
        {
            var result = _getTravelDetailsQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetTravelDetailById(string id)
        {
            var result = _getTravelDetailByIdQueryHandler.Handle(new GetTravelDetailByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTravelDetail([FromBody] CreateTravelDetailCommand command)
        {
            _createTravelDetailCommandHandler.Handle(command);
            return Ok("Gezi detayı başarılı eklendi");
        }

        [HttpPut]
        public IActionResult UpdateTravelDetail([FromBody] UpdateTravelDetailCommand command)
        {
            _updateTravelDetailCommandHandler.Handle(command);
            return Ok("Gezi detayı başarılı güncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveTravelDetail([FromBody] RemoveTravelDetailCommand command)
        {
            _removeTravelDetailCommandHandler.Handle(command);
            return Ok("Gezi detayı başarılı silindi");
        }
    }
}
