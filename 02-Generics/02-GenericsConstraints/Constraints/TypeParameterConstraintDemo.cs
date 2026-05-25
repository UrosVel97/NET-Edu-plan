namespace _02_GenericsConstraints;

// where T : U  -> T must be or derive from another type argument U.
public static class TypeParameterConstraintDemo<TBase, TDerived> where TDerived : TBase
{
    public static void AddIfDerived(List<TBase> list, TDerived item)
    {
        list.Add(item);
        Console.WriteLine($"  Added {typeof(TDerived).Name} into List<{typeof(TBase).Name}>");
    }
}
