namespace _02_GenericsConstraints;

// Base class used for the "where T : BaseClass" constraint demo.
public class Animal
{
    public string Name { get; set; } = "Unnamed";
    public virtual void Speak() => Console.WriteLine($"{Name} makes a sound.");
}
