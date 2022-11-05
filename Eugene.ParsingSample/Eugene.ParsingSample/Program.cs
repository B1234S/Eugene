using HtmlAgilityPack;

namespace Eugene.ParsingSample.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var htmlString = @"<strong>bold</strong> and some <i>italic</i> and a <a href=""https://google.com"">link</a>";

            if (!string.IsNullOrEmpty(htmlString))
            {
                HtmlDocument htmlDocument = new HtmlDocument
                {
                    // There are various options, set as needed
                    OptionFixNestedTags = true
                };

                htmlDocument.LoadHtml(htmlString);

                if (htmlDocument.ParseErrors == null || !htmlDocument.ParseErrors.Any())
                {
                    if (htmlDocument.DocumentNode != null)
                    {
                        var nbr = htmlDocument.DocumentNode.ChildNodes.Count;

                        var lst = htmlDocument.DocumentNode.ChildNodes.ToList();

                        foreach (var node in lst)
                        {
                            // Do something with nodes
                        }

                        // InnerHtml 
                        var innerHtml = htmlDocument.DocumentNode.InnerHtml;

                        // InnerText 
                        var innerText = htmlDocument.DocumentNode.InnerText;

                        // OuterHtml
                        var outerHtml = htmlDocument.DocumentNode.OuterHtml;

                        // Descendants 
                        var descendants = htmlDocument.DocumentNode.Descendants("a");

                        foreach (HtmlNode anchor in htmlDocument.DocumentNode.SelectNodes("//a"))
                        {
                            var link = anchor.GetAttributeValue("href", "");
                        }
                    }
                }
                else
                {
                    // Handle any parse errors as required
                }
            }

            Console.ReadKey();
        }
    }
}