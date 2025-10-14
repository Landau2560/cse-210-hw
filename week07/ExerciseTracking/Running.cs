using System;
using System.Diagnostics;

public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / LengthInMinutes) * 60;

    }
    public override double GetPace()
    {
        return LengthInMinutes / _distance;
    }

    public override string GetSummary()
    {
        return $"{Date:dd MMM yyyy} Running ({LengthInMinutes} min) - " +
                $"Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace(): 0.00} min per mile";
    }
}