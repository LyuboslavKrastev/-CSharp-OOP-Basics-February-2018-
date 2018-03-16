using System;



public class TyreFactory
{
    public Tyre CreateTire(string[] tyreArgs)
    {
        var tyreType = tyreArgs[0];
        var tyreHardness = double.Parse(tyreArgs[1]);

        switch (tyreType)
        {
            case "Hard":
                return new HardTyre(tyreHardness);

            case "Ultrasoft":
                var grip = double.Parse(tyreArgs[2]);
                return new UltrasoftTyre(tyreHardness, grip);

            default:
                throw new ArgumentException(OutputMessages.InvalidTyreType);
        }
    }
}

