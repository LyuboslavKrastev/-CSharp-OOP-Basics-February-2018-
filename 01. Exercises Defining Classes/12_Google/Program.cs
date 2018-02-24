using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem12.Google
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var people = new HashSet<Person>();
            while ((input = Console.ReadLine()) != "End")
            {
                var personInfo = input.Split();

                var personName = personInfo[0];
                var command = personInfo[1];
                if (!people.Any(p => p.Name == personName))
                {
                    people.Add(new Person(personName));
                }
                var person = people.FirstOrDefault(p => p.Name == personName);
                InterpretCommand(personInfo, command, person);
            }
            var searchFor = Console.ReadLine();
            PrintPersonInfo(people, searchFor);

        }

        private static void InterpretCommand(string[] personInfo, string command, Person person)
        {
            switch (command)
            {
                case "company":
                    person.Company = new Company(personInfo[2], personInfo[3], decimal.Parse(personInfo[4]));
                    break;
                case "pokemon":
                    var pokeName = personInfo[2];
                    var type = personInfo[3];
                    person.Pokemons.Add(new Pokemon(pokeName, type));
                    break;
                case "parents":
                    var name = personInfo[2];
                    var birthday = personInfo[3];
                    person.Parents.Add(new Person(name, birthday));
                    break;
                case "children":
                    var childName = personInfo[2];
                    var childBirthday = personInfo[3];
                    person.Children.Add(new Person(childName, childBirthday));
                    break;
                case "car":
                    var model = personInfo[2];
                    var speed = double.Parse(personInfo[3]);
                    person.Car = new Car(model, speed);
                    break;
            }
        }

        private static void PrintPersonInfo(HashSet<Person> people, string searchFor)
        {
            var found = people.FirstOrDefault(p => p.Name == searchFor);
            Console.WriteLine(found.Name);
            Console.WriteLine("Company:"); found.PrintCompany();
            Console.WriteLine("Car:"); found.PrintCar();
            Console.WriteLine("Pokemon:"); found.PrintPokemons();
            Console.WriteLine("Parents:"); found.PrintParents();
            Console.WriteLine("Children:"); found.PrintChildren();
        }
    }
}
