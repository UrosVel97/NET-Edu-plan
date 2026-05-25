namespace _02_GenericsConstraints;

// where T : class  -> T must be a reference type.
public static class ClassConstraintDemo<T> where T : class
{
    public static bool IsNull(T value) => value is null;
}
