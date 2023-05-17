// See https://aka.ms/new-console-template for more information

using FeedReader;

var granmaClient = new GranmaRSSClient(URLs.GRANMA);


foreach (var items in granmaClient.GranmaArticles)
{
    Console.WriteLine($"\n\nTitulo         : { items.Subject }\n" +
                      $"Published Date : { items.DatePublished:d}\n" +
                      $"Tags used:     : { string.Join(", ", items.TagsUsed) }\n" +
                      $"Resumen        : { items.Summary }\n" +
                      $"Links          : { items.articleUrl }\n" +
                      $"Content        \n{ string.Join("\n",items.articleContent) }");
}


/*using System.Xml;
using System.ServiceModel.Syndication;
using HtmlAgilityPack;

const string url = "https://www.granma.cu/feed";
using var reader = XmlReader.Create(url);
var feed = SyndicationFeed.Load(reader);
reader.Close();
foreach (var item in feed.Items)
{
    var subject = item.Title.Text;
    var summary = item.Summary.Text.Replace("<p>", "").Replace("</p>", "");
    var category = item.Categories.Select(x => x.Name).FirstOrDefault();
    var publishedDate = item.PublishDate;
    var tagsUsed = item.Categories.Select(x => x.Name).ToList();
    var linkToPost = item.Links.Select(x => x.Uri.AbsoluteUri).ToList();
    var articleContent = new List<string>();
    
    var web = new HtmlWeb();
    var htmlDoc = web.Load(linkToPost.First());
    
    var articleNode = htmlDoc.DocumentNode.SelectSingleNode("//article/div[@class='story-body-textt story-content']");

    if (articleNode != null)
    {
        var paragraphNodes = articleNode.SelectNodes(".//p");

        if (paragraphNodes != null)
        {
            articleContent.AddRange(paragraphNodes.Select(pNode => pNode.InnerText));
        }
    }

    Console.WriteLine($"\n\nTitulo         : { subject }\n" +
                      $"Category       : { category }\n" +
                      $"Published Date : { publishedDate:d}\n" +
                      $"Tags used:     : { string.Join(", ", tagsUsed) }\n" +
                      $"Resumen        : { summary }\n" +
                      $"Links          : { linkToPost.First() }\n" +
                      $"Content        \n{ string.Join("\n",articleContent) }");

}*/

