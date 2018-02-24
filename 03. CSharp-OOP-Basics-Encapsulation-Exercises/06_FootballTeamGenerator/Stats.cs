
using System;

public class Stats
    {
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    public int Shooting
    {
        get { return shooting; }
        set
        {
            if (!IsValidStat(value))
            {
                ThrowStatException("Shooting");
            }
            shooting = value;
        }
    }


    public int Passing
    {
        get { return passing; }
        set
        {
            if (!IsValidStat(value))
            {
                ThrowStatException("Passing");
            }
            passing = value;
        }
    }

    public int Dribble
    {
        get { return dribble; }

        set
        {
            if (!IsValidStat(value))
            {
                ThrowStatException("Dribble");

            }
            dribble = value;
        }
    }

    private void ThrowStatException(string stat)
    {
        throw new ArgumentException($"{stat} should be between 0 and 100.");
    }

    public int Sprint
    {
        get { return sprint; }
        set
        {
            if (!IsValidStat(value))
            {
                ThrowStatException("Sprint");
            }
            sprint = value;
        }
    }


    public int Endurance
    {
        get { return endurance; }
        set
        {
            if (!IsValidStat(value))
            {
                ThrowStatException("Endurance");
            }
            endurance = value;
        }
    }


    private bool IsValidStat(int stat)
    {
        return stat >= 0 && stat <= 100;
    }
}

