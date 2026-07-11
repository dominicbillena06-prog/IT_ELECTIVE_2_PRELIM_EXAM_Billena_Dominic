using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public class GetCategories
{
    public async Task Run()
    {
        using var client = new HttpClient();

        var url = "https://www.themealdb.com/api/json/v1/1/categories.php";

        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Request failed.");
        }

        var body = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(body);

        var categories = doc.RootElement.GetProperty("categories");

        if (categories.GetArrayLength() < 1)
        {
            throw new Exception("No categories found.");
        }

        Console.WriteLine("Categories fetched successfully.");
    }
}