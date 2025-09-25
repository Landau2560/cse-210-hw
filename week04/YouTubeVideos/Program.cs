using System;
using System.Reflection.PortableExecutable;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        var videos = new List<Video>();

        var v1 = new Video("How to tie a Bowtie", "Gentleman's Guide", 185);
        v1.AddComment(new Comment("John", "Great Explination!"));
        v1.AddComment(new Comment("Bob", "Tried it and it worked great"));
        v1.AddComment(new Comment("Dylan", "Great video"));
        videos.Add(v1);

        var v2 = new Video("6 Ingrident Dinner Idea", "Cooking Guy", 310);
        v2.AddComment(new Comment("Dave", "Saved me a lot of time and money!"));
        v2.AddComment(new Comment("Eve", "Short and helpful"));
        v2.AddComment(new Comment("Frank", "It was very delicious"));
        v2.AddComment(new Comment("Terry", "I made this for dinner tonight!"));
        videos.Add(v2);

        var v3 = new Video("5-Minute Piano Lesson:C Major", "Keys From Josh", 640);
        v3.AddComment(new Comment("Hank", "Thank you so much"));
        v3.AddComment(new Comment("Evelyn", "This helped so much!"));
        v3.AddComment(new Comment("Mark", "Thanks, Im getting better."));
        videos.Add(v2);

        foreach (var vid in videos)
        {
            Console.WriteLine("Title: " + vid.Title);
            Console.WriteLine("Author: " + vid.Author);
            Console.WriteLine("Legnth: " + vid.GetFormattedLength() + $"({vid.LengthSeconds} seconds)");
            Console.WriteLine("Number of comments: " + vid.GetCommentCount());
            Console.WriteLine("Comments:");
            foreach (var c in vid.GetComments())
            {
                Console.WriteLine(" -" + c.ToString());
            }
            Console.WriteLine(new string('_', 50));
        }
    }
}