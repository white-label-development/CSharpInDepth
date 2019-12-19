

using System;

namespace Generics101
{
    public class MoshTutorial
    {

        //non generic example
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        //Generic version must implement IComparable as can't compare unknown types (that may or may not be comparable)
        public T Max<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        // constraints:
        // where T : Comparable
        // where T : MyClass
        // where T : struct (so any value type)
        // where T : class (any reference type)
        // where T : new() (anything that can be instantiated)

        public void TypeContraintExample() //DiscountCalc where T: Product
        {
            var calc = new DiscountCalc<CarProduct>();
            var prod = new CarProduct {CarType = "type", Price = 100, Title = "title"};
            var discount = calc.CalcDiscount(prod);
        }
    }

    public class Product
    {
        public float Price { get; set; }
        public string Title { get; set; }
    }

    public class CarProduct : Product
    {
        public string CarType { get; set; }
    }


    public class DiscountCalc<TProduct> where TProduct : Product
    {
        public float CalcDiscount(TProduct product)
        {
            return product.Price = product.Price - 10; //TProduct properties available as this "generic" class only accepts types that are Products (in some way)
        }
    }
}
