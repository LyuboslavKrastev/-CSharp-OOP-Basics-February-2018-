
using System.Collections.Generic;
using System.Linq;

public class Department
{
    private List<Employee> employees = new List<Employee>();
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    public void AddEmployee(Employee employee)
    {
        this.employees.Add(employee);
    }

    public decimal GetAverageSalary()
    {
        var averageSalary = employees.Select(e => e.Salary).Average();
        return averageSalary;
    }

    public void GetEmployees()
    {
        foreach (var employee in employees.OrderByDescending(e => e.Salary))
        {
            System.Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }

}

