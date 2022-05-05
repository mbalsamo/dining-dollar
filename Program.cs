using System;

namespace dining_dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            const int SEMESTER_END = 124; // May 4th is the last day of finals, and the 124th day of the year

            Console.WriteLine("Type one of the following: \n  Dining Dollars\n  Meal Swipes\n  Info");
            string userInput = Console.ReadLine().ToLower();

            int currentDayOfYear = DateTime.Today.DayOfYear;
            int daysRemaining = SEMESTER_END - currentDayOfYear;
            double weeksRemaining = daysRemaining/7.0;
            int schoolDaysRemaining = (int)weeksRemaining*5; // Currently causes issue: integer will truncate decimal on weeksRemaining...  

            if(currentDayOfYear >= SEMESTER_END) {
                Console.WriteLine("\nError, today's date is after the end of the semester. Values will be inaccurate. \nPress enter to continue anyway...");
                Console.ReadLine();
            }

            // PARSE DINING DOLLARS
            // specifically checks if input includes "di" so that a typo would still work. It shouldn't mess up our other options
            if(userInput.Contains("di") || userInput.Equals("d")) {
                Console.WriteLine("How many dining dollars do you currently have?");
                double currentDollars = double.Parse(Console.ReadLine());

                // calculate: amount you can spend per week 
                //            amount you can spend per day (but only show if it is applicable)

                double amtPerWeek = currentDollars/weeksRemaining;
                double amtPerDay = currentDollars/schoolDaysRemaining;

                Console.WriteLine("You can spend " + Math.Round(amtPerWeek, 2) + " per week");
                // we aren't going to show this message if they don't have more than $4 per day anyways
                if(amtPerDay > 4)
                    Console.WriteLine("You can spend " + Math.Round(amtPerDay, 2) + " per weekday");
            }
            // PARSE SWIPES
            else if(userInput.Contains("sw") || userInput.Equals("s")) {
                Console.WriteLine("How many swipes do you currently have?");
                int currentSwipes = int.Parse(Console.ReadLine());

                Console.WriteLine("You can use " + Math.Round(currentSwipes/weeksRemaining, 1) + " swipes per week.");
            }
            // INFO
            else if(userInput.Contains("inf") || userInput.Equals("i")) {
                Console.WriteLine("Displaying info...");
                Console.WriteLine("  Today is the " + currentDayOfYear + " day of the year.");
                Console.WriteLine("  There are " + daysRemaining + " days remaining in the semester.");
                Console.WriteLine("  There are " + Math.Round(daysRemaining/7.0, 1) + " weeks remaining in the semester.");
                Console.WriteLine("  There are " + schoolDaysRemaining + " week days remaining in the semester.");
            }
            else {
                Console.WriteLine("Could not interpret " + userInput + " as a valid choice. \nPlease use \"dining dollars\", \"swipes\", or \"settings\".");
            }
            
        }
    }
}
