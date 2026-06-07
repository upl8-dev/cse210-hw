// Added Session Tracker. After the user quits, they will see a summary of how many times they completed each activity and total time spent on mindfulness activities.

using System;

class Program
{
    static void Main(string[] args)
    {
        // These variables track the user's current program session.
        // They should be placed before the menu loop starts.
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;
        int totalSeconds = 0;

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();

                // Update the session tracker after the activity finishes.
                breathingCount++;
                totalSeconds += breathingActivity.GetDuration();
            }
            else if (choice == "2")
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.Run();

                // Update the session tracker after the activity finishes.
                reflectingCount++;
                totalSeconds += reflectingActivity.GetDuration();
            }
            else if (choice == "3")
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();

                // Update the session tracker after the activity finishes.
                listingCount++;
                totalSeconds += listingActivity.GetDuration();
            }
            else if (choice == "4")
            {
                Console.Clear();

                int totalActivities = breathingCount + reflectingCount + listingCount;

                Console.WriteLine("Session Summary:");
                Console.WriteLine($"Breathing activities completed: {breathingCount}");
                Console.WriteLine($"Reflecting activities completed: {reflectingCount}");
                Console.WriteLine($"Listing activities completed: {listingCount}");
                Console.WriteLine($"Total activities completed: {totalActivities}");
                Console.WriteLine($"Total mindfulness time: {totalSeconds} seconds");
                Console.WriteLine();
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Press enter to try again.");
                Console.ReadLine();
            }
        }
    }
}