/*
 * Copyright 2023 Alexander Perfilyev
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace ElevatorControl.Controllers;

using Microsoft.AspNetCore.Mvc;
using ElevatorControl.ElevatorControlSystem;
using ElevatorControl.DTOs;

[ApiController]
[Route("api/person")]
public class PersonController : ControllerBase
{
    private readonly ElevatorControlSystem elevatorControlSystem;

    public PersonController(ElevatorControlSystem elevatorControlSystem)
    {
        this.elevatorControlSystem = elevatorControlSystem;
    }

    [HttpPost("request_elevator")]
    public IActionResult RequestElevator([FromBody] PersonRequestElevator request)
    {
        elevatorControlSystem.SendElevatorToFloor(request.PersonId, request.CurrentFloor, request.DestinationFloor);
        return Ok();
    }

    [HttpPost("request_floor")]
    public IActionResult RequestFloor([FromBody] PersonRequestFloor request)
    {
        elevatorControlSystem.BringPersonToFloor(request.ElevatorId, request.DestinationFloor);
        return Ok();
    }
}
