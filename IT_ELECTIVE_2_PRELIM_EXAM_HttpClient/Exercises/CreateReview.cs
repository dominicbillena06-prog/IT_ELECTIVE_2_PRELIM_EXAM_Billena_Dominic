using System.Net;
using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 6: POST Create Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts

public static class CreateReview
{
    public static async Task Run(HttpClient client)
    {
        var url = "https://jsonplaceholder.typicode.com/posts";

        var review = new
        {
            title = "Great Recipe",
            body = "This meal was delicious.",
            userId = 1
        };

        var json = JsonSerializer.Serialize(review);

        var content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json"
        );

        var response = await client.PostAsync(url, content);

        if (response.StatusCode != HttpStatusCode.Created)
        {
            throw new Exception("Expected status code 201 Created.");
        }

        var body = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(body);

        if (!doc.RootElement.TryGetProperty("id", out _))
        {
            throw new Exception("Response does not contain id field.");
        }

        Console.WriteLine("Review created successfully.");
    }
}