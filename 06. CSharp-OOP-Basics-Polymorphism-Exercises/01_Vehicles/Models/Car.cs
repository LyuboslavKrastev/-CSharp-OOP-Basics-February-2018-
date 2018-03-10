
using System;

public class Car : IDrivable
{
    public double fuelQuantity { get; private set; }
    private const double ACConsumption = 0.9;

    public double fuelConsumptionPerKilometer { get; private set; }

    public Car(double fuelQuantity, double fuelConsumption)
    {
        this.fuelQuantity = fuelQuantity;
        this.fuelConsumptionPerKilometer = fuelConsumption + ACConsumption;
    }

    public void Drive(double distance)
    {
        var fuelNeeded = distance * fuelConsumptionPerKilometer;
        if (this.fuelQuantity < fuelNeeded)
        {
            throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
        }

        PrintTravelDistance(distance);
        this.fuelQuantity -= fuelNeeded;
    }

    private static void PrintTravelDistance(double distance)
    {
        Console.WriteLine($"Car travelled {distance} km");
    }

    public void Refuel(double amountOfFuel)
    {
        this.fuelQuantity += amountOfFuel;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.fuelQuantity:f2}";
    }
}

