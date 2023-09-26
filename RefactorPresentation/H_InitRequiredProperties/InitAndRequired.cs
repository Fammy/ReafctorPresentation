// Requires C# 9 (init), C# 11 (required)

namespace RefactorPresentation.H_InitOnlySetters;

internal class InitAndRequired
{
    public void MakeEmployee()
    {
        var employee1 = new Employee("Jason", "Famularo", 8508675309)
        {
            Nickname = "Fammy"
        };

        var employee2 = new Employee("Jason", "Famularo");
        employee2.Nickname = "Fammy";
    }

    public EfficientEmployee MakeEfficientEmployee()
    {
        return new EfficientEmployee
        {
            FirstName = "Jason",
            LastName = "Famularo",
            EmployeeId = 8508675309,
            Nickname = "Fammy"
        };
    }
}

// Old Way
internal struct Employee
{
    internal Employee(string firstName, string lastName, long employeeId)
    {
        FirstName = firstName;
        LastName = lastName;
        EmployeeId = employeeId;
    }

    internal Employee(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    internal Employee(string firstName, string lastName, string nickname)
    {
        FirstName = firstName;
        LastName = lastName;
        Nickname = nickname;
    }

    internal Employee(string firstName, string lastName, string nickname, long employeeId)
    {
        FirstName = firstName;
        LastName = lastName;
        Nickname = nickname;
        EmployeeId = employeeId;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string? Nickname { get; set; }
    public long EmployeeId { get; }
}








// New way
internal class EfficientEmployee
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? Nickname { get; set; }
    public required long EmployeeId { get; init; }
}
