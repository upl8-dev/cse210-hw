using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("Please enter your grade number: ");
        string userGrade = Console.ReadLine();
        int gradePercent = int.Parse(userGrade);
        string letter = "";

        if (gradePercent <= 100 && gradePercent >= 90)
        {
            letter = "A";
        }
        else if (gradePercent <= 89 && gradePercent >= 80)
        {
            letter = "B";
        }
        else if (gradePercent <= 79 && gradePercent >= 70)
        {
            letter = "C";
        }
        else if (gradePercent <= 69 && gradePercent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.Write($"Your grade is: {letter}");

        if (gradePercent >= 70)
        {
            Console.WriteLine("\nCongratulations! You passed!");            
        }
        else
        {
            Console.WriteLine("\nI'm sorry. You did not pass. Better luck next time.");
        }                                 
    }
}