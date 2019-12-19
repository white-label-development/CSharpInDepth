using System;

namespace CidConsole.CoreFoundations_2
{
    //Delegates

    // http://blogs.msdn.com/b/brunoterkaly/archive/2012/03/02/c-delegates-actions-lambdas-keeping-it-super-simple.aspx

    //A delegate is a reference to a method. 
    //Whereas objects can easily be sent as parameters into methods, constructor or whatever, 
    //methods are a bit more tricky. But every once in a while you might feel the need to send a method
    //as a parameter to another method, and that's when you'll need delegates.

    //If I want something to happen when a button is clicked, I don’t want to have to change the code of the button 
    //I just want to tell the button to call one of my methods, which will take the appropriate action.

    //consider delegates to be Anonymous Interfaces. In many cases you can use them whenever you need an interface with a single method, but you don't want the overhead of defining that interface.

    //Delegates can be chained together; for example, multiple methods can be called on a single event.

    //http://stackoverflow.com/questions/2019402/when-why-to-use-delegates

    //Essentially,
    //delegates provide a level of indirection: instead of specifying behavior to be executed
    //immediately, the behavior can somehow be “contained” in an object. That object can
    //then be used like any other, and one operation you can perform with it is to execute
    //the encapsulated action. Alternatively, you can think of a delegate type as a singlemethod
    //interface, and a delegate instance as an object implementing that interface.


    //In order for a delegate to do anything, four things need to happen:
    //1 The delegate type needs to be declared.
    //2 The code to be executed must be contained in a method.
    //3 A delegate instance must be created.
    //4 The delegate instance must be invoked.

    //1 This type derives from System.MulticastDelegate which derives from delegate.
    //delegate void StringProcessor(string input);

    //2 FINDING AN APPROPRIATE METHOD FOR THE DELEGATE INSTANCE’S ACTION
    // in c#1 the method sig must match exactly. behind the scenes we get void Invoke(string input)
    //void PrintString(string x)

    //3 yeah, invoke as expected this. myInstanceObj. myStaticObj

    //4 use it


    //proc1("Hello"); compiles to proc1.Invoke("Hello"); which at execution time invokes PrintString("Hello");

    //another xample
    //Delegates are extremely useful when wanting to declare a block of code that you want to pass around. 
    //For example when using a generic retry mechanism. 
    //function Retry(Delegate func, int numberOfTimes)
    //try
    //{
    //   func.Invoke();
    //}
    //catch { if(numberOfTimes blabla) func.Invoke(); etc. etc. }


    
    delegate void StringProcessor(string input);

    public class Person
    {
        string name;
        public Person(string name) { this.name = name; }

        //this will be 'assigned' to the delegate
        public void Say(string message)
        {
            Console.WriteLine("{0} says: {1}", name, message);
        }

    }

    class Background
    {
        public static void Note(string note)
        {
            Console.WriteLine("({0})", note);
        }
    }

    public class SimpleDelegateUse
    {
        public static void Run()
        {
            Person jon = new Person("Jon");
            Person tom = new Person("Tom");

            StringProcessor jonsVoice, tomsVoice, background; //declare and create the delegate instances                               
            jonsVoice = new StringProcessor(jon.Say); //The delegate object will basically hold a reference to a function. The function will then be called via the delegate object. 
            tomsVoice = new StringProcessor(tom.Say); //tom.say is contanined in the delegate
            background = new StringProcessor(Background.Note);

            //invoke the delegate instances
            jonsVoice("Hello, son."); //pay to the delegate a string, which is passed to jon.Say
            background("An airplane flies past.");
            tomsVoice.Invoke("Hello, Daddy!"); //explicity call Invoke,               

        }
    }

    //another example
    //By defining a delegate, you are saying to the user of your class 
    //"Please feel free to put any method that match this signature here and it will be called each time my delegate is called".
    public delegate int Calculate(int value1, int value2);

    //creating the class which contains the methods 
    //that will be assigned to delegate objects
    public class myCalc
    {
        //a method, that will be assigned to delegate objects
        //having the EXACT signature of the delegate
        public int add(int value1, int value2)
        {
            return value1 + value2;
        }
        //a method, that will be assigned to delegate objects
        //having the EXACT signature of the delegate
        public int sub(int value1, int value2)
        {
            return value1 - value2;
        }


    }

    public class SimpleDelegateUse2
    {
        public static void Run()
        {
            var mc = new myCalc();

            //creating delegate objects and assigning appropriate methods
            //having the EXACT signature of the delegate
            Calculate add = new Calculate(mc.add);
            Calculate sub = new Calculate(mc.sub);

            //using the delegate objects to call the assigned methods 
            //add and sub invoke the delegate - which executes the method provided to the delegate earlier.
            Console.WriteLine("Adding two values: " + add(10, 6));
            Console.WriteLine("Subtracting two values: " + sub(10, 4));
        }
    }

}
