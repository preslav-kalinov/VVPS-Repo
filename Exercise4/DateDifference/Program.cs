// See https://aka.ms/new-console-template for more information
namespace date
{
    public class CalculkatorRunner
    {
        public static void Main(string[] args)
        {            
            DateCalculator dateCalculator = new DateCalculator();
            dateCalculator.calculateTimeZones();

            /*int choice = -1;
            while(choice != 0)
            {
                Console.WriteLine("Hello. Please enter 1 to calculate the day difference between two dates. Enter 2 to calculate which day of week is of the entered date. 0 to exit");
                choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("The difference is: " + dateCalculator.findDifferenceBetweenTwoDates());
                        break;
                    case 2:
                        Console.WriteLine("And the day of week is: " + dateCalculator.getDayOfWeek());
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            }
            */
        }
    }
}

