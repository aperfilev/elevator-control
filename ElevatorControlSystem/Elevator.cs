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

public class Elevator
{
    public int CurrentFloor { get; set; }
    public int DestinationFloor { get; set; }
    public bool IsMovingUp { get; set; }
    public bool IsMovingDown { get; set; }
    public HashSet<int> ServicingFloors { get; set; }

    public Elevator()
    {
        CurrentFloor = 1;
        DestinationFloor = 1;
        IsMovingUp = false;
        IsMovingDown = false;
        ServicingFloors = new HashSet<int>();
    }

    public void RequestFloor(int currentFloor, int destinationFloor)
    {
        ServicingFloors.Add(destinationFloor);
        if (currentFloor < CurrentFloor)
        {
            IsMovingDown = true;
        }
        else if (currentFloor > CurrentFloor)
        {
            IsMovingUp = true;
        }
    }

    public void BringToFloor(int destinationFloor)
    {
        ServicingFloors.Add(destinationFloor);
        if (destinationFloor < CurrentFloor)
        {
            IsMovingDown = true;
        }
        else if (destinationFloor > CurrentFloor)
        {
            IsMovingUp = true;
        }
    }

    public int GetNextFloorToService()
    {
        if (ServicingFloors.Count == 0)
        {
            return CurrentFloor;
        }

        if (IsMovingUp)
        {
            return ServicingFloors.Where(floor => floor > CurrentFloor).Min();
        }
        else if (IsMovingDown)
        {
            return ServicingFloors.Where(floor => floor < CurrentFloor).Max();
        }
        else
        {
            return CurrentFloor;
        }
    }
}
