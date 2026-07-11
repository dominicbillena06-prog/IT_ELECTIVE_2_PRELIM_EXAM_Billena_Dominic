using System.Net;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 8: DELETE Remove Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts/{id}

public static class DeleteReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        var url = "https://jsonplaceholder.typicode.com/posts/1";

        var response = await client.DeleteAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("Expected status code 200 OK.");
        }

        Console.WriteLine("Review deleted successfully.");
    }
}