using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        private string _name;
        private string _description;
        private int _pointsOnRecord;

        protected Goal(string name, string description, int pointsOnRecord)
        {
            _name = name;
            _description = description;
            _pointsOnRecord = pointsOnRecord;
        }
        public string Name => _name;
        public string Description => _description;
        public int PointsOnRecord => _pointsOnRecord;

        public abstract int RecordEvent();

        public abstract bool IsComplete();

        public abstract string DisplayStatus();

        public abstract string GetStringRepresentation();
    }
}