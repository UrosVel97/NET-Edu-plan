
// Generic class with a static member that counts how many instances
// of this exact closed type have been created.
// Note: Box<int> and Box<string> each have their OWN InstanceCount,
// because static members on a generic type are per closed type.
public class Box<T>
{
    public static int InstanceCount { get; private set; }

    public T? Value { get; set; }

    public Box(T? value)
    {
        Value = value;
        InstanceCount++;
    }
}
