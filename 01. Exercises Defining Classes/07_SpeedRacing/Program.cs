using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem7.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var cars = new HashSet<Car>();
            AddCars(numberOfCars, cars);

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                DriveCars(cars, input);
            }

            PrintCars(cars);
        }

        private static void AddCars(int numberOfCars, HashSet<Car> cars)
        {
            for (int i = 0; i < numberOfCars; i++)
            {
                var carInput = Console.ReadLine().Split();

                var model = carInput[0];
                var fuelAmount = double.Parse(carInput[1]);
                var fuelPerKilometer = double.Parse(carInput[2]);

                cars.Add(new Car(model, fuelAmount, fuelPerKilometer));
            }
        }

        private static void PrintCars(HashSet<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void DriveCars(HashSet<Car> cars, string input)
        {
            var tokens = input.Split();
            var model = tokens[1];
            var amountOfKilometers = double.Parse(tokens[2]);

            var currentCar = cars.FirstOrDefault(c => c.Model == model);

            if (currentCar.CanMove(amountOfKilometers))
            {
                currentCar.FuelAmount -= amountOfKilometers * currentCar.FuelPerKilometer;
                currentCar.DistanceTravelled += amountOfKilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
