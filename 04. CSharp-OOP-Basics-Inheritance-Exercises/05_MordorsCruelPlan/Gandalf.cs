
using System;

public class Gandalf
{
    public int Happiness { get; private set; } = 0;
    public string Mood { get; private set; }

    public void EatFood(Food food)
    {
        this.Happiness += food.HappinessPoints;
    }

    public void GetMood()
    {
       this.Mood = MoodFactory.GetMood(this.Happiness);
    }

    public override string ToString()
    {
        this.GetMood();
        return this.Happiness + Environment.NewLine + this.Mood;
    }
}

