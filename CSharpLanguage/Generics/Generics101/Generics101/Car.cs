using System.Collections.Generic;

namespace Generics101
{
    public class Car<T>
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public T Engine { get; set; }
    }

    public class V8
    {
        public V8()
        {
            HorsePower = 300;
        }

        public int HorsePower { get; set; }
    }

    public class CarExample
    {
        public void Main()
        {
            var car1 = new Car<V8> { ID = 1, Make = "Ford" };
            var car2 = new Car<V8> { ID = 2, Make = "Toyota" };

            var cars = new List<Car<V8>>(); //super simple example of a generic list of Cars with a V8. List<Car<T>>() would be better though.
        }
    }
}
