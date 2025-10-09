using System;
using System.Reflection;

namespace EternalQuest
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Eternal Quest!");
            string filename = "goals.txt";

            if (System.IO.File.Exists(filename))
            {
                Console.WriteLine($"Found existing save file '{filename}'. Load it? (Y/N)");
                var c = Console.ReadLine().Trim().ToUpper();
                if (c == "Y") QuestManager.LoadFromFile(filename);
            }

            bool exit = false;
            while (!exit)
            {
                ShowMainMenu();
                string choice = Console.ReadLine().Trim();
                switch (choice)
                {
                    case "1":
                        QuestManager.ShowGoals();
                        break;
                    case "2":
                        CreateNewGoal();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        QuestManager.ShowStatus();
                        break;
                    case "5":
                        QuestManager.SaveToFile(filename);
                        break;
                    case "6":
                        Console.WriteLine("Eneter filename to load from (or press Enter for default 'goals.txt):");
                        string f = Console.ReadLine().Trim();
                        if (string.IsNullOrWhiteSpace(f)) f = filename;
                        QuestManager.LoadFromFile(f);
                        break;
                    case "7":
                        QuestManager.ShowGoals();
                        Console.WriteLine("Which goal number would you like to delete? (or press Enter to cancel)");
                        var input = Console.ReadLine();
                        if (int.TryParse(input, out int gnum) && gnum >= 1 && gnum <= QuestManager.Goals.Count)
                        {
                            QuestManager.RemoveGoalAt(gnum - 1);
                            Console.WriteLine("Goal removed.");
                        }
                        else
                        {
                            Console.WriteLine("Cancelled or invalid number.");
                        }
                        break;
                    case "8":
                        Console.WriteLine("Existing. Would you like to save before you exit? (Y/N)");
                        var save = Console.ReadLine().Trim().ToUpper();
                        if (save == "Y") QuestManager.SaveToFile(filename);
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Unknown choice. Try again.");
                        break;
                }
            }
            Console.WriteLine("Good luck on your Eternal Quest! Goodbye.");
        }
        private static void ShowMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Show Goals");
            Console.WriteLine("2. Create a new goal");
            Console.WriteLine("3. Record an event (complete a goal)");
            Console.WriteLine("4.Show score & badges");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Delete a goal");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Choose an option");
        }

        private static void CreateNewGoal()
        {
            Console.WriteLine("Choose goal type: ");
            Console.WriteLine("1. Simple goal (one-time)");
            Console.WriteLine("2. Eternal goal (repeatable)");
            Console.WriteLine("3. Checklist goal (comeplete & times)");
            Console.Write("Type: ");
            string t = Console.ReadLine().Trim();
            Console.Write("Name: ");
            string name = Console.ReadLine().Trim();
            Console.Write("Description: ");
            string desc = Console.ReadLine().Trim();

            if (t == "1")
            {
                int p = AskInt("Point earned when completed: ", 0, 100000);
                var g = new SimpleGoal(name, desc, p);
                QuestManager.AddGoal(g);
                Console.WriteLine("Simple goal created.");
            }
            else if (t == "2")
            {
                int p = AskInt("Points earned each time: ", 0, 10000);
                var g = new EternalGoal(name, desc, p);
                QuestManager.AddGoal(g);
                Console.WriteLine("Eternal goal created.");
            }
            else if (t == "3")
            {
                int p = AskInt("Points earned each time: ", 0, 10000);
                int target = AskInt("Target count (how many times to finish): ", 1, 10000);
                int bonus = AskInt("Bonus points awarded upon final final completion: ", 0, 100000);
                var g = new CheckListGoal(name, desc, p, target, bonus);
                QuestManager.AddGoal(g);
                Console.WriteLine("Checklist goal created.");
            }
            else
            {
                Console.WriteLine("Unknown type. Aborting creation.");
            }
        }
        private static void RecordEvent()
        {
            if (QuestManager.Goals.Count == 0)
            {
                Console.WriteLine("No goals to record. Create one first.");
                return;
            }
            QuestManager.ShowGoals();
            Console.WriteLine("Which goal number did you accomplish? (or 0 to cancel)");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int gnum))
            {
                if (gnum == 0) return;
                if (gnum >= 1 && gnum <= QuestManager.Goals.Count)
                {
                    QuestManager.RecordGoal(gnum - 1);
                }
                else
                {
                    Console.WriteLine("Invalid goal number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        private static int AskInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (int.TryParse(s, out int v) && v >= min && v <= max) return v;
                Console.WriteLine($"Please enter an integer between {min} and {max}.");
            }
        }
    }
}