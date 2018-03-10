
using System;

public class Truck : IDrivable
{

    public double fuelQuantity { get; private set; }

    public double fuelConsumptionPerKilometer { get; private set; }
    private const double ACConsumption = 1.6;
    private const double truckLeak = 0.95;


    public Truck(double fuelQuantity, double fuelConsumption)
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

        PrintTravelledDistance(distance);
        this.fuelQuantity -= fuelNeeded;
    }

    private static void PrintTravelledDistance(double distance)
    {
        Console.WriteLine($"Truck travelled {distance} km");
    }

    public void Refuel(double amountOfFuel)
    {
        this.fuelQuantity += (amountOfFuel * truckLeak);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.fuelQuantity:f2}";
    }
}

