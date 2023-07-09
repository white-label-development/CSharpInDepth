
using ConsoleApp;

Console.WriteLine("Console App for delegate exploration");

var examples = new Examples();

examples.PureDelegate();
Console.WriteLine("-------------------");
examples.MulticastDelegate();
Console.WriteLine("-------------------");
examples.ActionExample();
Console.WriteLine("-------------------");
examples.ActionEquivalentDelegateMethod();
Console.WriteLine("-------------------");
examples.FuncExample();
Console.WriteLine("-------------------");
await examples.FuncAsyncExample();
Console.WriteLine("-------------------");
examples.MethodThatTakesAFunc(x => x * 10);