using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            string tempchar = "";
            int a, b, mul;
            System.Console.Write("Please input an int:");
            tempchar = Console.ReadLine();
            a = Int32.Parse(tempchar);
            System.Console.Write("Please input an int:");
            tempchar = Console.ReadLine();
            b = Int32.Parse(tempchar);
            mul = a * b;
            Console.WriteLine("Multiply is :" + mul);
        }
    }
}
