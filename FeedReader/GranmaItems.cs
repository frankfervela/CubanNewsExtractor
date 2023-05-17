namespace FeedReader;

public class GranmaItems
{
    public string Subject { get; set; }
    public string Summary { get; set; }
    public List<string> TagsUsed { get; set; }
    public DateTimeOffset DatePublished { get; set; }
    public string articleUrl { get; set; }
    public List<string> articleContent { get; set; }
}