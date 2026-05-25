using _02_GenericsConstraints;

Console.WriteLine("=== Generic Type Parameter Constraints Demo ===\n");

Console.WriteLine("1) where T : struct");
int? nullableInt = StructConstraintDemo<int>.AsNullable(42);
Console.WriteLine($"  AsNullable(42) => {nullableInt}");
Console.WriteLine();

Console.WriteLine("2) where T : class");
string? text = null;
Console.WriteLine($"  IsNull(null string)  => {ClassConstraintDemo<string>.IsNull(text!)}");
Console.WriteLine($"  IsNull(\"abc\")        => {ClassConstraintDemo<string>.IsNull("abc")}");
Console.WriteLine();

Console.WriteLine("3) where T : new()");
var logger = NewConstraintDemo<Logger>.CreateInstance();
logger.Log("Hello from a generically-created Logger.");
Console.WriteLine();

Console.WriteLine("4) where T : Animal (base class constraint)");
BaseClassConstraintDemo<Dog>.MakeItSpeak(new Dog { Name = "Rex" });
BaseClassConstraintDemo<Cat>.MakeItSpeak(new Cat { Name = "Whiskers" });
Console.WriteLine();

Console.WriteLine("5) where T : IIdentifiable (interface constraint)");
InterfaceConstraintDemo<Product>.PrintId(new Product { Id = 101, Title = "Keyboard" });
Console.WriteLine();

Console.WriteLine("6) Multiple constraints: class, IIdentifiable, new()");
Product p = MultipleConstraintsDemo<Product>.CreateAndDescribe();
Console.WriteLine($"  Returned: {p}");
Console.WriteLine();

Console.WriteLine("7) where T : U (type parameter constraint)");
var animals = new List<Animal>();
TypeParameterConstraintDemo<Animal, Dog>.AddIfDerived(animals, new Dog { Name = "Buddy" });
TypeParameterConstraintDemo<Animal, Cat>.AddIfDerived(animals, new Cat { Name = "Mittens" });
Console.WriteLine($"  animals.Count = {animals.Count}");
Console.WriteLine();

Console.WriteLine("8) where T : notnull");
NotNullConstraintDemo<int>.RequireNotNull(123);
NotNullConstraintDemo<string>.RequireNotNull("non-null string");
Console.WriteLine();

Console.WriteLine("9) where T : unmanaged");
Console.WriteLine($"  sizeof(int)    = {UnmanagedConstraintDemo<int>.SizeOf()} bytes");
Console.WriteLine($"  sizeof(double) = {UnmanagedConstraintDemo<double>.SizeOf()} bytes");
Console.WriteLine($"  sizeof(Guid)   = {UnmanagedConstraintDemo<Guid>.SizeOf()} bytes");
Console.WriteLine();

Console.WriteLine("10) where T : Enum");
foreach (var v in EnumConstraintDemo<TrafficLight>.GetValues())
{
    Console.WriteLine($"  TrafficLight value: {v}");
}
Console.WriteLine();

Console.WriteLine("11) where T : Delegate");
Action greet = () => Console.WriteLine("  Hello");
Action wave  = () => Console.WriteLine("  *waves*");
Action combined = DelegateConstraintDemo<Action>.Combine(greet, wave);
combined();
Console.WriteLine();

Console.WriteLine("=== Done ===");
