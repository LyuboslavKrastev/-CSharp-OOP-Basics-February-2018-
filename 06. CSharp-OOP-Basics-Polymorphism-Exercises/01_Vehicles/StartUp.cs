using System;

namespace _01_Vehicles
{
    class StartUp
    {
        // AN ABSTRACT CLASS WOULD'VE BEEN A BETTER IDEA THAN AN INTERFACE IN THIS SITUATION
        static void Main(string[] args)
        {
            IDrivable car = GetCar();

            IDrivable truck = GetTruck();

            var n = int.Parse(Console.ReadLine());

            ProcessInput(car, truck, n);

            PrintVehicleInfo(car, truck);
        }

        private static IDrivable GetCar()
        {
            var carInput = Console.ReadLine().Split();
            var carFuel = double.Parse(carInput[1]);
            var carLitersPerKilometer = double.Parse(carInput[2]);
            IDrivable car = new Car(carFuel, carLitersPerKilometer);
            return car;
        }

        private static IDrivable GetTruck()
        {
            var truckInput = Console.ReadLine().Split();
            var truckFuel = double.Parse(truckInput[1]);
            var truckLitersPerKilometer = double.Parse(truckInput[2]);
            IDrivable truck = new Truck(truckFuel, truckLitersPerKilometer);
            return truck;
        }

        private static void PrintVehicleInfo(IDrivable car, IDrivable truck)
        {
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ProcessInput(IDrivable car, IDrivable truck, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                var command = input[0];
                var vehicleType = input[1];
                var thirdParameter = double.Parse(input[2]);

                try
                {
                    DriveOrRefuelVehicle(car, truck, input, command, thirdParameter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void DriveOrRefuelVehicle(IDrivable car, IDrivable truck, string[] input, string command, double thirdParameter)
        {
            switch (command)
            {
                case "Drive":
                    if (input[1] == "Car")
                    {
                        car.Drive(thirdParameter);
                    }
                    else if (input[1] == "Truck")
                    {
                        truck.Drive(thirdParameter);
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
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle!");
            }
        }
    }
}
