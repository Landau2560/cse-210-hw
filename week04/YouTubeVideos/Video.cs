using System;
using System.Runtime.CompilerServices;
using System.Transactions;

public class Video
{
    private string _title;
    private string _author;
    private int _lengthSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
        _comments = new List<Comment>();
    }
    public string Title { get => _title; set => _title = value; }
    public string Author { get => _author; set => _author = value; }
    public int LengthSeconds { get => _lengthSeconds; set => _lengthSeconds = value; }

    public void AddComment(Comment comment)
    {
        if (comment != null)
            _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public IReadOnlyList<Comment> GetComments()
    {
        return _comments.AsReadOnly();
    }

    public string GetFormattedLength()
    {
        var ts = TimeSpan.FromSeconds(_lengthSeconds);
        if (ts.Hours > 0)
            return $"{ts.Hours}:{ts.Minutes:D2}:{ts.Seconds:D2}";
        return $"{ts.Minutes}:{ts.Minutes:D2}";
    }
}