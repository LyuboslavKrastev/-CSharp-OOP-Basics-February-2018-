using System;
using System.Collections.Generic;

namespace _03_WildFarm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                ProcessInput(animals, input);
            }

            PrintAnimals(animals);
        }

        private static void PrintAnimals(IEnumerable<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static void ProcessInput(ICollection<Animal> animals, string input)
        {
            var animalTokens = input.Split();
            var animalType = animalTokens[0];
            Animal animal = null;

            var name = animalTokens[1];
            var weight = double.Parse(animalTokens[2]);
            var thirdVariable = animalTokens[3];

            animal = AnimalFactory(animalTokens, animalType, name, weight, thirdVariable);

            animals.Add(animal);

            var foodTokens = Console.ReadLine().Split();

            var foodType = foodTokens[0];
            var foodQuantity = int.Parse(foodTokens[1]);
            Food food = null;

            food = FoodFactory(foodType, foodQuantity);

            Console.WriteLine(animal.MakeSound());

            FeedAnimal(animal, food);
        }
        private static Animal AnimalFactory(string[] animalTokens, string animalType, string name, double weight, string thirdVariable)
        {
            switch (animalType)
            {
                case "Cat":
                    var catBreed = animalTokens[4];
                    return new Cat(name, weight, thirdVariable, catBreed);

                case "Dog":
                    return new Dog(name, weight, thirdVariable);

                case "Tiger":
                    var tigerBreed = animalTokens[4];
                    return new Tiger(name, weight, thirdVariable, tigerBreed);

                case "Mouse":
                    return new Mouse(name, weight, thirdVariable);

                case "Owl":
                    var owlWingSize = double.Parse(animalTokens[3]);
                    return new Owl(name, weight, owlWingSize);

                case "Hen":
                    var henWingSize = double.Parse(animalTokens[3]);
                    return new Hen(name, weight, henWingSize);
                default:
                    throw new ArgumentException("Invalid Animal Type!");
            }
        }

        private static Food FoodFactory(string foodType, int foodQuantity)
        {
            switch (foodType)
            {
                case "Meat":
                    return new Meat(foodQuantity);

                case "Vegetable":
                    return new Vegetable(foodQuantity);

                case "Fruit":
                    return new Fruit(foodQuantity);

                case "Seeds":
                    return new Seeds(foodQuantity);
                default:
                    throw new ArgumentException("Invalid Food Type!");
            }
        }

        private static void FeedAnimal(Animal animal, Food food)
        {
            try
            {
                animal.TryEatFood(food);

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }      
       
    }
}
