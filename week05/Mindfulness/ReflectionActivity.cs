using System;
using System.Diagnostics;

namespace Mindfulness
{
    public class ReflectionActivity : Activity
    {
        private readonly List<string> _prompts = new List<string>
        {
            "Think of a time you stood up for a loved one.",
            "Think of a time you did something really difficult.",
            "Think of a time you helped someone in need.",
            "Think of a time when you did something truely selfless."
        };

        private readonly List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did it feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What did you learn about yourself during this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private readonly Random _rng = new Random();

        public ReflectionActivity()
            : base("Reflection Activity",
                    "This activity will help you reflect on times in your life when you have shown strength and resillience")
        { }

        protected override void PerformActivity()
        {
            var promptIndex = _rng.Next(_prompts.Count);
            Console.WriteLine(_prompts[promptIndex]);

            var questionPool = new List<string>(_questions);

            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);

            while (DateTime.Now < end)
            {
                if (questionPool.Count == 0)
                {
                    questionPool = new List<string>(_questions);
                }
                int qIndex = _rng.Next(questionPool.Count);
                string question = questionPool[qIndex];
                questionPool.RemoveAt(qIndex);

                Console.WriteLine("\n" + question);

                int remainingSecs = (int)(end - DateTime.Now).TotalSeconds;
                int pause = Math.Min(10, Math.Max(1, remainingSecs));
                ShowSpinner(pause);

            }

        }
    }
}