using System;

namespace Delegates101
{
    class Program
    {
        static void Main(string[] args)
        {
            //create delegate instances
            NumberChanger nc1 = new NumberChanger(MiniCalc.AddNum);
            NumberChanger nc2 = MiniCalc.MultNum; //removed explicit delegate creation here. Is same as nc1 really.
            
            //calling the methods using the delegate objects
            nc1(25);
            Console.WriteLine("Value of Num: {0}", MiniCalc.getNum());
            
            //in other works we pass appropriae parms to to the delegate instance, which delegates the logic to the method the instance points to.
            nc2(5);
            Console.WriteLine("Value of Num: {0}", MiniCalc.getNum());


            //Delegate objects can be composed using the "+" operator
            //Using this useful property of delegates you can create an invocation list of methods that will be called when a delegate is invoked. 
            //This is called multicasting of a delegate


            //create delegate instances
            MiniCalc.setNum(10); //reset the class
            NumberChanger nc;
            var nc3 = new NumberChanger(MiniCalc.AddNum);
            var nc4 = new NumberChanger(MiniCalc.MultNum);
            nc = nc3;
            nc += nc4; //nc is a multicast delegate. It will point to two methods
            
            //calling multicast
            nc(5);

            Console.WriteLine("Value of Num: {0}", MiniCalc.getNum());


            Console.ReadKey();
        }
    }
}
