# PARKING MANAGEMENT SYSTEM

## Table of Contents
- [PARKING MANAGEMENT SYSTEM](#parking-management-system)
  - [Table of Contents](#table-of-contents)
  - [Background](#background)
  - [Installation](#installation)
  - [Usage](#usage)
  - [Features](#features)
    - [Check In](#check-in)
    - [Check Out](#check-out)
    - [Report](#report)
  - [Methods](#methods)
  - [Example Output](#example-output)
  - [About The Project](#about-the-project)
    - [Project Structure](#project-structure)
    - [Detail Structure](#detail-structure)
      - [Program](#program)
      - [Model](#model)
      - [Service](#service)
      - [Menu](#menu)

## Background
This is a system to help organize parking lots in managing parked vehicles. In short, this system helps record vehicles entering, staying and leaving the parking lot.

## Installation
```
git clone https://github.com/MuffinCrunchy/ParkingSystem.git
```

## Usage
```
cd ./ParkingSystem
dotnet build
cd ./ParkingSystem
dotnet run
```

## Features
### Check In
1. All vehicles are free to use the available lots
2. The only vehicles permitted to enter are small cars and motorbikes.
3. Every vehicle that enters is recorded based on license number.
4. The calculation of parking fees is per hour, vehicles that have just entered are calculated for 1 hour.

### Check Out
1. Every vehicle that has checked out the lot will be available and can be used by other people.

### Report
1. A report on the number of lots filled is required.
2. A report on the number of lots available is required.
3. A vehicle number report is required based on odd and even license numbers.
4. A report on the number of vehicles based on vehicle's type is required.
5. A report on the number of vehicles based on vehicle's color is required.

## Methods
1. Create Parking Lot
    ```
    create_parking_lot [slots]
    ```
    Example:
    ```
    create_parking_lot 6
    ```
2. Check In Vehicle
    ```
    park [license_number] [colour] [type]
    ```
    Example
    ```
    park B-1234-XYZ Putih Mobil
    ```
3. Check Out Vehicle
    ```
    leave [slot]
    ```
    Example:
    ```
    leave 4
    ```
4. Check Parking Lot Status
    ```
    status
    ```
5. Count Type of Vehicles
    ```
    type_of_vehicles [type]
    ```
    Example:
    ```
    type_of_vehicles Motor
    ```
6. Get Vehicles with Odd License Number
    ```
    registration_numbers_for_vehicles_with_odd_plate
    ```
7. Get Vehicles with Even License Number
    ```
    registration_numbers_for_vehicles_with_even_plate
    ```
8. Get Licence Number of Vehicles by Colour
    ```
    registration_numbers_for_vehicles_with_colour [colour]
    ```
    Example:
    ```
    registration_numbers_for_vehicles_with_colour Putih
    ```
9. Get Slot Number of Vehicles by Colour
    ```
    slot_numbers_for_vehicles_with_colour [colour]
    ```
    Example:
    ```
    slot_numbers_for_vehicles_with_colour Putih
    ```
10. Get Slot Number of Vehicle by License Number
    ```
    slot_number_for_registration_number [license_number]
    ```
    Example:
    ```
    slot_number_for_registration_number B-3141-ZZZ
    ```
11. Exit Program
    ```
    exit
    ```

## Example Output
```
$ create_parking_lot 6
Created a parking lot with 6 slots

$ park B-1234-XYZ Putih Mobil
Allocated slot number: 1

$ park B-9999-XYZ Putih Motor
Allocated slot number: 2

$ park D-0001-HIJ Hitam Mobil
Allocated slot number: 3

$ park B-7777-DEF Red Mobil
Allocated slot number: 4

$ park B-2701-XXX Biru Mobil
Allocated slot number: 5

$ park B-3141-ZZZ Hitam Motor
Allocated slot number: 6

$ leave 4
Slot number 4 is free

$ status
Slot  No.          Type    Registration No. Colour
1     B-1234-XYZ   Mobil   Putih
2     B-9999-XYZ   Motor   Putih
3     D-0001-HIJ   Mobil   Hitam
5     B-2701-XXX   Mobil   Biru
6     B-3141-ZZZ   Motor   Hitam

$ park B-333-SSS Putih Mobil
Allocated slot number: 4

$ park A-1212-GGG Putih Mobil
Sorry, parking lot is full

$ type_of_vehicles Motor
2

$ type_of_vehicles Mobil
4

$ registration_numbers_for_vehicles_with_odd_plate
B-9999-XYZ, D-0001-HIJ, B-333-SSS, B-2701-XXX, B-3141-ZZZ

$ registration_numbers_for_vehicles_with_even_plate 
B-1234-XYZ

$ registration_numbers_for_vehicles_with_colour Putih
B-1234-XYZ, B-9999-XYZ, B-333-SSS

$ slot_numbers_for_vehicles_with_colour Putih
1, 2, 4

$ slot_number_for_registration_number B-3141-ZZZ
6

$ slot_number_for_registration_number Z-1111-AAA
Not Found

$ exit
```

## About The Project
### Project Structure
```
ParkingSystem
├─ Menus
│  ├─ Menu.cs
├─ Models
│  ├─ ParkingLot.cs
│  ├─ Vehicle.cs
├─ Services
│  ├─ Service.cs
├─ ParkingSystem.csproj
├─ Program.cs
.gitignore
ParkingSystem.sln
README.md
```
### Detail Structure
#### Program
This is main class to initiates the system. Create instance of `Menu` and start the system.

#### Model
Contains the main object structure, `ParkingLot` and `Vehicle`. With the following properties,

1. Parking Lot
   - `Slots (integer)`: contains the number of slots owned by a parking lot.
   - `List<Vehicles> (array)`: contains a list of `Vehicle` objects that are currently staying in the parking lot
   - `IsInitialized (boolean)`: to check whether the parking space has been initialized
2. Vehicle
   - `LicenseNumber (string)`: contains the license number of a vehicle
   - `Colour (string)`: contains the colour of a vehicle
   - `Type (string)`: contains the type of a vehicle

#### Service
Contains methods to run the features of the parking system
- `CreateParkingLot (void)`: initializes the parking lot according to the number of slots input.
- `CheckIn (void)`: record incoming vehicles and the lots occupied by those vehicles.
- `CheckOut (void)`: clear the lot of exiting vehicle.
- `Status (void)`: check the lot occupied by vehicles.
- `CountType (void)`: calculates the same vehicle type as the user input
- `OddPlate (void)`: prints license numbers that have odd values
- `EvenPlate (void)`: prints license numbers that have even values
- `ColourCollectByLicense (void)`: prints the license number in the same color as the user input
- `ColourCollectBySlot (void)`: prints the slot number in the same color as the user input
- `CheckLicense (void)`: Look for the slot number that matches the license number entered by the user

#### Menu
Main menu section to receive user input and run methods from `Service`. Using method `StartMenu (void)` to run the menu.
