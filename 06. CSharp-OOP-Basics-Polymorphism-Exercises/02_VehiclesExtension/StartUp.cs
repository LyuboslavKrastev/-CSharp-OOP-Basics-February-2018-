using System;

namespace _01_Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            // SHOULD HAVE USED AN ABSTRACT CLASS VEHICLE INSTEAD OF AN INTERFACE IN ORDER TO REUSE ALOT OF THE METHODS.
            IDrivable car = null;
            IDrivable truck = null;
            Bus bus = null;

            GetVehicles(ref car, ref truck, ref bus);

            var n = int.Parse(Console.ReadLine());

            ProcessInput(car, truck, bus, n);

            PrintVehicleStatus(car, truck, bus);
        }

        private static void ProcessInput(IDrivable car, IDrivable truck, Bus bus, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                var command = input[0];
                var vehicleType = input[1];
                var thirdParameter = double.Parse(input[2]);

                try
                {
                    DriveOrRefuelVehicle(car, truck, bus, input, command, thirdParameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void PrintVehicleStatus(IDrivable car, IDrivable truck, Bus bus)
        {
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void DriveOrRefuelVehicle(IDrivable car, IDrivable truck, Bus bus, string[] input, string command, double thirdParameter)
        {
            switch (command)
            {
                case "DriveEmpty":
                    bus.DriveEmpty(thirdParameter);
                    break;
                case "Drive":
                    if (input[1] == "Car")
                    {
                        car.Drive(thirdParameter);
                    }
                    else if (input[1] == "Truck")
                    {
                        truck.Drive(thirdParameter);
                    }
                    else if (input[1] == "Bus")
                    {
                        bus.Drive(thirdParameter);
                    }
                    break;

                case "Refuel":
                    if (input[1] == "Car")
                    {
                        car.Refuel(thirdParameter);
                    }
                    else if (input[1] == "Truck")
                    {
                        truck.Refuel(thirdParameter);
                    }
                    else if (input[1] == "Bus")
                    {
                        bus.Refuel(thirdParameter);
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle!");
            }
        }

        private static void GetVehicles(ref IDrivable car, ref IDrivable truck, ref Bus bus)
        {
            for (int i = 0; i < 3; i++)
            {
                IDrivable currentVehicle = null;
                var vehicleInput = Console.ReadLine().Split();

                currentVehicle = GetVehicle(vehicleInput);
                if (currentVehicle is Car)
                {
                    car = currentVehicle;
                }
                else if (currentVehicle is Truck)
                {
                    truck = currentVehicle;
                }
                else if (currentVehicle is Bus)
                {
                    bus = (Bus)currentVehicle;
                }
            }
        }

        private static IDrivable GetVehicle(string[] vehicleInput)
        {
            var vehicleType = vehicleInput[0];
            var vehicleFuel = double.Parse(vehicleInput[1]);
            var vehicleLittersPerKilometer = double.Parse(vehicleInput[2]);
            var vehicleTankCapacity = double.Parse(vehicleInput[3]);

            switch (vehicleType)
            {
                case "Car":
                    return new Car(vehicleFuel, vehicleLittersPerKilometer, vehicleTankCapacity);
                case "Truck":
                    return new Truck(vehicleFuel, vehicleLittersPerKilometer, vehicleTankCapacity);
                case "Bus":
                    return new Bus(vehicleFuel, vehicleLittersPerKilometer, vehicleTankCapacity);

                default:
                    throw new ArgumentException("Invalid vehicle type!");
            }
        }
    }
}
