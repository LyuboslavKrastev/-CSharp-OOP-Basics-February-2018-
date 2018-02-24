using System;

namespace _03_AnimalFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var chickenName = Console.ReadLine();
                var chickenAge = int.Parse(Console.ReadLine());

                var chicken = new Chicken(chickenName, chickenAge);

                Console.WriteLine(chicken);

            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }
            
        }
    }
}
