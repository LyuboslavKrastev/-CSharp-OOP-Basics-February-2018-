using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem10.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfEngines = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            var cars = new List<Car>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                var engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                GetEngines(engines, engineInfo);
            }

            var numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                var carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                GetCars(engines, cars, carInfo);
            }

            PrintCars(cars);
        }

        private static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void GetCars(List<Engine> engines, List<Car> cars, string[] carInfo)
        {
            var model = carInfo[0];
            var engine = engines.FirstOrDefault(e => e.Model == carInfo[1]);
            var car = new Car(model, engine);

            if (carInfo.Length >= 3)
            {
                var weight = 0;
                if (int.TryParse(carInfo[2], out weight))
                {
                    car.Weight = carInfo[2];
                }
                else
                {
                    car.Color = carInfo[2];
                }
            }
            if (carInfo.Length == 4)
            {
                car.Color = carInfo[3];
            }
            cars.Add(car);
        }

        private static void GetEngines(List<Engine> engines, string[] engineInfo)
        {
            var model = engineInfo[0];
            var power = int.Parse(engineInfo[1]);

            var engine = new Engine(model, power);

            if (engineInfo.Length >= 3)
            {
                var displacement = 0;
                if (int.TryParse(engineInfo[2], out displacement))
                {
                    engine.Displacement = engineInfo[2];
                }
                else
                {
                    engine.Efficiency = engineInfo[2];
                }

            }
            if (engineInfo.Length == 4)
            {
                engine.Efficiency = engineInfo[3];
            }
            engines.Add(engine);
        }
    }
}
