using System;

class Program
{
    public static void Main()
    {
        DateTime today = DateTime.Today;

        DateTime fDate = today.AddDays(100);

        DaysWeek dayInWeek = fDate.DaysWeek;
        string dayInWeekString = dayInWeek.ToString();

        string month = fDate.ToString("MMMM");

        Console.WriteLine("After 100 days from today, day will be: " + dayInWeekString);
        Console.WriteLine("And Month will be: " + month);
    }
}
