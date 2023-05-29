namespace FactoryPattern;

public class AnimalFactory
{
    public Animal Create<T>() where T : Animal, new() => new T();

    //public Animal Create(string type)
    //{
    //    var actualType = Type.GetType(type);
    //    ;
    //    return (Animal)Activator.CreateInstance(actualType!);
    //}

    //SOLID - SRP, OCP, LSP, ISP, DIP

    //this kind of factory violates OCP (open-closed principle) 
    //public Animal Create(string type) =>
    //    type switch
    //    {
    //        "Dog" => new Dog(),
    //        "Cat" => new Cat(),
    //        "Fish" => new Fish(),
    //        _ => throw new ArgumentOutOfRangeException(nameof(type), "Type not recognized")
    //    };
}

public abstract class Animal
{
    public abstract string MakeNoise();
}

public class Dog : Animal
{
    public override string MakeNoise() => "Hau hau";
}

public class Cat : Animal
{
    public override string MakeNoise() => "Miał miał";
}

public class Fish : Animal
{
    public override string MakeNoise() => string.Empty;
}

public class Horse : Animal
{
    public override string MakeNoise() => "Ihaa ihaa";
}