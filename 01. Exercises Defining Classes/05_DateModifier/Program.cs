using System;

namespace Problem5.DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            var dateModifier = new DateMod();

            Console.WriteLine(dateModifier.CalculateDays(firstDate, secondDate));
        }
    }
}
