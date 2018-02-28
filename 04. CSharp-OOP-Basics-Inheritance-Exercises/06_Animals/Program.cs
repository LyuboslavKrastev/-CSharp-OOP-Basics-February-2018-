using System;
using System.Text;

namespace _06_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            string animalType;
            var animals = new StringBuilder();

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                ProcessInput(animalType, animals);
            }

            PrintAnimals(animals);
        }

        private static void PrintAnimals(StringBuilder animals)
        {
            Console.WriteLine(animals.ToString().Trim());
        }

        private static void ProcessInput(string animalType, StringBuilder animals)
        {
            var tokens = Console.ReadLine().Split();
            var name = tokens[0];
            var age = int.Parse(tokens[1]);
            string gender = null;

            gender = GetGender(tokens, gender);

            AddAnimals(animalType, animals, name, age, gender);
        }

        private static string GetGender(string[] tokens, string gender)
        {
            if (tokens.Length == 3)
            {
                gender = tokens[2];
            }

            return gender;
        }

        private static void AddAnimals(string animalType, StringBuilder animals, string name, int age, string gender)
        {
            try
            {
                GetAnimal(animalType, animals, name, age, gender);
            }
            catch (ArgumentException ae)
            {

                animals.AppendLine(ae.Message);
            }
        }

        private static void GetAnimal(string animalType, StringBuilder animals, string name, int age, string gender) // COULD HAVE USED FACTORY PATTERN
        {
            switch (animalType)
            {
                case "Cat":
                    var cat = new Cat(name, age, gender);
                    animals.AppendLine(cat.ToString());
                    break;
                case "Dog":
                    var dog = new Dog(name, age, gender);
                    animals.AppendLine(dog.ToString());
                    break;
                case "Frog":
                    var frog = new Frog(name, age, gender);
                    animals.AppendLine(frog.ToString());
                    break;
                case "Kitten":
                    var kitten = new Kitten(name, age);
                    animals.AppendLine(kitten.ToString());
                    break;
                case "Tomcat":
                    var tomcat = new Tomcat(name, age);
                    animals.AppendLine(tomcat.ToString());
                    break;
                default:
                    animals.AppendLine("Invalid input!");
                    break;
            }
        }
    }
}
