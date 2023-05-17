using HtmlAgilityPack;

namespace FeedReader;

public class HtmlExtractorClient
{
    public HtmlWeb web { get; set; }
    
    public HtmlExtractorClient()
    {
        web = new HtmlWeb();
    }
    
    public List<string> ExtractArticleContent(string articleUrl)
    {
        var htmlDoc = web.Load(articleUrl);
        var articleNode = htmlDoc.DocumentNode.SelectSingleNode("//article/div[@class='story-body-textt story-content']");

        if (articleNode == null) return new List<string>();
        
        var paragraphNodes = articleNode.SelectNodes(".//p");

        if (paragraphNodes == null) return new List<string>();
        
        return paragraphNodes.Select(pNode => pNode.InnerText).ToList();
    }
}