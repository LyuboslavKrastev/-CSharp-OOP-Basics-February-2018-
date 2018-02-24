using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp3
{
    static void Main(string[] args)
    {
        string allPeople = Console.ReadLine().Trim();
        string allProducts = Console.ReadLine().Trim();
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        try
        {
            GetPeople(allPeople, people);

            GetProducts(allProducts, products);

            string purchaseInfo;
            while ((purchaseInfo = Console.ReadLine()) != "END")
            {
                string[] purchase = purchaseInfo.Split(' ');
                string personName = purchase[0];
                string productName = purchase[1];

                Person currentPerson;
                Product currentProduct;

                FindPersonAndProduct(people, products, personName, productName, out currentPerson, out currentProduct);

                currentPerson.BuyProduct(currentProduct);
            }

            PrintPeople(people);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            return;
        }

    }

    private static void FindPersonAndProduct(List<Person> people, List<Product> products, string personName, string productName, out Person currentPerson, out Product currentProduct)
    {
        currentPerson = people.Find(p => p.Name == personName);
        currentProduct = products.Find(pr => pr.Name == productName);
    }


    private static void PrintPeople(List<Person> people)
    {
        foreach (var pers in people)
        {
            pers.Print();
        }
    }

    private static void GetProducts(string allProducts, List<Product> products)
    {
        string[] splitAllProducts = allProducts.Split(';').ToArray();
        if (splitAllProducts.Last() == "")
        {
            splitAllProducts = splitAllProducts.Take(splitAllProducts.Length - 1).ToArray();
        }

        for (int i = 0; i < splitAllProducts.Length; i++)
        {
            string[] productInfo = splitAllProducts[i].Split('=');

            Product product = new Product(productInfo[0], decimal.Parse(productInfo[1]));
            products.Add(product);

        }
    }

    private static void GetPeople(string allPeople, List<Person> people)
    {
        string[] splitAllPeople = allPeople.Split(';').Take(allPeople.Length - 1).ToArray();
        for (int i = 0; i < splitAllPeople.Length; i++)
        {
            string[] personInfo = splitAllPeople[i].Split('=');

            Person person = new Person(personInfo[0], decimal.Parse(personInfo[1]));
            people.Add(person);

        }
    }
}
