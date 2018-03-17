using System.Text;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsePower;
    private int acceleration;
    private int suspension;
    private int durability;

    protected Car(string brand, string model,
        int yearOfProduction, int horsePower, 
        int acceleration, int suspension, int durability)
    {
        this.brand = brand;
        this.model = model;
        this.yearOfProduction = yearOfProduction;
        this.horsePower = horsePower;
        this.acceleration = acceleration;
        this.suspension = suspension;
        this.durability = durability;
    }

    public int HorsePower
    {
        get { return horsePower; }
        protected set
        {
            this.horsePower = value;
        }
    }
    public string Brand
    {
        get { return this.brand; }
    }
    public string Model
    {
        get { return this.model; }
    }
    public int YearOfProduction
    {
        get { return this.yearOfProduction; }
    }
    public int Acceleration
    {
        get { return acceleration; }
    }
    public int Suspension
    {
        get { return suspension; }
        protected set
        {
            this.suspension = value;
        }
    }

    public int Durability
    {
        get { return durability; }
    }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        this.HorsePower += tuneIndex;
        this.Suspension += tuneIndex * 50 / 100;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.brand} {this.model} {this.yearOfProduction}")
            .AppendLine($"{this.horsePower} HP, 100 m/h in {this.acceleration} s")
            .AppendLine($"{this.suspension} Suspension force, {this.durability} Durability");

        return sb.ToString();
    }
}

