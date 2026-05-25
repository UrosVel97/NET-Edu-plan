namespace _02_GenericsConstraints;

// where T : Delegate  -> T must be a delegate type.
public static class DelegateConstraintDemo<T> where T : Delegate
{
    public static T Combine(T a, T b) => (T)Delegate.Combine(a, b)!;
}
