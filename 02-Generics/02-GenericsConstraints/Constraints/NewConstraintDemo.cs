namespace _02_GenericsConstraints;

// where T : new()  -> T must have a public parameterless constructor.
// Must be specified last in a list of constraints.
public static class NewConstraintDemo<T> where T : new()
{
    public static T CreateInstance() => new T();
}
