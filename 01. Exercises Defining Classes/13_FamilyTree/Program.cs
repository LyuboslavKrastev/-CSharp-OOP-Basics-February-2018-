namespace P13.FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var fullFamily = new List<Person>();
            var familyRelations = new List<string>();

            var firstLine = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input.Contains(" - "))
                {
                    familyRelations.Add(input);
                }
                else
                {
                    var inputParams = input.Split();
                    var date = inputParams.Last();
                    var name = inputParams[0] + " " + inputParams[1];

                    fullFamily.Add(new Person(name, date));
                }
            }

            var mainPerson = fullFamily
                .First(p => p.name == firstLine || p.birthDay == firstLine);

            foreach (var relation in familyRelations)
            {
                var kvp = relation.Split(" - ");
                var parentNameOrDate = kvp.First();
                var childNameOrDate = kvp.Last().Trim();

                if (mainPerson.name == parentNameOrDate || mainPerson.birthDay == parentNameOrDate)
                {
                    mainPerson.Children.Add(fullFamily.First(p => p.name == childNameOrDate || p.birthDay == childNameOrDate));
                }
                else if (mainPerson.name == childNameOrDate || mainPerson.birthDay == childNameOrDate)
                {
                    mainPerson.Parents.Add(fullFamily.First(p => p.name == parentNameOrDate || p.birthDay == parentNameOrDate));
                }
            }

            Console.WriteLine(mainPerson);
            Console.WriteLine("Parents:");
            foreach (var parent in mainPerson.Parents)
            {
                Console.WriteLine(parent);
            }
            Console.WriteLine("Children:");
            foreach (var child in mainPerson.Children)
            {
                Console.WriteLine(child);
            }
        }
    }
}