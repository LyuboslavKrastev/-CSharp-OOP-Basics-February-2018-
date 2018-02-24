using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];

                Engine engine = GetEngine(parameters);

                Cargo cargo = GetCargo(parameters);

                List<Tire> tires = GetTires(parameters);

                AddCar(cars, model, engine, cargo, tires);
            }

            string command = Console.ReadLine();
            PrintResult(cars, command);
        }

        private static void AddCar(List<Car> cars, string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            cars.Add(new Car(model, engine, cargo, tires));
        }

        private static Cargo GetCargo(string[] parameters)
        {
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            var cargo = new Cargo(cargoWeight, cargoType);
            return cargo;
        }

        private static Engine GetEngine(string[] parameters)
        {
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);

            var engine = new Engine(engineSpeed, enginePower);
            return engine;
        }

        private static void PrintResult(List<Car> cars, string command)
        {
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.cargo.cargoType == "fragile" && x.tires.Any(t => t.tirePressure < 1))
                    .Select(x => x.model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.cargo.cargoType == "flamable" && x.engine.enginePower > 250)
                    .Select(x => x.model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static List<Tire> GetTires(string[] parameters)
        {
            double tire1Pressure = double.Parse(parameters[5]);
            int tire1age = int.Parse(parameters[6]);

            var tire1 = new Tire(tire1Pressure, tire1age);

            double tire2Pressure = double.Parse(parameters[7]);
            int tire2age = int.Parse(parameters[8]);

            var tire2 = new Tire(tire2Pressure, tire2age);

            double tire3Pressure = double.Parse(parameters[9]);
            int tire3age = int.Parse(parameters[10]);

            var tire3 = new Tire(tire3Pressure, tire3age);

            double tire4Pressure = double.Parse(parameters[11]);
            int tire4age = int.Parse(parameters[12]);

            var tire4 = new Tire(tire4Pressure, tire4age);

            var tires = new List<Tire>();
            tires.Add(tire1);
            tires.Add(tire2);
            tires.Add(tire3);
            tires.Add(tire4);
            return tires;
        }
    }
}
