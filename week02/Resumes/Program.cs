using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");

        Job job1 = new Job();
        job1._jobTitle = "Software Development";
        job1._company = "Apple";
        job1._startYear = 2020;
        job1._endYear = 2022;

        Job job2 = new Job();
        job1._jobTitle = "Manager";
        job1._company = "Google";
        job1._startYear = 2023;
        job1._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "Landau Grandberry";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();





    }
}     