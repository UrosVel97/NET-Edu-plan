internal sealed class MemoryReporter
{
    public void Print(string title)
    {
        var memoryInMb = GC.GetTotalMemory(forceFullCollection: false) / 1024d / 1024d;

        Console.WriteLine($"{title}: {memoryInMb:N2} MB");
        Console.WriteLine($"  Gen 0 collections: {GC.CollectionCount(0)}");
        Console.WriteLine($"  Gen 1 collections: {GC.CollectionCount(1)}");
        Console.WriteLine($"  Gen 2 collections: {GC.CollectionCount(2)}");
    }
}
