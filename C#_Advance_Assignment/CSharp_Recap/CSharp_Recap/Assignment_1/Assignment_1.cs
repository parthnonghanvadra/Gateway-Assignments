using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CSharp_Recap.Assignment_1
{
    public class Assignment_1
    {
        public static void Execute()
        {
            Console.WriteLine("================ 1) Culture Example ====================");
            Countries.Execute();

            Console.WriteLine("\r\n================ 2) Dynamic Object Example ====================");

            Students.Execute();

            Console.WriteLine("\r\n================ 3) Delegate Example ====================");

            DelegateFeature.Caller();

            Console.WriteLine("\n==========================================");
            Console.WriteLine(Environment.NewLine + " Process Completed " + Environment.NewLine);
            Console.ReadLine();

        }

    }


    public class Countries
    {
        public static void Execute()
        {
            List<string> countries = HelperMethods.GetCountry();

            int countOfCountriesStartWithI = countries.Count(c => c.StartsWith("I"));

            Console.WriteLine("\n==========================================");

            Console.WriteLine("\r\nCount of countries which starts with I:\n" + countOfCountriesStartWithI);

            Console.WriteLine("\n==========================================");

            Console.WriteLine("\r\nCountryNames in group of their countryName length:\n");

            var countriesGroupedByLength = countries.GroupBy(c => c.Length).OrderBy(c => c.Key);
            foreach (var countryGroup in countriesGroupedByLength)
            {
                Console.WriteLine("Country Name Length " + countryGroup.Key + ":");
                Console.WriteLine(String.Join(",", countryGroup) + Environment.NewLine);
            }
            Console.WriteLine("\n==========================================\n");
        }
    }


    public class HelperMethods
    {
        public static List<string> GetCountry()
        {
            List<string> list = new List<string>();
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo info in cultures)
            {
                RegionInfo info2 = new RegionInfo(info.LCID);
                if (!list.Contains(info2.EnglishName))
                {
                    list.Add(info2.EnglishName);
                }
            }
            return list;
        }
    }


    public class Students
    {
        public static void Execute()
        {

            SchoolStudent schoolStudentObject = new SchoolStudent(1, "Parth", "Nonghanvadra", 22, true, true, false, DateTime.Now, "Rajkot");
            CollegeStudent collegeStudentObject = new CollegeStudent();

            var listOfSchoolStudentProperties = schoolStudentObject.GetType().GetProperties();
            var listOfCollegeStudentProperties = collegeStudentObject.GetType().GetProperties();


            foreach (var schoolStudentProperty in listOfSchoolStudentProperties)
            {
                foreach (var collegeStudentProperty in listOfCollegeStudentProperties)
                {
                    if (schoolStudentProperty.Name == collegeStudentProperty.Name &&
                        schoolStudentProperty.PropertyType == collegeStudentProperty.PropertyType)
                    {
                        collegeStudentProperty.SetValue(collegeStudentObject, schoolStudentProperty.GetValue(schoolStudentObject));
                        break;
                    }
                }
            }

            Console.WriteLine("\n==========================================\n");
            Console.WriteLine("School Student Object:\n");
            foreach (var schoolStudentProperty in listOfSchoolStudentProperties)
            {
                Console.WriteLine("{0} : {1}", schoolStudentProperty.Name, schoolStudentProperty.GetValue(schoolStudentObject));
            }

            Console.WriteLine("\n==========================================\n");
            Console.WriteLine("College Student Object:\n");

            foreach (var collegeStudentProperty in listOfCollegeStudentProperties)
            {
                Console.WriteLine("{0} : {1}", collegeStudentProperty.Name, collegeStudentProperty.GetValue(collegeStudentObject));
            }
            Console.WriteLine("\n==========================================\n");
        }
    }



    public class DelegateFeature
    {
        public delegate void Calculator(int x, int y);

        static void Addition(int num1, int num2)
        {
            Console.WriteLine("Addition: " + (num1 + num2));
        }

        static void Subtraction(int num1, int num2)
        {
            Console.WriteLine("Subtraction: " + (num1 - num2));
        }

        static void Multiplication(int num1, int num2)
        {
            Console.WriteLine("Multiplication: " + (num1 * num2));
        }

        static void Division(int num1, int num2)
        {
            Console.WriteLine("Division: " + (num1 / num2));
        }

        public static void Caller()
        {
            Calculator myCalculator = Addition;

            myCalculator += Subtraction;
            myCalculator += Multiplication;

            Console.WriteLine("\r\nCalculator with Add, Subtract and Multiplication:\n");
            Perform_Calculation(myCalculator);

            Console.WriteLine("\r\nCalculator with Add, Multiplication and Division:\n");
            myCalculator -= Subtraction;
            myCalculator += Division;

            Perform_Calculation(myCalculator);
        }

        public static void Perform_Calculation(Calculator calc)
        {
            int num1 = 10, num2 = 5;

            calc(num1, num2);

        }

    }

}
