
public interface IDrivable
{
    double fuelQuantity { get; }
    double fuelConsumptionPerKilometer { get; }

    void Drive(double distance);
    void Refuel(double amountOfFuel);
}

