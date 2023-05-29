using FactoryPattern;
using FluentAssertions;

namespace FactoryPatternTests;

public class AnimalFactoryTests
{
    [Fact]
    public void Can_create_any_type_of_animal()
    {
        var factory = new AnimalFactory();

        factory.Create<Dog>().Should().BeOfType<Dog>();
        factory.Create<Cat>().Should().BeOfType<Cat>();
        factory.Create<Fish>().Should().BeOfType<Fish>();
        factory.Create< Horse>().Should().BeOfType<Horse>();

        //var action = () => factory.Create<Yeti>(); //this will not compile
        // action.Should().Throw<Exception>();
    }

    // [Fact]
    // public void Can_create_any_type_of_animal()
    // {
    //     var factory = new AnimalFactory();
    //
    //     factory.Create("FactoryPattern.Dog").Should().BeOfType<Dog>();
    //     factory.Create("FactoryPattern.Cat").Should().BeOfType<Cat>();
    //     factory.Create("FactoryPattern.Fish").Should().BeOfType<Fish>();
    //     factory.Create("FactoryPattern.Horse").Should().BeOfType<Horse>();
    //
    //     var action = () => factory.Create("Yeti");
    //
    //     action.Should().Throw<Exception>();
    // }
}