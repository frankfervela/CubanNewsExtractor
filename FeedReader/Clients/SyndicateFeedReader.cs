using System.ServiceModel.Syndication;
using System.Xml;

namespace FeedReader.Clients;

public class SyndicateFeedReader
{
    private string _url { get; set; }
    
    public SyndicateFeedReader(string url)
    {
        _url = url;
    }

    public SyndicationFeed? ExtractFeedItems()
    {
        using var reader = XmlReader.Create(_url);
        var feed = SyndicationFeed.Load(reader);
        reader.Close();
        return feed;
    }
}