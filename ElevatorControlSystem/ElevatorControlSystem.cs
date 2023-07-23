namespace ElevatorControl.ElevatorControlSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ElevatorControlSystem
    {
        private List<Elevator> elevators;

        public ElevatorControlSystem(int numberOfElevators)
        {
            elevators = new List<Elevator>();

            // Create the specified number of elevators
            for (int i = 0; i < numberOfElevators; i++)
            {
                elevators.Add(new Elevator());
            }
        }

        public void SendElevatorToFloor(int elevatorIndex, int currentFloor, int destinationFloor)
        {
            if (elevatorIndex < 0 || elevatorIndex >= elevators.Count)
            {
                throw new ArgumentOutOfRangeException("elevatorIndex", "Invalid elevator index");
            }

            elevators[elevatorIndex].RequestFloor(currentFloor, destinationFloor);
        }

        public void BringPersonToFloor(int elevatorIndex, int destinationFloor)
        {
            if (elevatorIndex < 0 || elevatorIndex >= elevators.Count)
            {
                throw new ArgumentOutOfRangeException("elevatorIndex", "Invalid elevator index");
            }

            elevators[elevatorIndex].BringToFloor(destinationFloor);
        }

        public List<int> GetServicingFloors(int elevatorIndex)
        {
            if (elevatorIndex < 0 || elevatorIndex >= elevators.Count)
            {
                throw new ArgumentOutOfRangeException("elevatorIndex", "Invalid elevator index");
            }

            return elevators[elevatorIndex].ServicingFloors.ToList();
        }

        public int GetNextFloorToService(int elevatorIndex)
        {
            if (elevatorIndex < 0 || elevatorIndex >= elevators.Count)
            {
                throw new ArgumentOutOfRangeException("elevatorIndex", "Invalid elevator index");
            }

            return elevators[elevatorIndex].GetNextFloorToService();
        }
    }
}
