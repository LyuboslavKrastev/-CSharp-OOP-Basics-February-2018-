using System;

namespace _05_MordorsCruelPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            var eatenFoods = Console.ReadLine().Split();
            var gandalf = new Gandalf();

            foreach (var food in eatenFoods)
            {
                gandalf.EatFood(FoodFactory.GetFood(food));
            }

            Console.WriteLine(gandalf);
        }
    }
}
