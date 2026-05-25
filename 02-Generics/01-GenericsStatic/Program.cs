
// Create some Box<int> instances.
var a = new Box<int>(1);
var b = new Box<int>(2);
var c = new Box<int>(3);

// Create some Box<string> instances.
var d = new Box<string>("a");
var e = new Box<string>("b");


// Each closed generic type has its OWN static InstanceCount.
Console.WriteLine($"Box<int>.InstanceCount    = {Box<int>.InstanceCount}");    // 3
Console.WriteLine($"Box<string>.InstanceCount = {Box<string>.InstanceCount}"); // 2
