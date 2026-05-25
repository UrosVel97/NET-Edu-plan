namespace _02_GenericsConstraints;

// where T : struct  -> T must be a non-nullable value type.
public static class StructConstraintDemo<T> where T : struct
{
    public static T? AsNullable(T value) => value;
}
