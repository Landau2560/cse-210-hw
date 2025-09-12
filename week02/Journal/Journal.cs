using System;
using System.Collections.Generic;
using System.IO;


public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry e)
    {
        if (e != null) _entries.Add(e);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("(No entries yet.)");
            return;
        }
        foreach (var e in _entries)
        {
            e.Display();
        }
    }
    public void SaveToFile(string filename)
    {
        using (var sw = new StreamWriter(filename))
        {
            foreach (var e in _entries)
            {
                sw.WriteLine(e.ToStorage());
            }
        }
    }
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }
        string[] lines = File.ReadAllLines(filename);
        _entries.Clear();

        foreach (string line in lines)
        {
            var e = Entry.FromStorage(line);
            if (e != null) _entries.Add(e);
        }
    }
}