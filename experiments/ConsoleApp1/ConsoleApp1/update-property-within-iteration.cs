using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.IterationSpike
{
    //confuses myself while working on a real client project as I could not update a property of an object within an iteration (well, I could - but in local scope, but then it was lost).
    //this is to explore this limit as I wasted an hour on it.


    public class Apple
    {
        public int AppleId { get; set; }
        public IEnumerable<Banana> Bananas { get; set; }
    }

    public class Banana
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TestClass
    {
        public void TestMethod()
        {
            IEnumerable<Apple> apples = new List<Apple>
            {
                new Apple{AppleId = 1, Bananas = new List<Banana> {new Banana {Id = 100, Name = "1-100"},new Banana {Id = 101, Name = "1-101"},new Banana {Id = 102, Name = "1-102"}}},
                new Apple{AppleId = 2, Bananas = new List<Banana> {new Banana {Id = 200, Name = "2-200"},new Banana {Id = 201, Name = "2-201"},new Banana {Id = 202, Name = "2-202"}}},
                new Apple{AppleId = 3, Bananas = new List<Banana> {new Banana {Id = 300, Name = "3-300"},new Banana {Id = 301, Name = "3-301"},new Banana {Id = 302, Name = "3-302"}}},
            };

            //UpdateAppleIdInLoop(apples); //update apple property in foreach. this works as expected (phew! I've not gone crazy!)
            //UpdateBananaPropertyInLoop(apples); //update apple property in foreach. this works as expected 

            //UpdateBanenaPropertyInLoop DID NOT WORK in real life yesterday - so I need to replicate my environment better. let's try again:
        }

        public void UpdateAppleIdInLoop(IEnumerable<Apple> apples)
        {
            //sanity check 1
            foreach (var apple in apples)
            {
                apple.AppleId = 1000; 
            }

            foreach (var apple in apples)
            {
                Console.WriteLine("apple AppleId=" + apple.AppleId);
            }
        }

        public void UpdateBananaPropertyInLoop(IEnumerable<Apple> apples)
        {
            var apple1 = apples.FirstOrDefault();
            foreach (var banana in apple1.Bananas)
            {
                banana.Name = "foo";
            }

            foreach (var banana in apple1.Bananas)
            {
                Console.WriteLine("banana.Name=" + banana.Name);
            }
        }

        public void UpdateBananaPropertyInLoop2(IEnumerable<Apple> apples)
        {

            //ok, I actually had "cfoCateringCafeDto" == apple
            //and cfoCateringCafeDto.CafeCateringCustomers == apple.Bananas


            var apple1 = apples.FirstOrDefault();
            foreach (var banana in apple1.Bananas)
            {
                banana.Name = "foo";
            }

            foreach (var banana in apple1.Bananas)
            {
                Console.WriteLine("banana.Name=" + banana.Name);
            }
        }
    }

}
