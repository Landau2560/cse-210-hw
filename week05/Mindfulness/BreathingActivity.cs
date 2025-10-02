using System;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        private readonly int _inhaleSeconds = 4;
        private readonly int _exhaleSeconds = 4;

        public BreathingActivity()
            : base("Breathing Activity",
                    "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind.")
        { }

        protected override void PerformActivity()
        {
            DateTime end = DateTime.Now.AddSeconds(DurationSeconds);

            while (DateTime.Now < end)
            {
                Console.WriteLine("\nBreathe in...");
                int remain = (int)(end - DateTime.Now).TotalSeconds;
                int inhale = Math.Min(_inhaleSeconds, Math.Max(1, remain));
                ShowCountdown(inhale);
                if (DateTime.Now >= end) break;

                Console.WriteLine("\nBreathe Out...");
                remain = (int)(end - DateTime.Now).TotalSeconds;
                int exhale = Math.Min(_exhaleSeconds, Math.Max(1, remain));
                ShowCountdown(exhale);
            }
        }
    }
}