namespace ParkingSystem.Models;

public class ParkingLot
{
    public int Slots { get; set; }
    public List<Vehicle?> Parking { get; set; }
    public bool IsInitialized { get; set; }
}