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
        public static string[] dirReduc(String[] arr)
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
                    
                    return dirReduc(newArray.ToArray());                  
                }

                previousPoint = point;
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
