namespace date
{
	public class DateCalculator
	{
		private DateTime beginningDate;
		private DateTime endDate;



		public DateCalculator()
		{

		}

		public int findDifferenceBetweenTwoDates()
        {
			setDates();
			return Math.Abs((endDate - beginningDate).Days);
        }

		public void setDates()
        {
			Console.WriteLine("Enter the data for the first date: ");
			beginningDate = setDate();
			Console.WriteLine("Enter the data for the second date: ");
			endDate = setDate();

		}

		public void calculateTimeZones()
        {
			Console.WriteLine("Enter the time zone of the first city. E.g Tokyo Standart Time");
			string timeZone1 = Console.ReadLine();

			Console.WriteLine("Enter the time zone of the second city:");
			string timeZone2 = Console.ReadLine();

			beginningDate = setDate();

			TimeZoneInfo timeZoneInfo1;
			TimeZoneInfo timeZoneInfo2;
			try
			{
				 timeZoneInfo1 = TimeZoneInfo.FindSystemTimeZoneById(timeZone1);
				 timeZoneInfo2 = TimeZoneInfo.FindSystemTimeZoneById(timeZone2);
				DateTime dateTimeZone1 = TimeZoneInfo.ConvertTime(beginningDate, TimeZoneInfo.Local, timeZoneInfo1);
				DateTime dateTimeZone2 = TimeZoneInfo.ConvertTime(beginningDate, TimeZoneInfo.Local, timeZoneInfo2);
				int hoursDifference = Math.Abs((dateTimeZone2 - dateTimeZone1).Hours);
				int daysDifference = Math.Abs((dateTimeZone2 - dateTimeZone1).Days);
				Console.WriteLine("Difference in days is: " + daysDifference + " days");
				if (daysDifference == 0)
				{
					Console.WriteLine("Difference in hours is: " + hoursDifference + " hours");
				}
				else
				{
					Console.WriteLine("Difference in hours is: " + hoursDifference % daysDifference + " hours");
				}

			}
            catch (Exception)
            {
				Console.WriteLine("Error");
            }
		}

		private DateTime setDate()
        {
			int minMonth = 1, maxMonth = 12, minDay = 1, maxDay = 31;

			Console.WriteLine("Enter the year of the date in numerical:");
			int year = Int32.Parse(Console.ReadLine());

			Console.WriteLine("Enter the month of the date:");
			int month = Int32.Parse(Console.ReadLine());

			if(month < minMonth || month > maxMonth)
            {
				Console.WriteLine("Invalid month. Enter a value within the 1-12 range");
				month = Int32.Parse(Console.ReadLine());
			}

			Console.WriteLine("Enter the day of the date:");
			int day = Int32.Parse(Console.ReadLine());

			if (day < minDay || day > maxDay)
			{
				Console.WriteLine("Invalid month. Enter a value within the 1-12 range");
				month = Int32.Parse(Console.ReadLine());
			}			
			
			return new DateTime(year, month, day);

		}

		public string getDayOfWeek()
        {
			DateTime date = setDate();
			return date.ToString("dddd");
        }
	}
}
