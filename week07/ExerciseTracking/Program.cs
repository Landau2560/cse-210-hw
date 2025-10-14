using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        var running = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        var cycling = new Cycling(new DateTime(2022, 11, 3), 45, 12.0);
        var swimming = new Swimming(new DateTime(2022, 11, 3), 60, 40);

        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}