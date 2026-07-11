using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public class GetMealById
{
    public async Task Run()
    {
        using var client = new HttpClient();

        var url = "https://www.themealdb.com/api/json/v1/1/lookup.php?i=52771";

        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Request failed.");
        }

        var body = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(body);

        var meals = doc.RootElement.GetProperty("meals");

        var mealName = meals[0]
            .GetProperty("strMeal")
            .GetString();

        if (string.IsNullOrEmpty(mealName))
        {
            throw new Exception("Meal name not found.");
        }

        Console.WriteLine($"Meal found: {mealName}");
    }
}