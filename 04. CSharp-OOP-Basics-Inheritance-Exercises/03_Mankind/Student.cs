
using System;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if ((value.Length >= 5 && value.Length <= 10) && regexItem.IsMatch(value))
            {
                this.facultyNumber = value;
            }
            else
            {
                throw new ArgumentException("Invalid faculty number!");
            }
        }
    }

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}");
        sb.AppendLine($"Last Name: {this.LastName}");
        sb.AppendLine($"Faculty number: {this.FacultyNumber}");
        return sb.ToString();
    }
}
