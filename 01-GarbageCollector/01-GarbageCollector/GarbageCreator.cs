internal sealed class GarbageCreator
{
    public void CreateGarbage()
    {
        Console.WriteLine("Allocating objects...");

        for (var i = 0; i < 50_000; i++)
        {
            _ = new DemoObject(i);
        }
    }
}
