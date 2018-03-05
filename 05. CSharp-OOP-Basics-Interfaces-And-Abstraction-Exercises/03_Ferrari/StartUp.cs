using System;

namespace _03_Ferrari
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var driver = Console.ReadLine();

            var ferrari = new Ferrari(driver);

            Console.WriteLine(ferrari);
        }
    }
}
