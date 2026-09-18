using HtmlAgilityPack;

using var client = new HttpClient();

try
{
    var url = "https://techcrunch.com";
    var html = await client.GetStringAsync(url);   
    Console.WriteLine($"{url} has been downloaded!");
    
    var doc = new HtmlDocument();
    doc.LoadHtml(html);

    var node = doc.DocumentNode.SelectNodes("//div[@data-custom-module='Latest News']//h3//a[@class='loop-card__title-link']");
    
    int i = 0;
    foreach (var item in node!)
    {
        i++;
        Console.WriteLine( $"[{i}]" + "---> " + item.InnerText);
    }
} 
catch(HttpRequestException ex)
{
    System.Console.WriteLine("Sorry!");
    Console.WriteLine(ex.Message);
}

