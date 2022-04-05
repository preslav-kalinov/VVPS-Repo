using System;

namespace DaysCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime firstDate = new DateTime(2022, 01, 01);
            Console.WriteLine("Enter a date: ");
            
            DateTime secondDate = new DateTime();
            try
            {
                secondDate = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong date and time format!");
                return;
            }

            TimeSpan difference = secondDate - firstDate;

            Console.WriteLine("Difference in days: " + difference.Days);
            Console.WriteLine("Day for the given date " + secondDate + " is: " + secondDate.DayOfWeek);
        }
    }
}
