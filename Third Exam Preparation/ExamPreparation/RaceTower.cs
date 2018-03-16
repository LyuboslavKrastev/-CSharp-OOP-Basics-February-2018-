using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private Track Track;
    private IList<Driver> racingDrivers;
    private Stack<Driver> failedDrivers;
    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;
    public bool raceIsOver => this.Track.CurrentLap == this.Track.LapsNumber;

    public RaceTower()
    {
        this.racingDrivers = new List<Driver>();
        this.failedDrivers = new Stack<Driver>();
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.Track = new Track(lapsNumber, trackLength);
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var driverType = commandArgs[0];
            var driverName = commandArgs[1];

            var horsePower = int.Parse(commandArgs[2]);
            var fuelAmount = double.Parse(commandArgs[3]);

            var tyreArgs = commandArgs.Skip(4).ToArray();

            var tyre = tyreFactory.CreateTire(tyreArgs);

            var car = new Car(horsePower, fuelAmount, tyre);

            var driver = driverFactory.CreateDriver(driverType, driverName, car);

            this.racingDrivers.Add(driver);
        }
        catch { }
    }

  

    public void DriverBoxes(List<string> commandArgs)
    {
        var boxReson = commandArgs[0];
        var driverName = commandArgs[1];

        var driver = this.racingDrivers.FirstOrDefault(d => d.Name == driverName);
        var methodArgs = commandArgs.Skip(2).ToArray();

        if (boxReson == "Refuel")
        {
            driver.Refuel(methodArgs);
        }
        else if (boxReson == "ChangeTyres")
        {
            Tyre tyre = tyreFactory.CreateTire(methodArgs);
            driver.ChangeTyres(tyre);
        }

    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder builder = new StringBuilder();
        int numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps > this.Track.LapsNumber - this.Track.CurrentLap)
        {
            try
            {
                throw new ArgumentException(string.Format(OutputMessages.InvalidLaps, this.Track.CurrentLap));
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }

        for (int lap = 0; lap < numberOfLaps; lap++)
        {
            for (int index = 0; index < this.racingDrivers.Count; index++)
            {
                Driver driver = racingDrivers[index];

                try
                {
                    driver.CompleteLap(this.Track.TrackLength);
                }
                catch (ArgumentException e)
                {
                    driver.Fail(e.Message);
                    this.failedDrivers.Push(driver);
                    this.racingDrivers.RemoveAt(index);
                    index--;
                }
            }

            this.Track.CurrentLap++;


            List<Driver> orderedDrivers = this.racingDrivers
                .OrderByDescending(d => d.TotalTime)
                .ToList();

            for (int index = 0; index < orderedDrivers.Count - 1; index++)
            {
                Driver overtakingDriver = orderedDrivers[index];
                Driver targetDriver = orderedDrivers[index + 1];

                bool overtakeHappened = this.TryOverTake(overtakingDriver, targetDriver);

                if (overtakeHappened)
                {
                    index++;
                    builder.AppendLine(string.Format
                        (OutputMessages.Overtake, overtakingDriver.Name, targetDriver.Name, this.Track.CurrentLap));
                }
                else
                {
                    if (!overtakingDriver.IsRacing)
                    {
                        this.failedDrivers.Push(overtakingDriver);
                        this.racingDrivers.Remove(overtakingDriver);
                    }
                }
            }
        }

        if (raceIsOver)
        {
            Driver winner = this.racingDrivers.OrderBy(d => d.TotalTime).First();
            builder.AppendLine(
                string.Format(OutputMessages.WinnerMessage, winner.Name, winner.TotalTime));
        }

        string result = builder.ToString().TrimEnd();
        return result;
    }

    private bool TryOverTake(Driver overtakingDriver, Driver targetDriver)
    {
        double timeDiff = overtakingDriver.TotalTime - targetDriver.TotalTime;

        bool aggressiveDriver = overtakingDriver is AggressiveDriver &&
            overtakingDriver.Car.Tyre is UltrasoftTyre;

        bool enduranceDriver = overtakingDriver is EnduranceDriver &&
            overtakingDriver.Car.Tyre is HardTyre;

        bool crash = (aggressiveDriver && this.Track.Weather == Weather.Foggy) ||
            (enduranceDriver && this.Track.Weather == Weather.Rainy);

        if ((aggressiveDriver || enduranceDriver) && timeDiff <= 3)
        {
            if (crash)
            {
                overtakingDriver.Fail(OutputMessages.Crash);
                return false;
            }

            overtakingDriver.TotalTime -= 3;
            targetDriver.TotalTime += 3;
            return true;
        }
        else if (timeDiff <= 2)
        {
            overtakingDriver.TotalTime -= 2;
            targetDriver.TotalTime += 2;
            return true;
        }

        return false;
    }


    public string GetLeaderboard()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Lap {this.Track.CurrentLap}/{this.Track.LapsNumber}");

        IEnumerable<Driver> leaderboardDrivers = this.racingDrivers
            .OrderBy(d => d.TotalTime)
            .Concat(this.failedDrivers);

        int position = 1;

        foreach (Driver driver in leaderboardDrivers)
        {
            builder.AppendLine($"{position} {driver.ToString()}");
            position++;
        }

        string result = builder.ToString().TrimEnd();
        return result;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string weatherType = commandArgs[0];

        bool validWeather = Enum.TryParse(typeof(Weather), weatherType, out object weatherObj);

        if (!validWeather)
        {
            throw new ArgumentException(OutputMessages.InvalidWeatherType);
        }

        Weather weather = (Weather)weatherObj;
        this.Track.Weather = weather;
    }

}

