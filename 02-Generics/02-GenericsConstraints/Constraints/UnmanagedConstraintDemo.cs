namespace _02_GenericsConstraints;

// where T : unmanaged  -> T must be a non-nullable unmanaged type.
public static class UnmanagedConstraintDemo<T> where T : unmanaged
{
    public static int SizeOf()
    {
        unsafe
        {
            return sizeof(T);
        }
    }
}
