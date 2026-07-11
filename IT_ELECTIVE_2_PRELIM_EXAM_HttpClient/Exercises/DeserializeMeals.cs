using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 10: GET Deserialize Multiple Meals
// TheMealDB API: https://themealdb.com/api/json/v1/1/search.php?f=a

public static class DeserializeMeals
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        var url = "https://themealdb.com/api/json/v1/1/search.php?f=a";

        var response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("Expected status code 200 OK.");
        }

        var body = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(body);

        var meals = doc.RootElement.GetProperty("meals");

        if (meals.GetArrayLength() <= 0)
        {
            throw new Exception("No meals found.");
        }

        foreach (var meal in meals.EnumerateArray())
        {
            var mealName = meal
                .GetProperty("strMeal")
                .GetString();

            Console.WriteLine(mealName);
        }

        Console.WriteLine("Meals deserialized successfully.");
    }
}