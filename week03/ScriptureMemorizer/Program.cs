// Added functionality in Scripture.cs to only hide words that are still visible to the user, thus preventing the user from hitting Enter more times than necessary.

using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Alma", 37, 6, 6);

        Scripture scripture = new Scripture(
            reference,
            "Now ye may suppose that this is foolishness in me but behold I say unto you that by small and simple things are great things brought to pass and small means in many instances doth confound the wise"
        );

        string userInput = "";

        while (userInput != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");

            userInput = Console.ReadLine();

            if (userInput != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}