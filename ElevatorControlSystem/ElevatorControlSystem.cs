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
namespace ElevatorControl.ElevatorControlSystem;

using System;
using System.Collections.Generic;
using System.Linq;

public class ElevatorControlSystem
{
    public List<Elevator> Elevators { get; set; }

    public ElevatorControlSystem(int numberOfElevators)
    {
        Elevators = new List<Elevator>();

        // Create the specified number of elevators
        for (int i = 0; i < numberOfElevators; i++)
        {
            Elevators.Add(new Elevator());
        }
    }

    public void SendElevatorToFloor(int elevatorIndex, int currentFloor, int destinationFloor)
    {
        if (elevatorIndex < 0 || elevatorIndex >= Elevators.Count)
        {
            throw new ArgumentOutOfRangeException("elevatorIndex", "Invalid elevator index");
        }

        Elevators[elevatorIndex].RequestFloor(currentFloor, destinationFloor);
    }

    public void BringPersonToFloor(int elevatorIndex, int destinationFloor)
    {
        if (elevatorIndex < 0 || elevatorIndex >= Elevators.Count)
        {
            throw new ArgumentOutOfRangeException("elevatorIndex", "Invalid elevator index");
        }

        Elevators[elevatorIndex].BringToFloor(destinationFloor);
    }

    public List<int> GetServicingFloors(int elevatorIndex)
    {
        if (elevatorIndex < 0 || elevatorIndex >= Elevators.Count)
        {
            throw new ArgumentOutOfRangeException("elevatorIndex", "Invalid elevator index");
        }

        return Elevators[elevatorIndex].ServicingFloors.ToList();
    }

    public int GetNextFloorToService(int elevatorIndex)
    {
        if (elevatorIndex < 0 || elevatorIndex >= Elevators.Count)
        {
            throw new ArgumentOutOfRangeException("elevatorIndex", "Invalid elevator index");
        }

        return Elevators[elevatorIndex].GetNextFloorToService();
    }
}
