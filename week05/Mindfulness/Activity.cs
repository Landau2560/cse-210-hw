using System;

namespace Mindfulness
{
    public abstract class Activity
    {
        private string _name;
        private string _description;
        private int _durationSeconds;

        protected int DurationSeconds => _durationSeconds;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void Run()
        {
            DisplayStart();
            AskDuration();
            Console.WriteLine("\nGet ready...");
            ShowSpinner(3);
            PerformActivity();
            Console.WriteLine();
            DisplayEnd();
            ShowSpinner(3);
        }

        private void DisplayStart()
        {
            Console.Clear();
            Console.WriteLine($"---{_name} ---\n");
            Console.WriteLine(_description + "\n");
        }

        private void AskDuration()
        {
            int seconds = 0;
            while (true)
            {
                Console.Write("Enter duration in seconds: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out seconds) && seconds > 0)
                {
                    _durationSeconds = seconds;
                    break;
                }
                Console.WriteLine("Please enter a positive number value for seconds. ");
            }
        }
        private void DisplayEnd()
        {
            Console.WriteLine("\nWell done!");
            Console.WriteLine($"You have completed the activity for {DurationSeconds} seconds.");
        }

        protected void ShowSpinner(int seconds)
        {
            char[] spinner = new char[] { '|', '/', '-', '\\' };
            int delay = 200;
            int iterations = Math.Max(1, (seconds * 1000) / delay);

            for (int i = 0; i < iterations; i++)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(delay);
                Console.Write("\b \b");

            }
            Console.WriteLine();
        }
        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                string s = i.ToString();
                Console.Write(s);
                Thread.Sleep(1000);

                for (int j = 0; j < s.Length; j++)
                {
                    Console.Write("\b \b");
                }
            }
        }

        protected abstract void PerformActivity();
    }

}