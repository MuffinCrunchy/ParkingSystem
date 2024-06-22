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
                    if (cmdDetails.Length == 2)
                    {
                        Service.CreateParkingLot(parkingLot, int.Parse(cmdDetails[1]));
                    }
                    else
                    {
                        Console.WriteLine("Command Incomplete");
                    }
                    break;
                case "park":
                    if (cmdDetails.Length == 4)
                    {
                        Vehicle vehicle = new Vehicle
                        {
                            LicenseNumber = cmdDetails[1],
                            Colour = cmdDetails[2],
                            Type = cmdDetails[3]
                        };
                        Service.CheckIn(parkingLot, vehicle);
                    }
                    else
                    {
                        Console.WriteLine("Command Incomplete");
                    }
                    break;
                case "leave":
                    if (cmdDetails.Length == 2)
                    {
                        Service.CheckOut(parkingLot, int.Parse(cmdDetails[1]));
                    }
                    else
                    {
                        Console.WriteLine("Command Incomplete");
                    }
                    break;
                case "status":
                    if (cmdDetails.Length == 1)
                    {
                        Service.Status(parkingLot);
                    }
                    else
                    {
                        Console.WriteLine("Command Incomplete");
                    }
                    break;
                case "type_of_vehicles":
                    if (cmdDetails.Length == 2)
                    {
                        Service.CountType(parkingLot, cmdDetails[1]);
                    }
                    else
                    {
                        Console.WriteLine("Command Incomplete");
                    }
                    break;
                case "registration_numbers_for_vehicles_with_odd_plate":
                    if (cmdDetails.Length == 1)
                    {
                        Service.OddPlate(parkingLot);
                    }
                    else
                    {
                        Console.WriteLine("Command Incomplete");
                    }
                    break;
                case "registration_numbers_for_vehicles_with_even_plate":
                    if (cmdDetails.Length == 1)
                    {
                        Service.EvenPlate(parkingLot);
                    }
                    else
                    {
                        Console.WriteLine("Command Incomplete");
                    }
                    break;
                case "registration_numbers_for_vehicles_with_colour":
                    if (cmdDetails.Length == 2)
                    {
                        Service.ColourCollectByLicense(parkingLot, cmdDetails[1]);
                    }
                    else
                    {
                        Console.WriteLine("Command Incomplete");
                    }
                    break;
                case "slot_numbers_for_vehicles_with_colour":
                    if (cmdDetails.Length == 2)
                    {
                        Service.ColourCollectBySlot(parkingLot, cmdDetails[1]);
                    }
                    else
                    {
                        Console.WriteLine("Command Incomplete");
                    }
                    break;
                case "slot_number_for_registration_number":
                    if (cmdDetails.Length == 2)
                    {
                        Service.CheckLicense(parkingLot, cmdDetails[1]);
                    }
                    else
                    {
                        Console.WriteLine("Command Incomplete");
                    }
                    break;
                case "exit":
                    if (cmdDetails.Length == 1)
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Command Incomplete");
                    }
                    break;
                default:
                    Console.WriteLine("Input Invalid");
                    break;
            }

            Console.WriteLine("");
        }
    }
}