using System.ServiceModel.Syndication;
using FeedReader.Dtos;

namespace FeedReader.Clients;

public class GranmaRssClient
{
    public List<GranmaItems> GranmaArticles { get;} = new();
    private HtmlExtractorClient HtmlExtractorClient { get; }
    
    public GranmaRssClient(string url)
    {
        HtmlExtractorClient = new HtmlExtractorClient();
        var feedReader = new SyndicateFeedReader(url);
        var rssFeed = feedReader.ExtractFeedItems();
        ExtractGranmaItems(rssFeed?.Items);
    }

    private void ExtractGranmaItems(IEnumerable<SyndicationItem>? syndicationItems)
    {
        if (syndicationItems == null) return;

        foreach (var rssItem in syndicationItems)
        {
            GranmaArticles.Add(new GranmaItems
            {
                Subject = rssItem.Title.Text,
                Summary = rssItem.Summary.Text.Replace("<p>", "").Replace("</p>", ""),
                TagsUsed = rssItem.Categories.Select(x => x.Name).ToList(),
                DatePublished = rssItem.PublishDate,
                articleUrl = rssItem.Links.Select(x => x.Uri.AbsoluteUri).First(),
                articleContent = ExtractArticleContent(rssItem.Links.Select(x => x.Uri.AbsoluteUri).First())
            });
        }
    }

    private List<string> ExtractArticleContent(string articleUrl)
    {
        return HtmlExtractorClient.ExtractArticleContent(articleUrl);
    }
}