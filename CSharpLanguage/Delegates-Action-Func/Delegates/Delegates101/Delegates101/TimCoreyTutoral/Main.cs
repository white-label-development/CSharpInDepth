using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Delegates101.TimCoreyTutoral
{
   
    public  class CoreyProgram
    {
        // https://www.youtube.com/watch?v=R8Blt5c-Vi4
        // real example uses 3 projects, but I will try to condense it into an console app as I can't be arsed with a winforms UI!

        ShoppingCartModel _cart;

        public CoreyProgram()
        {
            _cart = new ShoppingCartModel();
            PopCart();

            //v0
            //Console.WriteLine($"The total is {_cart.GenerateTotal_0(SubTotalAlert):C2}"); //GenerateTotal is passed the function reference, to be passed the input parameter and executed later.

            //v1
            Console.WriteLine($"The total is {_cart.GenerateTotal_1(SubTotalAlert, CalculateLeveledDiscount, AlertUser):C2}"); //GenerateTotal is passed SubTotalAlert and CalculateLeveledDiscount
            Console.WriteLine();

            //v2 x3 anonymous inline methods
            decimal total = _cart.GenerateTotal_1(
                (subTotal) => Console.WriteLine($"The subtotal for cart 2 is {subTotal:C2}"),

                (products, subtotal) =>
                {
                    if (products.Count > 3)
                    {
                        return subtotal * 0.5M;
                    }
                    else
                    {
                        return subtotal;
                    }
                },

                (message) => Console.WriteLine(message)
                );
            Console.WriteLine($"The Total is {total:C2}");

            Console.ReadKey();
        }

        //SubTotalAlert matches delegate sig: public delegate void MentionDiscount(decimal subTotal);
        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"subtotal is {subTotal:C2}");
        }

        private static void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

        //matches sig: Func<List<ProductModel>, decimal, decimal>
        private static decimal CalculateLeveledDiscount(List<ProductModel> items, decimal subTotal)
        {
           
            if (subTotal > 100)
            {
                return subTotal * 0.80M;
            }
            else if (subTotal > 50)
            {
                return subTotal * 0.85M;
            }
            else if (subTotal > 10)
            {
                return subTotal * 0.95M;
            }
            else
            {
                return subTotal;
            }
        }

        private void PopCart()
        {
            _cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M});
            _cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            _cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            _cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }

    }



    

    public class ShoppingCartModel
    {
        public ShoppingCartModel() => Items = new List<ProductModel>();

        public List<ProductModel> Items { get; set; }

        public delegate void MentionDiscount(decimal subTotal); //delegate definition


        public decimal GenerateTotal_0(MentionDiscount mentionDiscount)
        {
            var subTotal = Items.Sum(x => x.Price);

            mentionDiscount(subTotal);

            //this is a code smell - when new sale rules come in we have to change the code here
            if (subTotal > 100)
            {
                return subTotal * 0.80M;
            }
            else if (subTotal > 50)
            {
                return subTotal * 0.85M;
            }
            else if (subTotal > 10)
            {
                return subTotal * 0.9M;
            }
            else
            {
                return subTotal;
            }
        }

        private Func<int, int, int> myFunc; //Funcs don't have to be anonymous

        //only real difference between the defined delegate and the func is that the Func is defined anonymously inline
        //Action is there just for a good example
        public decimal GenerateTotal_1(MentionDiscount mentionSubtotal, 
            Func<List<ProductModel>, decimal, decimal> calculateDiscountedTotal,
            Action<string> tellUserWeAreDiscounting)
        {
            var subTotal = Items.Sum(x => x.Price);

            mentionSubtotal(subTotal);

            tellUserWeAreDiscounting("We are applying your discount");
            
            return calculateDiscountedTotal(Items, subTotal); // if (subTotal > 100) ... moved to Func


        }
    }

    public class ProductModel
    {
        public string ItemName{ get; set; }
        public decimal Price { get; set; }  
    }
}
