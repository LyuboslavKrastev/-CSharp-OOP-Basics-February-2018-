using System;
using System.Text;

namespace _09_CollectionHierarchy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var elementsToAdd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            AddElements(addCollection, addRemoveCollection, myList, elementsToAdd);

            PrintAddedElements(addCollection, addRemoveCollection, myList);

            var numberOfElementsToRemove = int.Parse(Console.ReadLine());

            RemoveElements(addRemoveCollection, myList, numberOfElementsToRemove);

            PrintRemovedElements(addRemoveCollection, myList);
        }

        private static void AddElements(AddCollection addCollection, AddRemoveCollection addRemoveCollection, MyList myList, string[] elementsToAdd)
        {
            foreach (var item in elementsToAdd)
            {
                addCollection.Add(item);

                addRemoveCollection.Add(item);

                myList.Add(item);
            }
        }

        private static void RemoveElements(AddRemoveCollection addRemCollection, MyList myCollection, int numberOfElementsToRemove)
        {
            for (int i = 0; i < numberOfElementsToRemove; i++)
            {
                addRemCollection.Remove();

                myCollection.Remove();
            }
        }

        private static void PrintRemovedElements(AddRemoveCollection addRemoveCollection, MyList myList)
        {
            Console.WriteLine(addRemoveCollection.CollectionRemoved.ToString().TrimEnd());
            Console.WriteLine(myList.CollectionRemoved.ToString().TrimEnd());
        }

        private static void PrintAddedElements(AddCollection addCollection, AddRemoveCollection addRemoveCollection, MyList myList)
        {
            Console.WriteLine(addCollection.CollectionAdded.ToString().TrimEnd());
            Console.WriteLine(addRemoveCollection.CollectionAdded.ToString().TrimEnd());
            Console.WriteLine(myList.CollectionAdded.ToString().TrimEnd());
        }
    }
}
