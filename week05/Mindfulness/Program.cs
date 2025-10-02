using System;
using System.Diagnostics;
namespace Mindfulness
{

    class Program


    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program\n");
                Console.WriteLine("1) Breathing Activity");
                Console.WriteLine("2) Reflection Activity");
                Console.WriteLine("3) Listing Activity");
                Console.WriteLine("4) Quit");
                Console.WriteLine("\nChoose an activity (1-4): ");

                string choice = Console.ReadLine()?.Trim();
                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice. Try Again");
                        Console.ReadLine();
                        continue;
                }
                activity.Run();

                Console.WriteLine("\nPress Enter to return to the main menu.");
                Console.ReadLine();
            }
        }
    }
}