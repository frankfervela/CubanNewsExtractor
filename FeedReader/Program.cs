// See https://aka.ms/new-console-template for more information

using FeedReader;
using FeedReader.Clients;
using FeedReader.Constants;

var granmaClient = new GranmaRssClient(URLs.GRANMA);


foreach (var items in granmaClient.GranmaArticles)
{
    Console.WriteLine($"\n\nTitulo         : { items.Subject }\n" +
                      $"Published Date : { items.DatePublished:d}\n" +
                      $"Tags used:     : { string.Join(", ", items.TagsUsed) }\n" +
                      $"Resumen        : { items.Summary }\n" +
                      $"Links          : { items.articleUrl }\n" +
                      $"Content        \n{ string.Join("\n",items.articleContent) }");
}
