//Requires C# 9 (record), C# 10 (record struct)

namespace RefactorPresentation.I_RecordTypes;

public record PersonModel(string FirstName, string LastName);







public record PersonRecord : IPerson
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    // Ignore for now
    public List<string> Data { get; set; }
}

public class PersonClass : IPerson
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    // Ignore for now
    public List<string> Data { get; set; }

    /*public override bool Equals(object? obj)
    {
        return obj is PersonClass p && p.FirstName == FirstName && p.LastName == LastName;
    }*/
}

public struct PersonStruct : IPerson
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}

public record struct PersonRecordStruct : IPerson
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}







public class RecordTests
{
    [Fact]
    public void A_RecordEquality()
    {
        var emp1 = new PersonRecord { FirstName = "F", LastName = "L" };
        var emp2 = new PersonRecord { FirstName = "F", LastName = "L" };

        Assert.Equal(emp1, emp2);
    }

    [Fact]
    public void B_ClassEquality()
    {
        var emp1 = new PersonClass { FirstName = "F", LastName = "L" };
        var emp2 = new PersonClass { FirstName = "F", LastName = "L" };

        // Fails
        Assert.Equal(emp1, emp2);
    }

    [Fact]
    public void C_StructEquality()
    {
        var emp1 = new PersonStruct { FirstName = "F", LastName = "L" };
        var emp2 = new PersonStruct { FirstName = "F", LastName = "L" };

        Assert.Equal(emp1, emp2);
    }

    [Fact]
    public void D_RecordStructEquality()
    {
        var emp1 = new PersonRecordStruct { FirstName = "F", LastName = "L" };
        var emp2 = new PersonRecordStruct { FirstName = "F", LastName = "L" };

        Assert.Equal(emp1, emp2);
    }









    [Fact]
    public void E_ClassMutation()
    {
        var emp = new PersonClass { FirstName = "F", LastName = "L" };
        Mutate(emp);

        // Fails?
        Assert.Equal("F", emp.FirstName);
    }

    [Fact]
    public void F_RecordMutation()
    {
        var emp = new PersonRecord { FirstName = "F", LastName = "L" };
        Mutate(emp);

        // Fails?
        Assert.Equal("F", emp.FirstName);
    }

    [Fact]
    public void G_StructMutation()
    {
        var emp = new PersonStruct { FirstName = "F", LastName = "L" };
        Mutate(emp);
        Assert.Equal("F", emp.FirstName);
    }

    [Fact]
    public void H_RecordStructMutation()
    {
        var emp = new PersonRecordStruct { FirstName = "F", LastName = "L" };
        Mutate(emp);
        Assert.Equal("F", emp.FirstName);
    }

    [Fact]
    public void I_CompareReferenceType()
    {
        var emp1 = new PersonRecord { FirstName = "F", LastName = "L" };
        var emp2 = new PersonRecord { FirstName = "F", LastName = "L" };

        //emp1.Data = new() { "one", "two" };
        //emp2.Data = new() { "one", "two" };

        // Fails?
        Assert.Equal(emp1, emp2);

        //var commonData = new List<string> () { "one", "two" };
        //emp1.Data = commonData;
        //emp2.Data = commonData;

        // How about array?
        //emp1.Data = new[] { "one", "two" };
        //emp2.Data = new[] { "one", "two" };
    }







    private void Mutate(IPerson person)
    {
        person.FirstName = $"Mutated {person.FirstName}";
        person.LastName = $"Mutated {person.LastName}";
    }
}

public interface IPerson
{
    string FirstName { get; set; }
    string LastName { get; set; }
}