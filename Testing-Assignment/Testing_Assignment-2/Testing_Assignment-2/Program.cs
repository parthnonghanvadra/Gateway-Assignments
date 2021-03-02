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
            string output;

            //case 1
            output = ExtensionMethods.StringConvert(inputString, "UppartoLower");

            //case 2
            output = ExtensionMethods.StringConvert(inputString, "TitleCase");

            //case 3
            output = ExtensionMethods.StringConvert(inputString, "CheckUppar");

            //case 4
            output = ExtensionMethods.StringConvert(inputString, "Capitalized");

            //case 5
            output = ExtensionMethods.StringConvert(inputString, "CheckLower");

            //case 6
            output = ExtensionMethods.StringConvert(inputString, "CheckforInt");

            //case 7
            output = ExtensionMethods.StringConvert(inputString, "RemoveLastChar");

            //case 8
            output = ExtensionMethods.StringConvert(inputString, "WordCount");

            //case 9
            output = ExtensionMethods.StringConvert(inputString, "StringToInt");
        }
    }
}
