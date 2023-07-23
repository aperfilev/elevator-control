﻿/*
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

[ApiController]
[Route("api/elevator")]
public class ElevatorController : ControllerBase
{
    private readonly ElevatorControlSystem elevatorControlSystem;

    public ElevatorController(ElevatorControlSystem elevatorControlSystem)
    {
        this.elevatorControlSystem = elevatorControlSystem;
    }

    [HttpGet("request_servicing_floors")]
    public IActionResult RequestServicingFloors([FromQuery] int elevatorId)
    {
        var servicingFloors = elevatorControlSystem.GetServicingFloors(elevatorId);
        return Ok(servicingFloors);
    }

    [HttpGet("request_next_floor")]
    public IActionResult RequestNextFloor([FromQuery] int elevatorId)
    {
        var nextFloor = elevatorControlSystem.GetNextFloorToService(elevatorId);
        return Ok(nextFloor);
    }
}
