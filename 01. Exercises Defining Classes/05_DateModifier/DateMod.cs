
using System;

public class DateMod
    {
    private DateTime firstDate;
    private DateTime secondDate;

    public double CalculateDays(string firstDate, string secondDate)
    {
        this.firstDate = Convert.ToDateTime(firstDate);
        this.secondDate = Convert.ToDateTime(secondDate);
        return Math.Abs((this.firstDate - this.secondDate).TotalDays);
    }
    }

