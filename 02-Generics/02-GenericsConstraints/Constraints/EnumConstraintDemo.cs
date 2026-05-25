namespace _02_GenericsConstraints;

// where T : Enum  -> T must be an enum type.
public static class EnumConstraintDemo<T> where T : Enum
{
    public static IEnumerable<T> GetValues() => (T[])Enum.GetValues(typeof(T));
}
