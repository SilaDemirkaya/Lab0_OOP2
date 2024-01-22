using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"C:\Users\silad\OneDrive\Desktop\Lab0\Lab0\numbers.txt";
            
            // Task 1: Updated to use double instead of int
            int low = (int)GetValidNumber("Enter the low number (positive only): ", true);
            int high = (int)GetValidNumber($"Enter the high number (greater than {low}): ", false, low);

            int difference = high - low;
            Console.WriteLine($"Difference: {difference}");

            // Rest of the code remains the same ...

            // Task 3 and additional tasks
            List<double> numbers = new List<double>();
            for (double i = high; i >= low; i--)
            {
                numbers.Add(i);
            }

            File.WriteAllLines(filepath, numbers.Select(n => n.ToString()));

            double sum = File.ReadAllLines(filepath).Select(double.Parse).Sum();
            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine("Prime numbers:");
            foreach (var number in numbers)
            {
                if (IsPrime(number))
                {
                    Console.WriteLine(number);
                }
            }
        }

        // Updated to use double
        static double GetValidNumber(string message, bool positiveOnly, double min = 0)
        {
            double number;
            do
            {
                Console.WriteLine(message);
                number = Convert.ToDouble(Console.ReadLine());
            }
            while ((positiveOnly && number <= 0) || (!positiveOnly && number <= min));

            return number;
        }

        static bool IsPrime(double number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
