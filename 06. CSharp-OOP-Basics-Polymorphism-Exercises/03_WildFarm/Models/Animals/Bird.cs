public abstract class Bird : Animal
{

    public Bird(string name, double weight, double wingSize) : base(name, weight)
    {
        this.WingSize = wingSize;
    }

    protected double WingSize { get; set; }


    public override string ToString()
    {
        var baseToString = base.ToString();
        var result = string.Format(baseToString, $"{this.WingSize}, ", $"{string.Empty} ");
        return result;
    }
}