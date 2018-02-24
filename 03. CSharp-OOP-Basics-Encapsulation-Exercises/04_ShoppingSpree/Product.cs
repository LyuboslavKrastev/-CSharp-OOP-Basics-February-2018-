using System;

public class Product
{
    private string name;
    private decimal price;

    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
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
            else
            {
                this.name = value;
            }
        }
    }
    public decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            else
            {
                this.price = value;
            }
        }
    }

    public override string ToString()
    {
        return this.Name;
    }
}
