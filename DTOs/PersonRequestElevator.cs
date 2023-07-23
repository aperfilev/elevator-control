namespace ElevatorControl.DTOs
{
    public class PersonRequestElevator
    {
        public string PersonId { get; set; }
        public int CurrentFloor { get; set; }
        public int DestinationFloor { get; set; }
    }
}
