using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using var client = new HttpClient();

        // GET /menu is public — no authentication required.
        using var response = await client.GetAsync("https://api.cafe.redocly.com/menu");
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        Console.WriteLine(body);
    }
}
