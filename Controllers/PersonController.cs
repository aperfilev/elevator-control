namespace ElevatorControl.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ElevatorControl.ElevatorControlSystem;
    using ElevatorControl.DTOs;

    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        private readonly ElevatorControlSystem _elevatorControlSystem;

        public PersonController(ElevatorControlSystem elevatorControlSystem)
        {
            _elevatorControlSystem = elevatorControlSystem;
        }

        [HttpPost("request_elevator")]
        public IActionResult RequestElevator([FromBody] PersonRequestElevator request)
        {
            // Your logic to handle the request and send elevator to the current floor.
            // _elevatorControlSystem.SendElevatorToFloor(request.PersonId, request.CurrentFloor, request.DestinationFloor);
            return Ok();
        }

        [HttpPost("request_floor")]
        public IActionResult RequestFloor([FromBody] PersonRequestFloor request)
        {
            // Your logic to handle the request and bring the person to the requested floor.
            // _elevatorControlSystem.BringPersonToFloor(request.ElevatorId, request.DestinationFloor);
            return Ok();
        }
    }
}
