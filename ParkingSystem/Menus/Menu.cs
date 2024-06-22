using ParkingSystem.Models;
using ParkingSystem.Services;

namespace ParkingSystem.Menus;

public class Menu
{
    public void StartMenu()
    {
        ParkingLot parkingLot = new ParkingLot
        {
            Slots = 0,
            Parking = new List<Vehicle?>(),
            IsInitialized = false
        };

        bool exit = false;
        while (!exit)
        {
            string cmdUser = Console.ReadLine();
            string[] cmdDetails = cmdUser.Split(' ');

            switch (cmdDetails[0])
            {
                case "create_parking_lot" :
                    Service.CreateParkingLot(parkingLot, int.Parse(cmdDetails[1]));
                    break;
                case "park":
                    Vehicle vehicle = new Vehicle
                    {
                        LicenseNumber = cmdDetails[1],
                        Colour = cmdDetails[2],
                        Type = cmdDetails[3]
                    };
                    Service.CheckIn(parkingLot, vehicle);
                    break;
                case "leave":
                    Service.CheckOut(parkingLot, int.Parse(cmdDetails[1]));
                    break;
                case "status":
                    Service.Status(parkingLot);
                    break;
                case "type_of_vehicles":
                    Service.CountType(parkingLot, cmdDetails[1]);
                    break;
                case "registration_numbers_for_vehicles_with_odd_plate":
                    Service.OddPlate(parkingLot);
                    break;
                case "registration_numbers_for_vehicles_with_even_plate":
                    Service.EvenPlate(parkingLot);
                    break;
                case "registration_numbers_for_vehicles_with_colour":
                    Service.ColourCollectByLicense(parkingLot, cmdDetails[1]);
                    break;
                case "slot_numbers_for_vehicles_with_colour":
                    Service.ColourCollectBySlot(parkingLot, cmdDetails[1]);
                    break;
                case "slot_number_for_registration_number":
                    Service.CheckLicense(parkingLot, cmdDetails[1]);
                    break;
                case "exit":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Input Invalid");
                    break;
            }

            Console.WriteLine("");
        }
    }
}