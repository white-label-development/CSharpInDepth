using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod_9_Homework
{
    public class Lab
    {

    }


    //Suppose you create a struct named Coffee. 
    //One of the responsibilities of this struct is to keep track of the stock level for each Coffee instance. 
    //When the stock level drops below a certain point, you might want to raise an event 
    //to warn an ordering system that you are running out of beans. 

    //The first thing you need to do is to define a delegate. To define a delegate, 
    //you use the delegate keyword. A delegate includes two parameters:
    //The first parameter is the object that raised the event—in this case, a Coffee instance. 
    //The second parameter is the event arguments—in other words, any other information that you want to provide to consumers. 
    //This must be an instance of the EventArgs class, or an instance of a class that derives from EventArgs.


    //Defining a Delegate and an Event
    public struct Coffee_PreExample
    {
        public EventArgs e;
        public delegate void OutOfBeansHandler(Coffee_PreExample coffee, EventArgs args);

        // To define an event, you use the event keyword. 
        // You precede the name of your event with the name of the delegate you want to associate with your event.
        public event OutOfBeansHandler OutOfBeans; //associate a delegate named OutOfBeansHandler with the OutOfBeans event.
    }

    //When you raise the event, the delegate associated with your event will invoke any event handler methods that have subscribed to your event.

    //To raise an event, you need to do two things:
    //Check whether the event is null. The event will be null if no code is currently subscribing to it.
    //Invoke the event and provide arguments to the delegate.

    //For example, suppose a Coffee struct includes a method named MakeCoffee. 
    //Every time you call the MakeCoffee method, the method reduces the stock level of the Coffee instance. 
    //If the stock level drops below a certain point, the MakeCoffee method will raise an OutOfBeans event.

    // Raising an Event
    public struct Coffee
    {
        // Declare the event and the delegate.
        public EventArgs e;
        public delegate void OutOfBeansHandler(Coffee coffee, EventArgs args);
        public event OutOfBeansHandler OutOfBeans;
        public string Bean;

        int currentStockLevel;
        int minimumStockLevel;

        public void MakeCoffee()
        {
            // Decrement the stock level.
            currentStockLevel--;
            // If the stock level drops below the minimum, raise the event.
            if (currentStockLevel < minimumStockLevel)
            {
                // Check whether the event is null.
                if (OutOfBeans != null)
                {
                    // Raise the event.
                    OutOfBeans(this, e);
                }
            }
        }
    }


    //Subscribing to Events

    //If you want to handle an event in client code, you need to do two things:
    //Create a method with a signature that matches the delegate for the event.
    //Use the addition assignment operator (+=) to attach your event handler method to the event.


    // Subscribing to an Event
    public class Inventory
    {
        private Coffee coffee1;
        public Inventory()
        {
            coffee1 = new Coffee();
        }
        public void HandleOutOfBeans(Coffee sender, EventArgs args)
        {
            string coffeeBean = sender.Bean;
            // Reorder the coffee bean.
        }


        public void SubscribeToEvent()
        {
            coffee1.OutOfBeans += HandleOutOfBeans;
        }
    }
    //In this example, the signature of the HandleOutOfBeans method matches the delegate for the OutOfBeans event. 
    //When you call the SubscribeToEvent method, 
    //the HandleOutOfBeans method is added to the list of subscribers for the OutOfBeans event on the coffee1 object.



}
