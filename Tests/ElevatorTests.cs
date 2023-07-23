using ElevatorControl.ElevatorControlSystem;
using Xunit;
using Moq;
using System.Collections.Generic;

namespace ElevatorControl.ElevatorControlSystem.Tests
{  
    public class ElevatorTests
    {
        [Fact]
        public void RequestFloor_Should_UpdateElevatorState()
        {
            // Arrange
            var elevator = new Elevator();
            int currentFloor = 3;
            int destinationFloor = 7;

            // Act
            elevator.RequestFloor(currentFloor, destinationFloor);

            // Assert
            Assert.Equal(currentFloor, elevator.CurrentFloor);
            Assert.Equal(destinationFloor, elevator.DestinationFloor);
            Assert.True(elevator.IsMovingUp); // Assuming destination floor is above the current floor
        }

        [Fact]
        public void BringToFloor_Should_UpdateElevatorState()
        {
            // Arrange
            var elevator = new Elevator();
            int destinationFloor = 5;

            // Act
            elevator.BringToFloor(destinationFloor);

            // Assert
            Assert.Equal(destinationFloor, elevator.DestinationFloor);
            Assert.True(elevator.IsMovingUp); // Assuming destination floor is above the current floor
        }

        [Fact]
        public void GetNextFloorToService_Should_ReturnCorrectNextFloor_Up()
        {
            // Arrange
            var elevator = new Elevator();
            int currentFloor = 2;
            int destinationFloor = 8;
            elevator.RequestFloor(currentFloor, destinationFloor);

            // Act
            int nextFloor = elevator.GetNextFloorToService();

            // Assert
            Assert.Equal(currentFloor + 1, nextFloor);
        }

        [Fact]
        public void GetNextFloorToService_Should_ReturnCorrectNextFloor_Down()
        {
            // Arrange
            var elevator = new Elevator();
            int currentFloor = 8;
            int destinationFloor = 2;
            elevator.RequestFloor(currentFloor, destinationFloor);

            // Act
            int nextFloor = elevator.GetNextFloorToService();

            // Assert
            Assert.Equal(currentFloor - 1, nextFloor);
        }

        [Fact]
        public void GetNextFloorToService_Should_ReturnCurrentFloor_WhenNoServicingFloors()
        {
            // Arrange
            var elevator = new Elevator();
            int currentFloor = 4;
            elevator.CurrentFloor = currentFloor;

            // Act
            int nextFloor = elevator.GetNextFloorToService();

            // Assert
            Assert.Equal(currentFloor, nextFloor);
        }

        [Fact]
        public void GetNextFloorToService_Should_ReturnCurrentFloor_WhenAtDestinationFloor()
        {
            // Arrange
            var elevator = new Elevator();
            int currentFloor = 6;
            int destinationFloor = 6;
            elevator.RequestFloor(currentFloor, destinationFloor);

            // Act
            int nextFloor = elevator.GetNextFloorToService();

            // Assert
            Assert.Equal(currentFloor, nextFloor);
        }
    }
}
