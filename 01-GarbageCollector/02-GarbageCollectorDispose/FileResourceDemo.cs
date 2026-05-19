internal sealed class FileResourceDemo
{
    private readonly string _filePath = Path.Combine(GetProjectDirectory(), "gc-file-demo.txt");

    public void Run()
    {
        Console.WriteLine(".NET GC and unmanaged file resource demo");
        Console.WriteLine("=======================================");

        RunDisposeDemo();
        RunGcFinalizerDemo();
        ClearDemoFile();

        Console.WriteLine();
        Console.WriteLine("Demo finished.");
    }

    private void RunDisposeDemo()
    {
        Console.WriteLine();
        Console.WriteLine("Entering RunDisposeDemo...");
        Console.WriteLine("This demo uses Dispose to close the file resource immediately.");

        using (var fileResource = new UnmanagedFileResource(_filePath))
        {
            fileResource.WriteLine("Line written by Dispose demo.");
            fileResource.WriteLine("The file handle will be closed when using block ends.");
        }

        using (var fileResource = new UnmanagedFileResource(_filePath))
        {
            var content = fileResource.ReadAllText();
            Console.WriteLine("File content after Dispose demo:");
            Console.WriteLine(content);
        }

        Console.WriteLine("Exiting RunDisposeDemo...");
    }

    private void RunGcFinalizerDemo()
    {
        Console.WriteLine();
        Console.WriteLine("Entering RunGcFinalizerDemo...");
        Console.WriteLine("This demo does not call Dispose. The finalizer will release the file resource when GC collects the object.");

        CreateResourceWithoutDispose();

        Console.WriteLine("Forcing garbage collection...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        Console.WriteLine("After GC, the finalizer should have released the file resource.");
        Console.WriteLine("Exiting RunGcFinalizerDemo...");
    }

    private void CreateResourceWithoutDispose()
    {
        var fileResource = new UnmanagedFileResource(_filePath);
        fileResource.WriteLine("Line written by GC finalizer demo.");
        fileResource.WriteLine("Dispose is intentionally not called for this object.");
    }

    private void ClearDemoFile()
    {
        Console.WriteLine();
        Console.WriteLine("Clearing demo file contents...");

        File.WriteAllText(_filePath, string.Empty);
    }

    private static string GetProjectDirectory()
    {
        return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
    }
}
