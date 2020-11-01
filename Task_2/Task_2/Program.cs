using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter c: ");
            long c = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("a = {0}; b = {1}; c = {2}", a, b, c);


        }
    }
}