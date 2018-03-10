public abstract class Feline : Mammal
{

    public Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
    {
        this.Breed = breed;
    }


    protected string Breed { get; set; }

    public override string ToString()
    {
        var baseToString = base.ToString();
        var result = string.Format(baseToString, $"{this.Breed}, ");
        return result;
    }
}