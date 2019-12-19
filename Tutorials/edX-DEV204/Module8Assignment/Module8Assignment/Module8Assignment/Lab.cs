using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Module8Assignment
{
    public class Lab
    {

        public void Test1()
        {
            //Instantiating a Generic Class
            CustomList<Coffee> clc = new CustomList<Coffee>();
            Coffee coffee1 = new Coffee();
            Coffee coffee2 = new Coffee();
            clc.Add(coffee1);
            clc.Add(coffee2);
            //Coffee firstCoffee = clc[0];
        }


    }

    public class Coffee
    {

    }

    // Creating a Generic Class
    public class CustomList<T>
    {
        //public T this[int index] { get; set; }
        public void Add(T item)
        {
            // Method logic goes here.
        }
        public void Remove(T item)
        {
            // Method logic goes here.
        }
    }
}
