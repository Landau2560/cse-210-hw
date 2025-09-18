using System;
using System.Runtime.CompilerServices;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var scriptures = new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16),
                    "For God so loved the world, that he gaqve his only begotten Son, that whosoever believth in him should not perish, but have everlasting life."),
                new Scripture(new Reference("Proverbs", 3, 5, 6),
                    "Trust in the lord with all thine heart; and lean not thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
                new Scripture(new Reference("Psalm", 23, 1),
                    "The lord is my shepherd; I shall not want")

            };

            var rnd = new Random();
            var scripture = scriptures[rnd.Next(scriptures.Count)];

            const int HideCountPerStep = 3;



            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());

                if (scripture.IsFullyHidden())
                {
                    Console.WriteLine("\nAll words are hidden. Press Enter to exit.");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine("\nPress Enter to hide more words, or type 'quit' and press Enter to exit.");
                var input = Console.ReadLine()?.Trim().ToLower();
                if (!string.IsNullOrEmpty(input) && input == "quit")
                    break;
                scripture.HideRandomWords(HideCountPerStep);
            }
        }
    }
}