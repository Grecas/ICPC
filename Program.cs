using System;

namespace TrafficBr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("0 " + isRed(0, 3, 5));
            Console.WriteLine("1 " + isRed(1, 3, 5));
            Console.WriteLine("2 " + isRed(2, 3, 5));
            Console.WriteLine("3 " + isRed(3, 3, 5));
            Console.WriteLine("4 " + isRed(4, 3, 5));
            Console.WriteLine("5 " + isRed(5, 3, 5));
            Console.WriteLine("6 " + isRed(6, 3, 5));
            Console.WriteLine("7 " + isRed(7, 3, 5));
            Console.WriteLine("8 " + isRed(8, 3, 5));
            Console.WriteLine("9 " + isRed(9, 3, 5));
            Console.WriteLine("10 " + isRed(10, 3, 5));
            Console.WriteLine("11 " + isRed(11, 3, 5));
            Console.WriteLine("12 " + isRed(12, 3, 5));
            Console.WriteLine("13 " + isRed(13, 3, 5));
            Console.WriteLine("14 " + isRed(14, 3, 5));
            Console.WriteLine("15 " + isRed(15, 3, 5));
            Console.WriteLine("16 " + isRed(16, 3, 5));
            Console.WriteLine("17 " + isRed(17, 3, 5));
            Console.WriteLine("18 " + isRed(18, 3, 5));
            Console.Read();
        }

        static bool isRed(int time, int red, int green)
        {
            return (time) % (green + red) < red;
        }
    }
}
