using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var familyTree = new List<Person>();
            string personInput = Console.ReadLine();

            Person mainPerson = Person.CreatePerson(personInput);
            familyTree.Add(mainPerson);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                ParseInput(familyTree, command);
            }

            PrintParents(mainPerson);
            PrintChildren(mainPerson);
        }

        private static void PrintChildren(Person mainPerson)
        {
            Console.WriteLine("Children:");
            foreach (var c in mainPerson.Children)
            {
                Console.WriteLine(c);
            }
        }

        private static void PrintParents(Person mainPerson)
        {
            Console.WriteLine(mainPerson);
            Console.WriteLine("Parents:");
            foreach (var p in mainPerson.Parents)
            {
                Console.WriteLine(p);
            }
        }

        private static void ParseInput(List<Person> familyTree, string command)
        {
            string[] tokens = command.Split(" - ");
            if (tokens.Length > 1)
            {
                CreateParentChildRelation(familyTree, tokens);
            }
            else
            {
                tokens = tokens[0].Split();
                string name = $"{tokens[0]} {tokens[1]}";
                string birthday = tokens[2];

                SetPersonalInfo(familyTree, name, birthday);
            }
        }

        private static void SetPersonalInfo(List<Person> familyTree, string name, string birthday)
        {
            var person = familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

            if (person == null)
            {
                person = new Person();
                familyTree.Add(person);
            }

            person.Name = name;
            person.Birthday = birthday;

            CheckForDuplicates(familyTree, name, birthday, person);
        }

        private static void CheckForDuplicates(List<Person> familyTree, string name, string birthday, Person person)
        {
            Person duplicatePerson = familyTree.Where(p => p.Name == name || p.Birthday == birthday).Skip(1)
                                    .FirstOrDefault();

            TakeCareOfDuplicates(familyTree, person, duplicatePerson);
        }

        private static void TakeCareOfDuplicates(List<Person> familyTree, Person person, Person duplicatePerson)
        {
            if (duplicatePerson != null)
            {
                familyTree.Remove(duplicatePerson);

                person.Parents.AddRange(duplicatePerson.Parents);

                foreach (var parent in duplicatePerson.Parents)
                {
                    ReplaceDuplicate(person, duplicatePerson, parent.Children);
                }

                person.Children.AddRange(duplicatePerson.Children);

                foreach (var child in duplicatePerson.Children)
                {
                    ReplaceDuplicate(person, duplicatePerson, child.Parents);
                }
            }
        }

        private static void CreateParentChildRelation(List<Person> familyTree, string[] tokens)
        {
            string parentInput = tokens[0];
            string childInput = tokens[1];

            Person currentPerson = familyTree.FirstOrDefault(p => p.Birthday == parentInput || p.Name == parentInput);

            if (currentPerson == null)
            {
                currentPerson = Person.CreatePerson(parentInput);

                familyTree.Add(currentPerson);

            }

            SetChild(familyTree, currentPerson, childInput);
        }

        private static void ReplaceDuplicate(Person person, Person duplicatePerson, List<Person> people)
        {
            var copyPersonIndex = people.IndexOf(duplicatePerson);
            if (copyPersonIndex > -1)
            {
                people[copyPersonIndex] = person;
            }
            else
            {
                people.Add(person);
            }
        }

        private static void SetChild(List<Person> familyTree, Person parent, string childInput)
        {
            var child = familyTree.FirstOrDefault(c => c.Name == childInput ||
            c.Birthday == childInput);

            if (child == null)
            {
                child = Person.CreatePerson(childInput);
                familyTree.Add(child);
            }


            parent.Children.Add(child);
            child.Parents.Add(parent);
        }
    }
}
