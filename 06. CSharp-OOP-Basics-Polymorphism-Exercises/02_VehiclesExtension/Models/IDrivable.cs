
public interface IDrivable
{
    double fuelQuantity { get; }
    double fuelConsumptionPerKilometer { get; }
    double tankCapacity { get; } 
    double ACConsumption { get; }

    void Drive(double distance);
    void Refuel(double amountOfFuel);
    void CheckTankSpace(double amountOfFuel, double availableSpace);
}

