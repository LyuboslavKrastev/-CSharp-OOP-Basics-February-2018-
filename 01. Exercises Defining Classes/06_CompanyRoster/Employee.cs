
public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private Department department;
    private string email = "n/a";
    private int age = -1;

    public int Age
    {
        get { return this.age; }
        set { age = value; }
    }



    public string Email
    {
        get { return email; }
        set { email = value; }
    }


    public Department Department
    {
        get { return department; }
        set { department = value; }
    }


    public string Position
    {
        get { return position; }
        set { position = value; }
    }


    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    public Employee(string name, decimal salary, string position, Department department)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
    }

    public Employee(string name, decimal salary, string position, Department department, string email, int age)
      : this(name, salary, position, department)
    {
        this.Email = email;
        this.Age = age;
    }
}

