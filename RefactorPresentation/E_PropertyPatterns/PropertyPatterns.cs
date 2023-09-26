// Requires C# 8, enhanced in C# 9, 10, 11 (list patterns)
using RefactorPresentation.C_DefaultInterfaceMembers;

namespace RefactorPresentation.E_PropertyPatterns;

public class PropertyPatterns
{
    public bool HasFourFeet(IDefaultAnimal animal)
    {
        //return animal.Feet == 4;
        return animal is { Feet: 4 };
    }

    public bool HasTwoOrFourFeet(IDefaultAnimal animal)
    {
        //return animal.Feet == 2 || animal.Feet == 4;
        return animal is { Feet: 2 or 4 };
    }

    public bool HasTwoToEightFeet(IDefaultAnimal animal)
    {
        // return animal.Feet >= 2 and animal.Feet <= 8;
        return animal is { Feet: >= 2 and <= 8 };
    }

    public bool IsFourLeggedCow(IDefaultAnimal animal)
    {
        return animal is { Feet: 4, Name: "cow" or "moo cow" };
    }

    public bool IsFourLeggedMooCow(IDefaultAnimal animal)
    {
        return animal is MooCow and { Feet: 4 };
    }

    public bool StartsWith123(int[] range)
    {
        return range is [1, 2, 3, ..];
    }

    public bool EndsWith8910(int[] range)
    {
        return range is [.., 8, 9, 10];
    }

    [Fact]
    public void EnsureCowHasProperFeet()
    {
        var cow = new MooCow();
        Assert.True(HasFourFeet(cow));
        Assert.True(HasTwoOrFourFeet(cow));
        Assert.True(HasTwoToEightFeet(cow));
    }

    [Fact]
    public void TestRanges()
    {
        var validNumbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var invalidNumbers = new[] { 1, 2, 9, 10 };

        Assert.True(StartsWith123(validNumbers));
        Assert.True(EndsWith8910(validNumbers));
        Assert.False(StartsWith123(invalidNumbers));
        Assert.False(EndsWith8910(invalidNumbers));
    }
}
