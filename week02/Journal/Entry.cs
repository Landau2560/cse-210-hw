using System;


public class Entry
{

    public string _date = "";
    public string _promptText = "";
    public string _response = "";

    public void Display()
    {
        Console.WriteLine($"Date:  {_date}");
        Console.WriteLine($"Prompt:  {_promptText}");
        Console.WriteLine($"Response:{Environment.NewLine}{_response}");
        Console.WriteLine(new string('-', 40));
    }

    private const string Sep = "~|~";

    public string ToStorage()
    {
        return $"{_date}{Sep}{_promptText}{Sep}{_response}";
    }

    public static Entry FromStorage (string line)
    {
        var parts = line.Split(Sep);
        if (parts.Length != 3)
        {
            return null;
        }

        return new Entry
        {
            _date = parts[0],
            _promptText = parts[1],
            _response = parts[2]
        };
        
    }
}