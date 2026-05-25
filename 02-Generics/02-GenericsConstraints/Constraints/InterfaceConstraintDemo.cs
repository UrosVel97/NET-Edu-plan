namespace _02_GenericsConstraints;

// where T : <interface name>  -> T must implement the interface.
public static class InterfaceConstraintDemo<T> where T : IIdentifiable
{
    public static void PrintId(T item) => Console.WriteLine($"  Id is: {item.Id}");
}
