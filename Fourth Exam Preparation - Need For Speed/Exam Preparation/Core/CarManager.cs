using System;
using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;
    private CarFactory carFactory;
    private RaceFactory raceFactory;


    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
        this.carFactory = new CarFactory();
        this.raceFactory = new RaceFactory();
    }


    public void Register(int id, string type, string brand, string model,
        int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        Car car = carFactory.CreateCar(type, brand, model,
         yearOfProduction, horsepower, acceleration, suspension, durability);

        this.cars.Add(id, car);
    }

    public string Check(int id)
    {
        var result = cars[id].ToString();

        return result;
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        var race = raceFactory.CreateRace(type, length, route, prizePool);

        this.races.Add(id, race);
    }

    public void Participate(int carId, int raceId)
    {
        if (races[raceId].IsClosed == false)
        {
            if (!garage.ParkedCars.Any(c => c == carId))
            {
                this.races[raceId].Participants.Add(carId, cars[carId]);
            }
        }
    }

    public string Start(int id)
    {
        if (!races[id].Participants.Any())
        {
            return "Cannot start the race with zero participants.";
        }

        var result = races[id].StartRace();
        races[id].IsClosed = true;
        return result;
    }

    public void Park(int id)
    {
        foreach (var race in races.Where(r => r.Value.IsClosed == false))
        {
            if (race.Value.Participants.ContainsKey(id))
            {
                return;
            }
        }
        this.garage.ParkCar(id);
    }

    public void Unpark(int id)
    {
        this.garage.UnparkCar(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var carId in garage.ParkedCars)
        {
            cars[carId].Tune(tuneIndex, addOn);

        }
    }
}

