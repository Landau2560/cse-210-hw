using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator prompts = new PromptGenerator();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file.");
            Console.WriteLine("5. Quit.");
            Console.WriteLine("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, prompts);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save ( ex: journal.txt)");
                    string saveName = Console.ReadLine();
                    journal.SaveToFile(saveName);
                    Console.WriteLine("Journal saved.");
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadName = Console.ReadLine();
                    journal.LoadFromFile(loadName);
                    Console.WriteLine("Journal saved.");
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;

            }
        }

    }
    private static void WriteNewEntry(Journal journal, PromptGenerator prompts)
    {
        string date = DateTime.Now.ToShortDateString();
        string prompt = prompts.GetRandomPrompt();

        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("Type your response. Press Enter to finish: ");
        Console.Write("> ");
        string response = Console.ReadLine();

        var entry = new Entry
        {
            _date = date,
            _promptText = prompt,
            _response = response
        };

        journal.AddEntry(entry);
        Console.WriteLine("Entry recorded. ");
    }

}