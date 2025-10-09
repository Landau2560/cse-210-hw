using System;
using System.Runtime.InteropServices.Marshalling;

namespace EternalQuest
{
    public class CheckListGoal : Goal
    {
        private int _timesRecorded;
        private int _targetCount;
        private int _bonusOnCompletion;

        public CheckListGoal(string name, string description, int pointsOnRecord, int targetCount, int bonusOnCompletion)
            : base(name, description, pointsOnRecord)
        {
            _timesRecorded = 0;
            _targetCount = Math.Max(1, targetCount);
            _bonusOnCompletion = Math.Max(0, bonusOnCompletion);
        }

        public override int RecordEvent()
        {
            if (IsComplete())
            {
                Console.WriteLine($"Checklist goal '{Name}' already achieved.");
                return 0;
            }

            _timesRecorded++;
            int point = PointsOnRecord;
            if (_timesRecorded >= _targetCount) point += _bonusOnCompletion;
            return point;
        }

        public override bool IsComplete() => _timesRecorded >= _targetCount;

        public int Timesrecorded => _timesRecorded;
        public int targetCount => _targetCount;
        public int Bonus => -_bonusOnCompletion;

        public override string DisplayStatus()
        {
            return $"Completed {_timesRecorded}/{_targetCount} {(IsComplete() ? "(Done)" : "")}";
        }

        public override string GetStringRepresentation()
        {
            return $"Checklist|{Escape(Name)}|{Escape(Name)}|{Escape(Description)}|{PointsOnRecord}|{_timesRecorded}|{_targetCount}|{_bonusOnCompletion}";

        }

        internal void SetTimesRecorded(int times)
        {
            _timesRecorded = Math.Max(0, times);
        }
        private string Escape(string s) => s.Replace("|", "/PIPE/");
    }
}