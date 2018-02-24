using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelPerKilometer;
    private double distanceTravelled = 0;

    public Car(string model, double fuelAmount, double fuelPerKilometer)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelPerKilometer = fuelPerKilometer;
    }

    public double DistanceTravelled
    {
        get { return distanceTravelled; }
        set { distanceTravelled = value; }
    }


    public double FuelPerKilometer
    {
        get { return fuelPerKilometer; }
        set { fuelPerKilometer = value; }
    }


    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }


    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public bool CanMove(double amountOfKm)
    {
        if (amountOfKm * this.fuelPerKilometer > this.fuelAmount)
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        return $"{this.model} {this.fuelAmount:f2} {this.distanceTravelled}";
    }
}

