using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public class SearchMealByName
{
    public async Task Run()
    {
        using var client = new HttpClient();

        var url = "https://www.themealdb.com/api/json/v1/1/search.php?s=Arrabiata";

        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Request failed.");
        }

        var body = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(body);

        var meals = doc.RootElement.GetProperty("meals");

        if (meals.GetArrayLength() < 1)
        {
            throw new Exception("No meals found.");
        }

        Console.WriteLine("Meal search successful.");
    }
}