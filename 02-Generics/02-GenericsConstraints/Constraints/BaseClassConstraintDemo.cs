namespace _02_GenericsConstraints;

// where T : <base class name>  -> T must be or derive from the base class.
public static class BaseClassConstraintDemo<T> where T : Animal
{
    public static void MakeItSpeak(T animal)
    {
        Console.WriteLine($"  About to make '{animal.Name}' speak...");
        animal.Speak();
    }
}
