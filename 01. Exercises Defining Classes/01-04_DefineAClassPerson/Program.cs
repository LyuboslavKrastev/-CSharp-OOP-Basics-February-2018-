using System;

namespace Problem_1._Define_a_Class_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var family = new Family();
            var people = new OpinionPoll();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                people.AddPerson(new Person { Name = input[0], Age = int.Parse(input[1]) });

                //family.AddMember(new Person { Name = input[0], Age = int.Parse(input[1])});
            }
            // Console.WriteLine(family.GetOldestMember());

            Console.WriteLine(people);
        }
    }
}
