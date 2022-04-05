using System;

namespace DaysCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime firstDate = new DateTime();
            DateTime secondDate = new DateTime();
            try
            {
                Console.WriteLine("Enter the first date: ");        
                firstDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Correct first date!");

                Console.WriteLine("Enter the second date: ");
                secondDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Correct second date!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong date and time format!");
                return;
            }

            Console.WriteLine("-----Result before timezones-----");
            TimeSpan difference = secondDate - firstDate;

            Console.WriteLine("Difference in days: " + Math.Abs(difference.Days));
            Console.WriteLine("Day for the given date " + secondDate + " is: " + secondDate.DayOfWeek);

            Console.WriteLine("-----Result after timezones-----");
            calculateTimeZone(firstDate, secondDate);
        }
        
        public static void calculateTimeZone(DateTime firstDate, DateTime secondDate)
        {
            string firstTimeZone, secondTimeZone;

            TimeZoneInfo tzi1, tzi2;

            TimeSpan dateDifference;
            try
            {
                Console.WriteLine("Enter the first timezone for the first date: ");
                firstTimeZone = Console.ReadLine();

                tzi1 = TimeZoneInfo.FindSystemTimeZoneById(firstTimeZone);
                DateTime firstDateTimeZoneConversion = TimeZoneInfo.ConvertTime(firstDate, tzi1);
                Console.WriteLine("Correct first timezone!");

                Console.WriteLine("Enter the second timezone for the second date: ");
                secondTimeZone = Console.ReadLine();

                tzi2 = TimeZoneInfo.FindSystemTimeZoneById(secondTimeZone);
                DateTime secondDateTimeZoneConversion = TimeZoneInfo.ConvertTime(secondDate, tzi2);
                Console.WriteLine("Correct second timezone!");

                dateDifference = secondDateTimeZoneConversion - firstDateTimeZoneConversion;
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured. Exiting...");
                return;
            }

            Console.WriteLine("Difference in days is: " + dateDifference.Days);
            Console.WriteLine("Difference in time is: " + dateDifference.Hours + ":" + dateDifference.Minutes + ":" + dateDifference.Seconds);
        }
    }
}