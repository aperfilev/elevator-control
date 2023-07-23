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
namespace ElevatorControl;

using Xunit;
using Moq;
using System.Collections.Generic;

public class ElevatorControlSystemTests
{
    [Fact]
    public void SendElevatorToFloor_Should_UpdateElevatorState()
    {
        // Arrange
        var elevatorControlSystem = new ElevatorControlSystem(numberOfElevators: 1);
        var mockElevator = new Mock<Elevator>();
        elevatorControlSystem.Elevators[0] = mockElevator.Object;
        int personCurrentFloor = 1;
        int personDestinationFloor = 5;

        // Act
        elevatorControlSystem.SendElevatorToFloor(elevatorIndex: 0, personCurrentFloor, personDestinationFloor);

        // Assert
        mockElevator.Verify(e => e.RequestFloor(personCurrentFloor, personDestinationFloor), Times.Once);
    }

    [Fact]
    public void BringPersonToFloor_Should_UpdateElevatorState()
    {
        // Arrange
        var elevatorControlSystem = new ElevatorControlSystem(numberOfElevators: 1);
        var mockElevator = new Mock<Elevator>();
        elevatorControlSystem.Elevators[0] = mockElevator.Object;
        int destinationFloor = 3;

        // Act
        elevatorControlSystem.BringPersonToFloor(elevatorIndex: 0, destinationFloor);

        // Assert
        mockElevator.Verify(e => e.BringToFloor(destinationFloor), Times.Once);
    }

    [Fact]
    public void GetServicingFloors_Should_ReturnCorrectListOfFloors()
    {
        // Arrange
        var elevatorControlSystem = new ElevatorControlSystem(numberOfElevators: 1);
        var mockElevator = new Mock<Elevator>();
        mockElevator.SetupGet(e => e.ServicingFloors).Returns(new HashSet<int> { 2, 5, 8 });
        elevatorControlSystem.Elevators[0] = mockElevator.Object;

        // Act
        List<int> servicingFloors = elevatorControlSystem.GetServicingFloors(elevatorIndex: 0);

        // Assert
        Assert.Equal(new List<int> { 2, 5, 8 }, servicingFloors);
    }

    [Fact]
    public void GetNextFloorToService_Should_ReturnCorrectNextFloor()
    {
        // Arrange
        var elevatorControlSystem = new ElevatorControlSystem(numberOfElevators: 1);
        var mockElevator = new Mock<Elevator>();
        mockElevator.Setup(e => e.GetNextFloorToService()).Returns(10);
        elevatorControlSystem.Elevators[0] = mockElevator.Object;

        // Act
        int nextFloor = elevatorControlSystem.GetNextFloorToService(elevatorIndex: 0);

        // Assert
        Assert.Equal(10, nextFloor);
    }
}
