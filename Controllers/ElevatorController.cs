namespace ElevatorControl.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ElevatorControl.ElevatorControlSystem;

    [ApiController]
    [Route("api/elevator")]
    public class ElevatorController : ControllerBase
    {
        private readonly ElevatorControlSystem _elevatorControlSystem;

        public ElevatorController(ElevatorControlSystem elevatorControlSystem)
        {
            _elevatorControlSystem = elevatorControlSystem;
        }

        [HttpGet("request_servicing_floors")]
        public IActionResult RequestServicingFloors([FromQuery] string elevatorId)
        {
            // Your logic to handle the request and get the list of floors being serviced.
            // var servicingFloors = _elevatorControlSystem.GetServicingFloors(elevatorId);
            // return Ok(servicingFloors);
            return Ok(new List<int> { 5, 8, 12 }); // Sample response
        }

        [HttpGet("request_next_floor")]
        public IActionResult RequestNextFloor([FromQuery] string elevatorId)
        {
            // Your logic to handle the request and get the next floor to service.
            // var nextFloor = _elevatorControlSystem.GetNextFloorToService(elevatorId);
            // return Ok(nextFloor);
            return Ok(10); // Sample response
        }
    }
}
