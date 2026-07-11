using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class GetMealById
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        var url = "https://themealdb.com/api/json/v1/1/lookup.php?i=52771";

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
            throw new Exception("Meal not found.");
        }

        var mealName = meals[0]
            .GetProperty("strMeal")
            .GetString();

        if (mealName != "Spicy Arrabiata Penne")
        {
            throw new Exception($"Expected Spicy Arrabiata Penne but got {mealName}.");
        }

        Console.WriteLine("Meal lookup successful.");
    }
}