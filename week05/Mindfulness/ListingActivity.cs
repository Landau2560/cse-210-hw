using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>
        {
            "Who are people who appreciate you?",
            "What are personal strengths of yours?",
            "Who did you help this week?",
            "Did you pray today?",
            "Who are some of your personal heroes?"
        };

        private readonly Random _rng = new Random();

        public ListingActivity()
            : base("Listing Activity",
                    "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        { }

        protected override void PerformActivity()
        {
            int pIndex = _rng.Next(_prompts.Count);
            Console.WriteLine(_prompts[pIndex]);

            Console.WriteLine("\nYou may begin in: ");
            ShowCountdown(5);

            Console.WriteLine("\nStart listing items. Press Enter after each one:");

            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);
            var items = new List<string>();

            while (DateTime.Now < end)
            {
                int msRemaining = (int)(end - DateTime.Now).TotalMilliseconds;
                if (msRemaining <= 0) break;

                string entry = ReadLineWithTimeout(msRemaining);
                if (entry == null) break;

                entry = entry.Trim();
                if (!string.IsNullOrEmpty(entry))
                {
                    items.Add(entry);
                }
            }

            Console.WriteLine($"\nYou listed {items.Count} item(s).");
        }

        private string ReadLineWithTimeout(int timeoutms)
        {
            var sb = new StringBuilder();
            DateTime end = DateTime.Now.AddMilliseconds(timeoutms);

            while (DateTime.Now < end)
            {
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        return sb.ToString();
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Length--;
                            Console.Write("\b \b");
                        }
                    }
                    else
                    {
                        sb.Append(key.KeyChar);
                        Console.Write(key.KeyChar);
                    }
                }
                Thread.Sleep(50);
            }
            Console.WriteLine();
            return sb.Length > 0 ? sb.ToString() : null;
        }
    }
}


