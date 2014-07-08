using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics101
{
    class Program
    {
        static void Main(string[] args)
        {
            var car1 = new Car<V8> { ID = 1, Make = "Ford" };
            var car2 = new Car<V8> { ID = 2, Make = "Toyota" };

            var cars = new List<Car<V8>>(); //super simple example of a generic list of Cars with a V8. List<Car<T>>() would be better though.
        }
    }
}
