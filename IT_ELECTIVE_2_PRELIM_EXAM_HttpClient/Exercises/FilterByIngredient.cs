using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 5: GET Filter by Ingredient
// TheMealDB API: https://themealdb.com/api/json/v1/1/filter.php?i={ingredient}

public static class FilterByIngredient
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        var url = "https://themealdb.com/api/json/v1/1/filter.php?i=chicken_breast";

        var response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("Expected status code 200 OK.");
        }

        var body = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(body);

        var meals = doc.RootElement.GetProperty("meals");

        if (meals.ValueKind == JsonValueKind.Null || meals.GetArrayLength() < 1)
        {
            throw new Exception("No meals found for this ingredient.");
        }

        Console.WriteLine("Ingredient filter successful.");
    }
}