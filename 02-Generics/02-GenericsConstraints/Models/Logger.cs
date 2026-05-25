namespace _02_GenericsConstraints;

// A type with a parameterless constructor for the new() constraint demo.
public class Logger
{
    public Logger() => Console.WriteLine("  [Logger created via new() constraint]");
    public void Log(string message) => Console.WriteLine($"  LOG: {message}");
}
