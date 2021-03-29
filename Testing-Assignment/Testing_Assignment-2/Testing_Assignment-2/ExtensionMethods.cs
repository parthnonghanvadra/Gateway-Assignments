using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Assignment_2
{
    public static class ExtensionMethods
    {

        /// <summary>
        /// Converts the given string to an integer
        /// </summary>
        /// <returns>
        /// decimal if the given string can be converted, null otherwise
        /// </returns>
        public static string StringToInt(this string inputString)
        {
            try
            {
                return "" + int.Parse(inputString);
            }
            catch (Exception)
            {

                return "null";
            }

        }

        /// <summary>
        /// Word Count in given string
        /// </summary>
        /// <returns>
        /// total number of words
        /// </returns>
        public static string WordCount(this string inputString)
        {
            return "" + inputString.Count();
        }

        /// <summary>
        /// Remove last char from given string
        /// </summary>
        /// <returns>
        /// return string
        /// </returns>
        public static string RemoveLastChar(this string inputString)
        {
            return inputString.Substring(0, inputString.Length - 1);
        }

        public static string CheckforInt(this string inputString)
        {
            try
            {
                int x = int.Parse(inputString);
                return "Success";
            }
            catch (Exception)
            {

                return "Failed";
            }
        }

        /// <summary>
        /// check string for upparcase
        /// </summary>
        /// <returns>
        /// return upparvase if it is upparcase otherwise null
        /// </returns>
        public static string CheckUppar(this string inputString)
        {
            int ascii = 0;

            foreach (var item in inputString)
            {
                ascii = (int)item;
                bool status = false;
                if (ascii >= 65 && ascii <= 90)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                if (status)
                {
                    return "upparCase";
                }
            }

            return "null";
        }

        /// <summary>
        /// check string for lowercase
        /// </summary>
        /// <returns>
        /// return upparvase if it is lowercase otherwise null
        /// </returns>
        public static string CheckLower(this string inputString)
        {
            int ascii = 0;
            foreach (var item in inputString)
            {
                ascii = (int)item;
                bool status = false;
                if (ascii >= 97 && ascii <= 122)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                if (status)
                {
                    return "lowerCase";
                }
            }
            return "null";
        }

        /// <summary>
        /// convert string in Title case
        /// </summary>
        /// <returns>
        /// return coneverted string
        /// </returns>
        public static string TitleCase(this string inputString)
        {
            TextInfo textInfo = new CultureInfo("en-us", false).TextInfo;
            return textInfo.ToTitleCase(inputString);
        }

        /// <summary>
        /// convert string in Capitalized case
        /// </summary>
        /// <returns>
        /// return coneverted string
        /// </returns>
        public static string Capitalized(this string inputString)
        {
            TextInfo textInfo = new CultureInfo("en-us", false).TextInfo;
            return textInfo.ToTitleCase(inputString);
        }

        /// <summary>
        /// convert Upparcase string in lower case
        /// </summary>
        /// <returns>
        /// return coneverted string
        /// </returns>
        public static string InverseCase(this string inputString)
        {
            string output = "";
            int ascii = 0;
            foreach (var ch in inputString)
                {
                    ascii = (int)ch;
                    if (ascii >= 65 && ascii <= 90)
                        ascii += 32;
                    else if (ascii >= 97 && ascii <= 122)
                        ascii -= 32;
                    output += (char)ascii;
                }

            return output;
        }
    }

    
}
