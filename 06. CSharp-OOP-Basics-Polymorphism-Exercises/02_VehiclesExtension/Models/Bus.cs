
using System;

public class Bus : IDrivable
{
    public double fuelQuantity { get; private set; }

    public double fuelConsumptionPerKilometer { get; private set; }

    public double tankCapacity { get; private set; }

    public double ACConsumption => 1.4;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        if (fuelQuantity > tankCapacity)
        {
            this.fuelQuantity = 0;
        }
        else
        {
            this.fuelQuantity = fuelQuantity;
        }

        this.fuelConsumptionPerKilometer = fuelConsumption;
        this.tankCapacity = tankCapacity;
    }

    public void Drive(double distance)
    {
        var fuelNeeded = distance * (fuelConsumptionPerKilometer + ACConsumption);
        ValidateFuelQuantity(fuelNeeded);

        PrintTravelledDistance(distance);

        this.fuelQuantity -= fuelNeeded;
    }

    private static void PrintTravelledDistance(double distance)
    {
        Console.WriteLine($"Bus travelled {distance} km");
    }

    private void ValidateFuelQuantity(double fuelNeeded)
    {
        if (fuelQuantity < fuelNeeded)
        {
            throw new InvalidOperationException($"{GetType().Name} needs refueling");
        }
    }

    public void DriveEmpty(double distance)
    {
        var fuelNeeded = distance * fuelConsumptionPerKilometer;
        ValidateFuelQuantity(fuelNeeded);

        PrintTravelledDistance(distance);
        this.fuelQuantity -= fuelNeeded;
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
        return $"Bus: {this.fuelQuantity:f2}";
    }
}


