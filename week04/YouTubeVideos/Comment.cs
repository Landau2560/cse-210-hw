public class Comment
{
    private string _author;
    private string _text;

    public Comment(string author, string text)
    {
        _author = author;
        _text = text;
    }

    public string Author { get => _author; set => _author = value; }
    public string Text { get => _text; set => _text = value; }

    public override string ToString()
    {
        return $"{Author}: {Text}";
    }
}