# PARKING MANAGEMENT SYSTEM

### Installation
Clone repo to local
```bash
clone https://github.com/MuffinCrunchy/ParkingSystem.git
```
You can run with
```csharp
dotnet run
```

### Method
1. Create Parking Lot
    ```csharp
    create_parking_lot [slots]
    ```
    Example:
    ```csharp
    create_parking_lot 6
    ```
2. Check In Vehicle
    ```csharp
    park [license_number] [colour] [type]
    ```
    Example
    ```csharp
    park B-1234-XYZ Putih Mobil
    ```
3. Check Out Vehicle
    ```csharp
    leave [slot]
    ```
    Example:
    ```csharp
    leave 4
    ```
4. Check Parking Lot Status
    ```csharp
    status
    ```
5. Count Type of Vehicles
    ```csharp
    type_of_vehicles [type]
    ```
    Example:
    ```csharp
    type_of_vehicles Motor
    ```
6. Get Vehicles with Odd License Number
    ```csharp
    registration_numbers_for_vehicles_with_odd_plate
    ```
7. Get Vehicles with Even License Number
    ```csharp
    registration_numbers_for_vehicles_with_even_plate
    ```
8. Get Licence Number of Vehicles by Colour
    ```csharp
    registration_numbers_for_vehicles_with_colour [colour]
    ```
    Example:
    ```csharp
    registration_numbers_for_vehicles_with_colour Putih
    ```
9. Get Slot Number of Vehicles by Colour
    ```csharp
    slot_numbers_for_vehicles_with_colour [colour]
    ```
    Example:
    ```csharp
    slot_numbers_for_vehicles_with_colour Putih
    ```
10. Get Slot Number of Vehicle by License Number
    ```csharp
    slot_number_for_registration_number [license_number]
    ```
    Example:
    ```csharp
    slot_number_for_registration_number B-3141-ZZZ
    ```
11. Exit Program
    ```csharp
    exit
    ```

### Example Runtime
```csharp
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