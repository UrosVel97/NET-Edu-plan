namespace _02_GenericsConstraints;

public class Dog : Animal
{
    public override void Speak() => Console.WriteLine($"{Name} barks!");
}
