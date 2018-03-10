
using System;

public class Car : IDrivable
{
    public double fuelQuantity { get; private set; }

    public double fuelConsumptionPerKilometer { get; private set; }

    public double tankCapacity { get; private set; }

    public double ACConsumption => 0.9;

    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
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
        Console.WriteLine($"Car travelled {distance} km");
    }

    public void Refuel(double amountOfFuel)
    {
        if (amountOfFuel <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        var availableSpace = this.tankCapacity - this.fuelQuantity;
        CheckTankSpace(amountOfFuel, availableSpace);

        this.fuelQuantity += amountOfFuel;
    }

    public void CheckTankSpace(double amountOfFuel, double availableSpace)
    {
        if (availableSpace < amountOfFuel)
        {
            throw new InvalidOperationException($"Cannot fit {amountOfFuel} fuel in the tank");
        }
    }

    public override string ToString()
    {
        return $"Car: {this.fuelQuantity:f2}";
    }
}

