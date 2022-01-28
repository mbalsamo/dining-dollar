using System;

namespace dining_dollars
{
    class Program
    {

        // void dining() {

            
        // }

        static void Main(string[] args)
        {

            const int SEMESTEREND = 124; //may 4th is the 94th day of the year, and last day of finals

            Console.WriteLine("Type one of the following: \n  Dining Dollars\n  Meal Swipes\n  Settings");
            string userInput = Console.ReadLine();


            int currentDayOfYear = DateTime.Today.DayOfYear;
            int daysRemaining = SEMESTEREND - currentDayOfYear;
            double weeksRemaining = daysRemaining/7.0;
            int schoolDaysRemaining = (int)weeksRemaining*5;

            // DINING DOLLARS
            if(userInput.Contains("di") || userInput.Equals("d")) {
                Console.WriteLine("How many dining dollars do you currently have?");
                double currentDollars = double.Parse(Console.ReadLine());

                // calculate: amount you can spend per week 
                //            amount you can spend per day 

                double amtPerWeek = currentDollars/weeksRemaining;
                double amtPerDay = currentDollars/schoolDaysRemaining;

                Console.WriteLine("You can spend " + amtPerWeek + " per week");
                // we aren't going to show this message if they don't have more than $4 per day anyways
                if(amtPerDay > 4)
                    Console.WriteLine("You can spend " + amtPerDay + " per weekday");
            }
            // SWIPES
            else if(userInput.Contains("sw") || userInput.Equals("s")) {
                Console.WriteLine("How many swipes do you currently have?");
                int currentSwipes = int.Parse(Console.ReadLine());

                Console.WriteLine("You can use " + currentSwipes/weeksRemaining + " swipes per week.");


            }
            // SETTINGS
            else if(userInput.Contains("set") || userInput.Equals("se")) {
                Console.WriteLine("Entering settings...");
                Console.WriteLine("  Today is the " + currentDayOfYear + " day of the year.");
                Console.WriteLine("  There are " + daysRemaining + " days remaining in the semester.");
                Console.WriteLine("  There are " + daysRemaining/7.0 + " weeks remaining in the semester.");
                Console.WriteLine("  There are " + schoolDaysRemaining + " week days remaining in the semester.");

            }
            else {
                Console.WriteLine("Could not interpret " + userInput + " as a valid choice. \nPlease use \"dining dollars\", \"swipes\", or \"settings\".");
            }
            



        }
    }
}
