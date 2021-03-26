using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            //case 1
            Console.WriteLine(inputString.UppartoLower());

            //case 2
            Console.WriteLine(inputString.TitleCase());

            //case 3
            Console.WriteLine(inputString.CheckUppar());

            //case 4
            Console.WriteLine(inputString.Capitalized());

            //case 5
            Console.WriteLine(inputString.CheckLower());

            //case 6
            Console.WriteLine(inputString.CheckforInt());

            //case 7
            Console.WriteLine(inputString.RemoveLastChar());

            //case 8
            Console.WriteLine(inputString.WordCount());

            //case 9
            Console.WriteLine(inputString.StringToInt());

            Console.ReadLine();
        }
    }
}
