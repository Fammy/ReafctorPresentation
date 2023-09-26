// Requires C# 8

namespace RefactorPresentation.C_DefaultInterfaceMembers;

public interface IAbstractAnimal
{
    string Name { get; }
    string Speak();
    int Feet { get; }
}

public abstract class Animal : IAbstractAnimal
{
    public abstract string Name { get; }

    public virtual int Feet => 2;

    public string Speak() => $"I am a {Name.ToLower()}";
}

public class Cow : Animal
{
    public override string Name => "Cow";

    [Fact]
    public void AnimalTest()
    {
        var cow = new Cow();
        Assert.Equal("I am a cow", cow.Speak());
    }
}




















public interface IDefaultAnimal
{
    string Name { get; }
    string Speak() => $"I am a {Name.ToLower()}";
    int Feet => 2;
}

public class MooCow : IDefaultAnimal
{
    public string Name => "Moo Cow";
    public int Feet => 4;

    [Fact]
    public void AnimalTest()
    {
        IDefaultAnimal cow = new MooCow();
        //var cow = new MooCow(); // Does not work!

        Assert.Equal("I am a moo cow", cow.Speak());
        Assert.Equal(4, cow.Feet);
    }
}
