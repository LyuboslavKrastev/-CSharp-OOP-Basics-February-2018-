using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bagOfProducts = new List<Product>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value == string.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }

    public decimal Money
    {
        get
        {
            return this.money;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

                this.money = value;
            
        }
    }
    public List<Product> BagOfProducts
    {
        get
        {
            return this.bagOfProducts;
        }
        set
        {
            this.bagOfProducts = value;
        }
    }

    public void Print()
    {

        if (this.BagOfProducts.Count != 0)
        {
            Console.WriteLine($"{this.Name} - {string.Join(", ", bagOfProducts)}");
        }
        else
        {
            Console.WriteLine($"{this.Name} - Nothing bought");
        }
    }

    public void BuyProduct(Product currentProduct)
    {
        if (this.Money < currentProduct.Price)
        {
            Console.WriteLine($"{this.Name} can't afford {currentProduct.Name}");
        }
        else
        {
            this.Money -= currentProduct.Price;

            this.BagOfProducts.Add(currentProduct);

            Console.WriteLine($"{this.Name} bought {currentProduct.Name}");
        }
    }
}