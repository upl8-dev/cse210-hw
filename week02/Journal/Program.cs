// In the event the user types an incorrect number or letter while selecting 1-5, the program will exclaim "invalid entry" and run the program again.

using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Please type a number option.");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Display all Entries");
            Console.WriteLine("3. Save to File");
            Console.WriteLine("4. Load from File");
            Console.WriteLine("5. Quit");
            Console.WriteLine("----------");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.Write("Prompt: ");
                Console.WriteLine(prompt);
                Console.Write(" > ");
                string response = Console.ReadLine();

                // Entry[Class Name] userEntry[Variable Name] = new[Creates new object] Entry()[Calls Entry Class];
                // Simple meaning: Create a new blank journal entry and call it userEntry.
                Entry userEntry = new Entry();
                
                DateTime currentTime = DateTime.Now;
                string dateText = currentTime.ToShortDateString();
                userEntry._date = dateText;
                userEntry._promptText = prompt;
                userEntry._entryText = response;
                theJournal.AddEntry(userEntry);
            }
            else if (choice == "2")
            {
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What filename would you like to save to? ");
                string filename = Console.ReadLine();

                theJournal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Which filename would you like to load from? ");
                string filename = Console.ReadLine();

                theJournal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Until Next Time!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose a number 1-5.");
            }
            Console.WriteLine();
        }
    }
}