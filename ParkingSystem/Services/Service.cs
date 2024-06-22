using ParkingSystem.Models;

namespace ParkingSystem.Services;

public class Service
{
    public static void CreateParkingLot(ParkingLot parkingLot, int slots)
    {
        List<Vehicle?> vehicles = new List<Vehicle?>();
        for (int i = 0; i < slots; i++)
        {
            vehicles.Add(null);
        }

        parkingLot.Slots = slots;
        parkingLot.Parking = vehicles;
        parkingLot.IsInitialized = true;
        Console.WriteLine($"Created a parking lot with {slots} slots");
    }

    public static void CheckIn(ParkingLot parkingLot, Vehicle vehicle)
    {
        if (parkingLot.IsInitialized)
        {
            if (IsFull(parkingLot))
            {
                Console.WriteLine("Sorry, parking lot is full");
            }
            else
            {
                for (int i = 0; i < parkingLot.Slots; i++)
                {
                    if (parkingLot.Parking[i] is null)
                    {
                        parkingLot.Parking[i] = vehicle;
                        Console.WriteLine($"Allocated slot number: {i+1}");
                        break;
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Parking lot isn't initialized yet");
        }
    }

    public static void CheckOut(ParkingLot parkingLot, int slot)
    {
        if (parkingLot.IsInitialized)
        {
            if (slot < 1 || slot > parkingLot.Slots)
            {
                Console.WriteLine($"Slot number invalid");
            }
            else
            {
                if (parkingLot.Parking[slot-1] is null)
                {
                    Console.WriteLine($"Slot number {slot} already free");
                }
                else
                {
                    parkingLot.Parking[slot-1] = null;
                    Console.WriteLine($"Slot number {slot} is free");
                }
            }

        }
        else
        {
            Console.WriteLine("Parking lot isn't initialized yet");
        }
    }

    public static void Status(ParkingLot parkingLot)
    {
        if (parkingLot.IsInitialized)
        {
            if (IsEmpty(parkingLot))
            {
                Console.WriteLine("Parking lot still empty");
            }
            else
            {
                Console.WriteLine("Slot  No.          Type    Registration No. Colour");
                for (int i = 0; i < parkingLot.Slots; i++)
                {
                    if (parkingLot.Parking[i] is not null)
                    {
                        Console.WriteLine($"{i+1}     {parkingLot.Parking[i].LicenseNumber}   {parkingLot.Parking[i].Type}   {parkingLot.Parking[i].Colour}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Parking lot isn't initialized yet");
        }
    }

    public static void CountType(ParkingLot parkingLot, string type)
    {
        if (parkingLot.IsInitialized)
        {
            int count = 0;
            foreach (var vehicle in parkingLot.Parking)
            {
                if (vehicle is not null)
                {
                    if (vehicle.Type == type)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
        else
        {
            Console.WriteLine("Parking lot isn't initialized yet");
        }
    }

    public static void OddPlate(ParkingLot parkingLot)
    {
        if (parkingLot.IsInitialized)
        {
            if (IsEmpty(parkingLot))
            {
                Console.WriteLine("Parking lot still empty");
            }
            else
            {
                List<string> oddPlates = new List<string>();
                foreach (var vehicle in parkingLot.Parking)
                {
                    if (vehicle is not null)
                    {
                        if (int.Parse(vehicle.LicenseNumber.Split('-')[1]) % 2 != 0)
                        {
                            oddPlates.Add(vehicle.LicenseNumber);
                        }
                    }
                }

                Console.WriteLine(oddPlates.Count > 0 ? string.Join(", ", oddPlates) : "Not Found");
            }
        }
        else
        {
            Console.WriteLine("Parking lot isn't initialized yet");
        }
    }

    public static void EvenPlate(ParkingLot parkingLot)
    {
        if (parkingLot.IsInitialized)
        {
            if (IsEmpty(parkingLot))
            {
                Console.WriteLine("Parking lot still empty");
            }
            else
            {
                List<string> evenPlates = new List<string>();
                foreach (var vehicle in parkingLot.Parking)
                {
                    if (vehicle is not null)
                    {
                        if (int.Parse(vehicle.LicenseNumber.Split('-')[1]) % 2 == 0)
                        {
                            evenPlates.Add(vehicle.LicenseNumber);
                        }
                    }
                }

                Console.WriteLine(evenPlates.Count > 0 ? string.Join(", ", evenPlates) : "Not Found");
            }
        }
        else
        {
            Console.WriteLine("Parking lot isn't initialized yet");
        }
    }

    public static void ColourCollectByLicense(ParkingLot parkingLot, string colour)
    {
        if (parkingLot.IsInitialized)
        {
            if (IsEmpty(parkingLot))
            {
                Console.WriteLine("Parking lot still empty");
            }
            else
            {
                List<string> collections = new List<string>();
                foreach (var vehicle in parkingLot.Parking)
                {
                    if (vehicle is not null)
                    {
                        if (vehicle.Colour == colour)
                        {
                            collections.Add(vehicle.LicenseNumber);
                        }
                    }
                }

                Console.WriteLine(collections.Count > 0 ? string.Join(", ", collections) : "Not Found");
            }
        }
        else
        {
            Console.WriteLine("Parking lot isn't initialized yet");
        }
    }

    public static void ColourCollectBySlot(ParkingLot parkingLot, string colour)
    {
        if (parkingLot.IsInitialized)
        {
            if (IsEmpty(parkingLot))
            {
                Console.WriteLine("Parking lot still empty");
            }
            else
            {
                List<int> collections = new List<int>();
                for (int i = 0; i < parkingLot.Slots; i++)
                {
                    if (parkingLot.Parking[i] is not null)
                    {
                        if (parkingLot.Parking[i].Colour == colour)
                        {
                            collections.Add(i+1);
                        }
                    }
                }

                Console.WriteLine(collections.Count > 0 ? string.Join(", ", collections) : "Not Found");
            }
        }
        else
        {
            Console.WriteLine("Parking lot isn't initialized yet");
        }
    }

    public static void CheckLicense(ParkingLot parkingLot, string license)
    {
        bool isFound = false;
        if (parkingLot.IsInitialized)
        {
            for (int i = 0; i < parkingLot.Slots; i++)
            {
                if (parkingLot.Parking[i] is not null)
                {
                    if (parkingLot.Parking[i].LicenseNumber == license)
                    {
                        Console.WriteLine(i+1);
                        isFound = true;
                        break;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Not Found");
            }
        }
        else
        {
            Console.WriteLine("Parking lot isn't initialized yet");
        }
    }

    private static bool IsEmpty(ParkingLot parkingLot)
    {
        bool isEmpty = true;
        foreach (var vehicle in parkingLot.Parking)
        {
            if (vehicle is not null)
            {
                isEmpty = false;
            }
        }

        return isEmpty;
    }

    private static bool IsFull(ParkingLot parkingLot)
    {
        bool isFull = true;
        foreach (var vehicle in parkingLot.Parking)
        {
            if (vehicle is null)
            {
                isFull = false;
                break;
            }
        }

        return isFull;
    }
}