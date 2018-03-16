using System;

public class Car
{
    private double fuelAmount;
    private const double MaxCapacity = 160;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(OutputMessages.OutOfFuel);
            }

            this.fuelAmount = Math.Min(value, MaxCapacity);
        }
    }

    public Tyre Tyre { get; private set; }

    internal void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    internal void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    internal void CompleteLap(int trackLength, double fuelConsumption)
    {
        this.FuelAmount -= trackLength * fuelConsumption;

        this.Tyre.CompleteLap();
    }
}

