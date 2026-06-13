using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                RecordEvent();
            }
            else if (choice == "4")
            {
                SaveGoals();
            }
            else if (choice == "5")
            {
                LoadGoals();
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points.");
    }

    private void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (goalType == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (goalType == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    private void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            _score += pointsEarned;

            Console.WriteLine($"Congratulations! You earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] mainParts = lines[i].Split(":");
            string goalType = mainParts[0];
            string[] goalParts = mainParts[1].Split("|");

            string name = goalParts[0];
            string description = goalParts[1];
            int points = int.Parse(goalParts[2]);

            if (goalType == "SimpleGoal")
            {
                bool isComplete = bool.Parse(goalParts[3]);
                _goals.Add(new SimpleGoal(name, description, points, isComplete));
            }
            else if (goalType == "EternalGoal")
            {
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (goalType == "ChecklistGoal")
            {
                int amountCompleted = int.Parse(goalParts[3]);
                int target = int.Parse(goalParts[4]);
                int bonus = int.Parse(goalParts[5]);

                _goals.Add(new ChecklistGoal(name, description, points, amountCompleted, target, bonus));
            }
        }

        Console.WriteLine("Goals loaded.");
    }
}