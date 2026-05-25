namespace _02_GenericsConstraints;

// where T : notnull  -> T must be a non-nullable type (reference or value).
public static class NotNullConstraintDemo<T> where T : notnull
{
    public static void RequireNotNull(T value) =>
        Console.WriteLine($"  Received non-null value: {value}");
}
