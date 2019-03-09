using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodingKataLessons
{

    /*
     *… a man was given directions to go from one point to another.
     * The directions were "NORTH", "SOUTH", "WEST", "EAST".
     * Clearly "NORTH" and "SOUTH" are opposite, "WEST" and "EAST" too.
     * Going to one direction and coming back the opposite direction is a needless effort.
     * Since this is the wild west, with dreadfull weather and not much water, it's important to save yourself some energy, otherwise you might die of thirst!
     *
     * Write a function dirReduc which will take an array of strings and returns an array of strings with the needless directions removed (W<->E or S<->N side by side).
     */
    public class DirReduction
    {
        public static string[] dirReduc_WRONG(String[] arr)
        {            
            string previousPoint = "";
            foreach (var point in arr)
            {
                if (isOpposite(point, previousPoint))
                {
                    var newArray = new List<string>();
                    newArray.AddRange(arr.ToList());                                            
                    newArray.Remove(point); //this is wrong as it removes the FIRST OCCURENCE when we need it removed at it's index point. come back and fix https://www.codewars.com/kata/550f22f4d758534c1100025a/train/csharp
                    newArray.Remove(previousPoint);   
                    
                    return dirReduc_WRONG(newArray.ToArray());                  
                }

                previousPoint = point;
            }
            return arr;
        }


        public static string[] dirReduc(String[] arr)
        {
            string previousPoint = "";
            int index = 0;
            foreach (var point in arr)
            {
                if (isOpposite(point, previousPoint))
                {
                    var newArray = new List<string>();
                    newArray.AddRange(arr.ToList());

                    newArray.RemoveAt(index);
                    newArray.RemoveAt(index-1);
                  
                    return dirReduc(newArray.ToArray());
                }

                previousPoint = point;
                index++;
            }
            return arr;
        }

        static bool isOpposite(string a, string b)
        {
            if (a == "NORTH" && b == "SOUTH") return true;
            if (a == "SOUTH" && b == "NORTH") return true;
            if (a == "EAST" && b == "WEST") return true;
            if (a == "WEST" && b == "EAST") return true;
            return false;
        }



        //and the clever people did...

        public static String[] dirReduc_1(String[] arr)
        {
            Stack<String> stack = new Stack<String>();

            foreach (String direction in arr)
            {
                String lastElement = stack.Count > 0 ? stack.Peek().ToString() : null;

                switch (direction)
                {
                    case "NORTH": if ("SOUTH".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
                    case "SOUTH": if ("NORTH".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
                    case "EAST": if ("WEST".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
                    case "WEST": if ("EAST".Equals(lastElement)) { stack.Pop(); } else { stack.Push(direction); } break;
                }
            }
            String[] result = stack.ToArray();
            Array.Reverse(result);

            return result;
        }


        //NT: I like this one
        public static string[] dirReduc_2(String[] arr)
        {
            Dictionary<string, string> oppositeOf = new Dictionary<string, string>()
            {
                {"NORTH", "SOUTH"},
                {"SOUTH", "NORTH"},
                {"EAST", "WEST"},
                {"WEST", "EAST"}
            };

            List<string> betterDirections = new List<string>();
            foreach (var direction in arr)
            {
                if (betterDirections.LastOrDefault() == oppositeOf[direction])
                {
                    betterDirections.RemoveAt(betterDirections.Count - 1);
                }
                else
                {
                    betterDirections.Add(direction);
                }
            }
            return betterDirections.ToArray();
        }


    }

    [TestFixture]
    public class DirReductionTests
    {

        [Test]
        public void Test1()
        {
            string[] a = new string[] {"NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST"};
            string[] b = new string[] {"WEST"};
            Assert.AreEqual(b, DirReduction.dirReduc(a));
        }

        [Test]
        public void Test2()
        {
            string[] a = new string[] {"NORTH", "WEST", "SOUTH", "EAST"};
            string[] b = new string[] {"NORTH", "WEST", "SOUTH", "EAST"};
            Assert.AreEqual(b, DirReduction.dirReduc(a));
        }

        [Test]
        public void Test3()
        {
            string[] a = new string[] { "NORTH", "SOUTH", "EAST", "WEST" };
            string[] b = new string[] { };
            Assert.AreEqual(b, DirReduction.dirReduc(a));
        }

        [Test]
        public void Test4()
        {
            string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH" };
            string[] b = new string[] {  };
            Assert.AreEqual(b, DirReduction.dirReduc(a));
        }


        [Test]
        public void Test5ByNeilRandomTest()
        {
            string[] a = new string[] { "EAST", "NORTH", "SOUTH", "EAST", "NORTH", "SOUTH", "SOUTH", "EAST", "SOUTH", "NORTH", };            
            string[] b = new string[] { "EAST", "EAST", "SOUTH", "EAST" };
            Assert.AreEqual(b, DirReduction.dirReduc(a));
        }
    }
}
