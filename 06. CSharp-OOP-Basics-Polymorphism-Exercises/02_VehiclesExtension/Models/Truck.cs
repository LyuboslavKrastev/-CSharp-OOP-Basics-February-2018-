
using System;

public class Truck : IDrivable
{

    public double fuelQuantity { get; private set; }

    public double fuelConsumptionPerKilometer { get; private set; }

    public double tankCapacity { get; private set; }

    public double ACConsumption => 1.6;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        if (fuelQuantity > tankCapacity)
        {
            this.fuelQuantity = 0;
        }
        else
        {
            this.fuelQuantity = fuelQuantity;
        }
        this.fuelConsumptionPerKilometer = fuelConsumption + ACConsumption;
        this.tankCapacity = tankCapacity;
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
        Console.WriteLine($"Truck travelled {distance} km");
    }

    public void Refuel(double amountOfFuel)
    {
        if (amountOfFuel <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        var availableSpace = this.tankCapacity - this.fuelQuantity;
        CheckTankSpace(amountOfFuel, availableSpace);

        this.fuelQuantity += (amountOfFuel * 0.95);
    }

    public override string ToString()
    {
        return $"Truck: {this.fuelQuantity:f2}";
    }

    public void CheckTankSpace(double amountOfFuel, double availableSpace)
    {
        if (availableSpace < amountOfFuel)
        {
            throw new InvalidOperationException($"Cannot fit {amountOfFuel} fuel in the tank");
        }
    }
}

