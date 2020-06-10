using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace csharp_web_dev_lsn9exceptions
{
    class Program
    {
        static double Divide(double x, double y)
        {
            if( y != 0)
            {
                return x / y;
            } else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        static int CheckFileExtension(string fileName)
        {
            string pattern = @"\.cs\z";
            if(String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException();
            }
            Match m = Regex.Match(fileName, pattern, RegexOptions.IgnoreCase);
            if (m.Success)
                return 1;
            else
                return 0;
        }


        static void Main(string[] args)
        {
            // Test out your Divide() function here!
            try
            {
                Divide(10, 0);
            } catch (ArgumentOutOfRangeException e)
            {
                Console.Error.WriteLine(e.Message);
            }
            // Test out your CheckFileExtension() function here!
            Dictionary<string, string> students = new Dictionary<string, string>();
            students.Add("Carl", "Program.cs");
            students.Add("Brad", "");
            students.Add("Elizabeth", "MyCode.cs");
            students.Add("Stefanie", "CoolProgram.cs");
            try
            {
                foreach(KeyValuePair<string, string> s in students)
                {
                    Console.WriteLine($"{s.Key} {CheckFileExtension(s.Value)}");
                    
                }
            } 
            catch (ArgumentNullException e)
            {
                Console.Error.WriteLine(e.Message);
            }

        }
    }
}
