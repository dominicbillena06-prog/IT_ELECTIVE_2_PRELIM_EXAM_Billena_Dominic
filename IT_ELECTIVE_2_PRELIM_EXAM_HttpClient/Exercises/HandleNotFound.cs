using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 9: GET Handle 404 Not Found
// TheMealDB API: https://themealdb.com/api/json/v1/1/lookup.php?i={id}

public static class HandleNotFound
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        var url = "https://themealdb.com/api/json/v1/1/lookup.php?i=999999";

        var response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("Expected status code 200 OK.");
        }

        var body = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(body);

        var meals = doc.RootElement.GetProperty("meals");

        if (meals.ValueKind != JsonValueKind.Null)
        {
            throw new Exception("Expected meals to be null.");
        }

        Console.WriteLine("Not found response handled correctly.");
    }
}