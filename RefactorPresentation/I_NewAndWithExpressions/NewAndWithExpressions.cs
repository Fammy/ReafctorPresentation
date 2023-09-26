// Requires C# 9

using RefactorPresentation.C_DefaultInterfaceMembers;
using RefactorPresentation.H_InitOnlySetters;

namespace RefactorPresentation.J_NewExpression;

public class NewAndWithExpressions
{
    internal void DoSomething()
    {
        Cow cow = new();

        var mooCow = new MooCow();
    }

    internal EfficientEmployee CreateEmployee()
    {
        return new()
        {
            FirstName = "Jason",
            LastName = "Famularo",
            EmployeeId = 12345
        };
    }

    internal Counter CopyCounter(Counter counter)
    {
        /*return new Counter
        {
            Name = counter.Name,
            Value = counter.Value
        };*/

        return counter with { };
    }

    internal Counter CopyAndResetCounter(Counter counter)
    {
        return counter with { Value = 0 };
    }

    internal record Counter
    {
        public int Value { get; init; } = 0;
        public required string Name { get; init; }
    }

    [Fact]
    public void TestCounterCopy()
    {
        var counter = new Counter { Name = "My Counter", Value = 10 };

        var copy = CopyCounter(counter);

        Assert.Equal("My Counter", copy.Name);
        Assert.Equal(10, copy.Value);
    }

    [Fact]
    public void TestCounterCopyAndReset()
    {
        var counter = new Counter { Name = "My Counter", Value = 10 };

        var copy = CopyAndResetCounter(counter);

        Assert.Equal("My Counter", copy.Name);
        Assert.Equal(0, copy.Value);
    }
}
