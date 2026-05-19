internal sealed class DemoObject
{
    private readonly byte[] _data = new byte[1024];

    public DemoObject(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
