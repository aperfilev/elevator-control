namespace ElevatorControl.ElevatorControlSystem
{
    public class Elevator
    {
        public int CurrentFloor { get; private set; }
        public int DestinationFloor { get; private set; }
        public bool IsMovingUp { get; private set; }
        public bool IsMovingDown { get; private set; }
        public HashSet<int> ServicingFloors { get; private set; }

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
}
