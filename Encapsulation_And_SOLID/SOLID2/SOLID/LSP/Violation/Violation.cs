using System;

namespace SOLID.LSP.Violation
{
    public class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Square : Rectangle
    {

    }

    public class AreaCalculator
    {
        // or maybe it'd be better to multiply Widths?       
        public static int CalcSquare(Square square) => square.Height * square.Height;
        public static int CalcRectangle(Rectangle square) => square.Height * square.Width;

        public static int CalcArea(Rectangle rect)
        {
            if (rect is Square)
            {
                return rect.Height * rect.Height;
            }
            else
            {
                return rect.Height * rect.Width;
            }
        }

    }

    class EntryPoint
    {
        static void SuperMain(string[] args)
        {
            Rectangle rect = new Rectangle() { Width = 2, Height = 5 };
            int rectArea = AreaCalculator.CalcRectangle(rect);

            Console.WriteLine($"Rectangle Area = {rectArea}");

            //

            Rectangle square = new Square() { Height = 2, Width = 10 };
            int squareArea = AreaCalculator.CalcRectangle(square);
            Console.WriteLine($"Square Area = {squareArea}");

        }
    }
}
