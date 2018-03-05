using System;
public class Ferrari : ICar
{
    private const string breaksMessage = "Brakes!";
    private const string pedalMessage = "Zadu6avam sA!";

    public string Model => "488-Spider";
    public string Driver { get; private set; }

    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public string PushBrakes()
    {
        return breaksMessage;
    }

    public string PushGasPedal()
    {
        return pedalMessage;
    }

    public override string ToString()
    {
        var result = $"{this.Model}/{this.PushBrakes()}/{this.PushGasPedal()}/{this.Driver}";
        return result;
    }
}

