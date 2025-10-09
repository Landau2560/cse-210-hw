using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        private int _timesRecorded;

        public EternalGoal(string name, string description, int pointsOnRecord)
        : base(name, description, pointsOnRecord)
        {
            _timesRecorded = 0;
        }

        public override int RecordEvent()
        {
            _timesRecorded++;
            return PointsOnRecord;
        }

        public override bool IsComplete() => false;

        public int Timesrecorded => _timesRecorded;

        public override string DisplayStatus() => $"(Eternal) Recorded {_timesRecorded} time(s)";

        public override string GetStringRepresentation()
        {
            return $"Eternal|{Escape(Name)}|{Escape(Description)}|{PointsOnRecord}|{_timesRecorded}";
        }

        internal void SetTimesRecorded(int times)
        {
            _timesRecorded = Math.Max(0, times);
        }

        private string Escape(string s) => s.Replace("|", "/PIPE");
    }
}