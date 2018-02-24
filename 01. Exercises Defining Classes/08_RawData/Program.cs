using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem8.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var carInfo = Console.ReadLine().Split();
                Car car = AssembleCar(carInfo);

                cars.Add(car);
            }

            var command = Console.ReadLine();
            PrintCars(cars, command);
        }

        private static Car AssembleCar(string[] carInfo)
        {
            var car = new Car();

            var model = carInfo[0];

            var engineSpeed = int.Parse(carInfo[1]);
            var enginePower = int.Parse(carInfo[2]);
            var engine = new Engine(engineSpeed, enginePower);

            var cargoWeight = int.Parse(carInfo[3]);
            var cargoType = carInfo[4];
            var cargo = new Cargo(cargoWeight, cargoType);

            car.Model = model;
            car.Engine = engine;
            car.Cargo = cargo;

            var firstTirePressure = double.Parse(carInfo[5]);
            var firstTireAge = double.Parse(carInfo[6]);
            var firstTire = new Tire(firstTirePressure, firstTireAge);
            car.Tires.Add(firstTire);

            var secondTirePressure = double.Parse(carInfo[7]);
            var secondTireAge = double.Parse(carInfo[8]);
            var secondTire = new Tire(secondTirePressure, secondTireAge);
            car.Tires.Add(secondTire);

            var thirdTirePressure = double.Parse(carInfo[9]);
            var thirdTireAge = double.Parse(carInfo[9]);
            var thirdTire = new Tire(thirdTirePressure, thirdTireAge);
            car.Tires.Add(thirdTire);

            var fourthTirePressure = double.Parse(carInfo[11]);
            var fourthTireAge = double.Parse(carInfo[12]);
            var fourthTire = new Tire(fourthTirePressure, fourthTireAge);
            car.Tires.Add(fourthTire);
            return car;
        }

        private static void PrintCars(List<Car> cars, string command)
        {
            if (command == "fragile")
            {
                var carResult = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1));

                foreach (var car in carResult)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                var carResult = cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250);

                foreach (var car in carResult)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
