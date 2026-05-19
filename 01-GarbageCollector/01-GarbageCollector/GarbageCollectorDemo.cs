internal sealed class GarbageCollectorDemo
{
    private readonly GarbageCreator _garbageCreator = new();
    private readonly MemoryReporter _memoryReporter = new();

    public void Run()
    {
        Console.WriteLine(".NET Garbage Collector overload demo");
        Console.WriteLine("====================================");

        _memoryReporter.Print("Initial state");

        _garbageCreator.CreateGarbage();
        _memoryReporter.Print("After object allocation");

        RunFullCollectionDemo();
        RunGenerationZeroCollectionDemo();
        RunForcedGenerationTwoCollectionDemo();
        RunBlockingCollectionDemo();
        RunCompactingCollectionDemo();

        Console.WriteLine();
    }

    private void RunFullCollectionDemo()
    {
        Console.WriteLine();
        Console.WriteLine("Entering RunFullCollectionDemo...");

        _garbageCreator.CreateGarbage();
        _memoryReporter.Print("After object allocation and before GC.Collect()");

        Console.WriteLine("1) GC.Collect() - starts collection for all generations.");

        GC.Collect();

        _memoryReporter.Print("After GC.Collect()");
        Console.WriteLine("Exiting RunFullCollectionDemo...");
    }

    private void RunGenerationZeroCollectionDemo()
    {
        Console.WriteLine();
        Console.WriteLine("Entering RunGenerationZeroCollectionDemo...");

        _garbageCreator.CreateGarbage();
        _memoryReporter.Print("After object allocation and before GC.Collect(0)");

        Console.WriteLine("2) GC.Collect(0) - starts collection only for generation 0.");

        GC.Collect(0);

        _memoryReporter.Print("After GC.Collect(0)");
        Console.WriteLine("Exiting RunGenerationZeroCollectionDemo...");
    }

    private void RunForcedGenerationTwoCollectionDemo()
    {
        Console.WriteLine();
        Console.WriteLine("Entering RunForcedGenerationTwoCollectionDemo...");

        _garbageCreator.CreateGarbage();
        _memoryReporter.Print("After object allocation and before GC.Collect(2, GCCollectionMode.Forced)");

        Console.WriteLine("3) GC.Collect(2, GCCollectionMode.Forced) - forces collection up to generation 2.");

        GC.Collect(2, GCCollectionMode.Forced);

        _memoryReporter.Print("After GC.Collect(2, GCCollectionMode.Forced)");
        Console.WriteLine("Exiting RunForcedGenerationTwoCollectionDemo...");
    }

    private void RunBlockingCollectionDemo()
    {
        Console.WriteLine();
        Console.WriteLine("Entering RunBlockingCollectionDemo...");

        _garbageCreator.CreateGarbage();
        _memoryReporter.Print("After object allocation and before GC.Collect(..., blocking: true)");

        Console.WriteLine("4) GC.Collect(2, GCCollectionMode.Forced, blocking: true) - blocks the current thread until collection finishes.");

        GC.Collect(2, GCCollectionMode.Forced, blocking: true);

        _memoryReporter.Print("After GC.Collect(..., blocking: true)");
        Console.WriteLine("Exiting RunBlockingCollectionDemo...");
    }

    private void RunCompactingCollectionDemo()
    {
        Console.WriteLine();
        Console.WriteLine("Entering RunCompactingCollectionDemo...");

        _garbageCreator.CreateGarbage();
        _memoryReporter.Print("After object allocation and before GC.Collect(..., compacting: true)");

        Console.WriteLine("5) GC.Collect(2, GCCollectionMode.Forced, blocking: true, compacting: true) - additionally requests LOH compaction.");

        GC.Collect(2, GCCollectionMode.Forced, blocking: true, compacting: true);

        _memoryReporter.Print("After GC.Collect(..., compacting: true)");
        Console.WriteLine("Exiting RunCompactingCollectionDemo...");
    }
}
