using System;
using System.Drawing;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _completed;

        public SimpleGoal(string name, string description, int pointsOnRecord)
            : base(name, description, pointsOnRecord)
        {
            _completed = false;
        }

        public override int RecordEvent()
        {
            if (_completed)
            {
                Console.WriteLine($"Goal '{Name}' already completed.");
                return 0;
            }
            _completed = true;
            return PointsOnRecord;
        }

        public override bool IsComplete() => _completed;

        public override string DisplayStatus() => IsComplete() ? "[X]" : "[ ]";

        public override string GetStringRepresentation()
        {
            return $"Simple|{Escape(Name)}|{Escape(Description)}|{PointsOnRecord}|{(_completed ? 1 : 0)}";
        }

        internal void SetCompleted(bool completed)
        {
            _completed = completed;
        }

        private string Escape(string s) => s.Replace("|", "/PIPE/");
    }
}