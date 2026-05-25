namespace _02_GenericsConstraints;

public class Product : IIdentifiable
{
    public int Id { get; init; }
    public string Title { get; init; } = "";
    public override string ToString() => $"Product #{Id} - {Title}";
}
