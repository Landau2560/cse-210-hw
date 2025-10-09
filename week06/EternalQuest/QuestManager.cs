using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    public static class QuestManager
    {
        private static List<Goal> _goals = new List<Goal>();
        private static int _score = 0;
        private static HashSet<string> _badges = new HashSet<string>();

        private const int LEVEL_XP = 1000;

        public static IReadOnlyList<Goal> Goals => _goals.AsReadOnly();
        public static int Score => _score;
        public static int Level => 1 + (_score / LEVEL_XP);
        public static int XPForNextLevel => LEVEL_XP - (_score % LEVEL_XP);
        public static IEnumerable<string> Badges => _badges;

        public static void AddGoal(Goal g) => _goals.Add(g);

        public static void RemoveGoalAt(int index)
        {
            if (index < 0 || index >= _goals.Count) return;
            _goals.RemoveAt(index);
        }

        public static void RecordGoal(int index)
        {
            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("Invalid goal index.");
                return;
            }
            var goal = _goals[index];
            int gained = goal.RecordEvent();
            if (gained > 0)
            {
                _score += gained;
                Console.WriteLine($"You gained {gained} points! Total score: {_score}");
                CheckForBadges(goal);
            }
            else
            {
                Console.WriteLine("No points gained.");
            }
        }

        private static void CheckForBadges(Goal goal)
        {
            if (_score >= 1) _badges.Add("First Point");

            if (goal is SimpleGoal sg && sg.IsComplete()) _badges.Add("Completed First SimpleGoal");

            _badges.Add($"Level-{Level}");
        }

        public static void ShowStatus()
        {
            Console.WriteLine();
            Console.WriteLine("===Player Status ===");
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine($"Level: {Level} (Need {XPForNextLevel} XP for next level)");
            Console.WriteLine("Basges: " + (_badges.Any() ? string.Join(", ", _badges) : "(none)"));
            Console.WriteLine("=============");
            Console.WriteLine();
        }

        public static void ShowGoals()
        {
            Console.WriteLine();
            Console.WriteLine("=== Goals ===");
            if (_goals.Count == 0) Console.WriteLine("(no goals yet)");
            else
            {
                for (int i = 0; i < _goals.Count; i++)
                {
                    var g = _goals[i];
                    Console.WriteLine($"{i + 1}. {g.DisplayStatus()} {g.Name} - {g.Description}");
                }
            }
            Console.WriteLine("==========");
            Console.WriteLine();
        }
        public static void SaveToFile(string filename)
        {
            using (var writer = new StreamWriter(filename))
            {
                writer.WriteLine($"SCORE|{_score}");
                writer.WriteLine($"BADGES|{string.Join(";", _badges)}");
                foreach (var g in _goals)
                {
                    writer.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Saved to {filename}");

        }
        public static void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File '{filename}' not found. Nothing loaded.");
                return;
            }

            _goals.Clear();
            _badges.Clear();
            _score = 0;

            var lines = File.ReadAllLines(filename);
            foreach (var raw in lines)
            {
                if (string.IsNullOrWhiteSpace(raw)) continue;
                var parts = raw.Split('|');
                if (parts.Length == 0) continue;
                string type = parts[0];

                if (type == "SCORE" && parts.Length >= 2)
                {
                    if (int.TryParse(parts[1], out int s)) _score = s;
                    continue;
                }
                if (type == "BADGES" && parts.Length >= 2)
                {
                    var badges = parts[1].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var b in badges) _badges.Add(b);
                    continue;
                }
                Goal g = CreateGoalFromString(raw);
                if (g != null) _goals.Add(g);
            }
            Console.WriteLine($"Loaded {_goals.Count} goal(s) from {filename}.");
        }

        private static Goal CreateGoalFromString(string line)
        {
            var parts = line.Split('|');
            if (parts.Length == 0) return null;
            string type = parts[0];
            try
            {
                if (type == "Simple" && parts.Length >= 5)
                {
                    string name = Unescape(parts[1]);
                    string desc = Unescape(parts[2]);
                    int points = int.Parse(parts[3]);
                    bool completed = parts[4] == "1";
                    var s = new SimpleGoal(name, desc, points);
                    s.SetCompleted(completed);
                    return s;
                }
                else if (type == "Eternal" && parts.Length >= 5)
                {
                    string name = Unescape(parts[1]);
                    string desc = Unescape(parts[2]);
                    int points = int.Parse(parts[3]);
                    int times = int.Parse(parts[4]);
                    var e = new EternalGoal(name, desc, points);
                    e.SetTimesRecorded(times);
                    return e;
                }
                else if (type == "CheckList" && parts.Length >= 7)
                {
                    string name = Unescape(parts[1]);
                    string desc = Unescape(parts[2]);
                    int pointsPer = int.Parse(parts[3]);
                    int times = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);
                    var c = new CheckListGoal(name, desc, pointsPer, target, bonus);
                    c.SetTimesRecorded(times);
                    return c;
                }
            }
            catch
            {

            }
            return null;
        }
        private static string Unescape(string s) => s.Replace("/PIPE/", "|");
    }
}