namespace _02_GenericsConstraints;

// Multiple constraints: reference type + implements IIdentifiable + parameterless ctor.
// new() must come last.
public static class MultipleConstraintsDemo<T> where T : class, IIdentifiable, new()
{
    public static T CreateAndDescribe()
    {
        T item = new T();
        Console.WriteLine($"  Created {typeof(T).Name} with Id={item.Id}");
        return item;
    }
}
