using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem6.CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var departments = new List<Department>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var salary = decimal.Parse(input[1]);
                var position = input[2];
                var department = input[3];
                int age = 0;
                string email = string.Empty;
                var currentDeparment = new Department();
                currentDeparment.Name = department;
                if (!departments.Any(d => d.Name == department))
                {                                       
                    departments.Add(currentDeparment);
                }
               
                var employee = new Employee(name, salary, position, currentDeparment);
                if (input.Length == 5)
                {
                    if (!int.TryParse(input[4], out age))
                    {
                        email = input[4];
                    }
                }
                else if (input.Length == 6)
                {
                    age = int.Parse(input[5]);
                    email = input[4];
                }

                if (age != 0)
                {
                    employee.Age = age;
                }
                if (email != string.Empty)
                {
                    employee.Email = email;
                }

                departments.Where(d => d.Name == department).First().AddEmployee(employee);
            }

            var highestDept = departments.OrderByDescending(d => d.GetAverageSalary()).FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {highestDept.Name}");

            highestDept.GetEmployees();
        }
    }
}
