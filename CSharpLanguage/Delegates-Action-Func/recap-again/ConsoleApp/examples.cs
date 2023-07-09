using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp
{
    internal class Examples
    {
        delegate int DoMath(int number); // the delegate definition
        internal void PureDelegate()
        {
            DoMath addTwo = new DoMath(AddTwo); // can assign any function that matches the sig to the delegate
            DoMath multiplyByTwo = new DoMath(MultiplyByTwo);

            int AddTwo(int number) => number + 2; // these functions match the required sig
            int MultiplyByTwo(int number) => number * 2;

            Console.WriteLine(addTwo(10));
            Console.WriteLine(multiplyByTwo(10));
        }



        delegate void PrintToConsole(string text); // the delegate definition
        internal void MulticastDelegate()
        {
            void PrintUpperCase(string text) => Console.WriteLine(text.ToUpper());
            void PrintLowerCaps(string text) => Console.WriteLine(text.ToLower());

            var printDelegate = new PrintToConsole(PrintLowerCaps);
            printDelegate += PrintUpperCase;

            printDelegate("Hello World");
        }



        internal void ActionExample()
        {
            Action<int, int> myAction = (x, y) => Console.WriteLine(x + y); // takes 2 parameters (no return value)

            ProcessAction(2, 3, myAction);
        }
        internal void ProcessAction(int x, int y, Action<int, int> action) => action(x, y);

        // actions are neater than delegates, ie:
        delegate void ActionEquivalentDelegate(int x, int y); // the delegate definition
        internal void ActionEquivalentDelegateMethod()
        {
            void SumAndWriteToConsole(int x, int y) => Console.WriteLine(x + y); // the function
            ActionEquivalentDelegate actionEquivalent = new ActionEquivalentDelegate(SumAndWriteToConsole); // wire function to delegate           
            actionEquivalent(2, 3); // call the implementation of the delegate
        }



        Func<int, int> MultiplyByTwo = n => n * 2;
        internal void FuncExample()
        {
            Console.WriteLine(MultiplyByTwo(12));
        }

        Func<int, Task<int>> MultiplyByTwoAsync = async n => n * 2;
        internal async Task FuncAsyncExample()
        {
            Console.WriteLine(await MultiplyByTwoAsync(24));
        }

        internal void MethodThatTakesAFunc(Func<int, int> f)
        {
            Console.WriteLine(f(7)); // pass 7 to the func, and the func will do something and return an int.
                                     // we pass in a func that times by ten: examples.MethodThatTakesAFunc(x => x * 10);
        }

        internal void AnonymousFunction()
        {
            // re-use delegate int DoMath(int number);

            DoMath addTwo = delegate (int number)
            {
                return number + 2;
            }; // reduces need for explicit function in delegat example: int AddTwo(int number) => number + 2;

            Console.WriteLine(addTwo(2));
        }

        // https://steven-giesel.com/blogPost/aa77f7fb-41a7-47d2-8e48-ef9e101cf08e
    }
}
