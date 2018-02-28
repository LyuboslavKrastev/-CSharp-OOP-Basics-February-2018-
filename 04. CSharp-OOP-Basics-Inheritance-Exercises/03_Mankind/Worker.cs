using System;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHours) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workingHours;
    }

    public decimal WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workHoursPerDay = value;
        }
    }


    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        decimal salaryPerHour = this.weekSalary / (this.workHoursPerDay * 5);
        sb.AppendLine($"First Name: {this.FirstName}");
        sb.AppendLine($"Last Name: {this.LastName}");
        sb.AppendLine($"Week Salary: {this.weekSalary:f2}");
        sb.AppendLine($"Hours per day: {this.workHoursPerDay:f2}");
        sb.AppendLine($"Salary per hour: {salaryPerHour:f2}");

        return sb.ToString().Trim();
    }

}

