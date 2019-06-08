using System;

namespace Delegates101
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //MiniCalcExample();

            var tcTutorial = new TimCoreyTutoral.CoreyProgram(); //run this example, launched from ctor
           
        }

        static void MiniCalcExample()
        {

            // MiniCalc is our straight up calculator class with 4 methods.
            // MiniCalc.cs also defines a .Net1 delegate: delegate int NumberChanger(int n);
            // We make NumberChanger delegate instances when we define which function they point to
            // later we can execute the delegate, which executes the function it points to, eg: nc1(25) calls MiniCalc.AddNum(25)

            // Although this does not look that useful here, we can pass the delegate into a function to be run later, without changing the internals of the function, eg:
            var nc10 = new NumberChanger(MiniCalc.AddNum);
            var output = PassMeADelegate(nc10, 100); //pass in a delegate and the function input parameter
            var output2 = PassMeADelegate(MiniCalc.AddNum, 100); //use an anonymous delegate
            Console.WriteLine("Value of output: {0}", output); //110
            MiniCalc.setNum(10); //reset the class

            var output3 = PassMeADelegateWithoutInput(MiniCalc.AddNum); //pass the delegate to be run with input parameter from the containing function
            MiniCalc.setNum(10); //reset the class


            //create delegate instances(not matching sig of int in, int out)
            NumberChanger nc1 = new NumberChanger(MiniCalc.AddNum);
            NumberChanger nc2 = MiniCalc.MultNum; //removed explicit delegate creation here. Is same as nc1 really.

            //calling the methods using the delegate objects
            nc1(25);
            Console.WriteLine("Value of Num: {0}", MiniCalc.getNum()); // 10+25=35

            //in other works we pass appropriate params to to the delegate instance, which delegates the logic to the method the instance points to.
            nc2(5);
            Console.WriteLine("Value of Num: {0}", MiniCalc.getNum()); //175


            //Delegate objects can be composed using the "+" operator
            //Using this useful property of delegates you can create an invocation list of methods that will be called when a delegate is invoked. 
            //This is called multicasting of a delegate


            //multicast delegate example:

            MiniCalc.setNum(10); //reset the class

            //create delegate instances
            var nc3 = new NumberChanger(MiniCalc.AddNum);
            NumberChanger nc4 = new NumberChanger(MiniCalc.MultNum);
            NumberChanger nc = nc3;
            nc += nc4; //nc is now a multicast delegate. It will point to two methods

            //calling multicast. Both methods get called ofc.
            nc(5);

            Console.WriteLine("Value of Num: {0}", MiniCalc.getNum());

            Console.ReadKey();
        }

        static int PassMeADelegate(NumberChanger aDelegate, int input)
        {
            var output = aDelegate.Invoke(input); //explicitly invoke
            return output;
        }

        static int PassMeADelegateWithoutInput(NumberChanger aDelegate)
        {
            int useInternalValue = 23;
            var output = aDelegate(useInternalValue);

            return output;
        }
    }
}
