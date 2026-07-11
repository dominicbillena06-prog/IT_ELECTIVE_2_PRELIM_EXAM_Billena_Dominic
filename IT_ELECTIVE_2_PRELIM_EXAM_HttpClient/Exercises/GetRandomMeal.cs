using System.Net;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public class GetRandomMeal
{
    public async Task Run()
    {
        using var client = new HttpClient();

        var url = "https://www.themealdb.com/api/json/v1/1/random.php";

        var response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("Request failed.");
        }

        var body = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(body))
        {
            throw new Exception("Response body is empty.");
        }

        Console.WriteLine("Random meal fetched successfully.");
    }
}