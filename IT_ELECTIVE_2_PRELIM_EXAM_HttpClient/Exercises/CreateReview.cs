using System.Net;
using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 6: POST Create Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts

public static class CreateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        var url = "https://jsonplaceholder.typicode.com/posts";

        var json = """
        {
            "title": "Great Pasta!",
            "body": "Loved this recipe",
            "userId": 1
        }
        """;

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

        var responseBody = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(responseBody);

        if (!doc.RootElement.TryGetProperty("id", out var id))
        {
            throw new Exception("Response does not contain an id field.");
        }

        Console.WriteLine($"Review created successfully. ID: {id}");
    }
}