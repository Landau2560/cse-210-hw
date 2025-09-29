using System;
using Homework;
class Program
{
    static void Main(string[] args)
    {
        Assignment a = new Assignment(" Samuel Bennett", "Multiplication");
        Console.WriteLine(a.GetSummary());

        Console.WriteLine();

        MathAssignment math = new MathAssignment("Landau Grandberry", "Fractions", "7.3", "8-19");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());

        Console.WriteLine();

        WritingAssignment writing = new WritingAssignment("Josh Waters", "European History", "The Conflict of World War II");
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }
}