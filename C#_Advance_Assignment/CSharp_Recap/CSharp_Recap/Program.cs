using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Recap
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("================================ Assignment 1 ================================");
            Console.WriteLine("==============================================================================\r\n");
            Assignment_1.Assignment_1.Execute();

            Console.WriteLine("\r\n================================ Assignment 2 ================================");
            Console.WriteLine("==============================================================================\r\n");
            await Assignment_2.Assignment_2.Execute();

            Console.WriteLine("\r\n================================ Assignment 3 ================================");
            Console.WriteLine("==============================================================================\r\n");
            Assignment_3.Assignment_3.Execute();

            Console.ReadLine();

        }

    }

}
