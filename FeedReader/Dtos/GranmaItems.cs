namespace FeedReader.Dtos;

public class GranmaItems
{
    public string? Subject { get; set; }
    public string? Summary { get; set; }
    public List<string>? TagsUsed { get; set; }
    public DateTimeOffset? DatePublished { get; set; }
    public string? ArticleUrl { get; set; }
    public List<string>? ArticleContent { get; set; }
}