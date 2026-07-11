using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 4: GET List Categories
// TheMealDB API: https://themealdb.com/api/json/v1/1/categories.php

public static class GetCategories
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        var url = "https://themealdb.com/api/json/v1/1/categories.php";

        var response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("Expected status code 200 OK.");
        }

        var body = await response.Content.ReadAsStringAsync();

        using JsonDocument doc = JsonDocument.Parse(body);

        var categories = doc.RootElement.GetProperty("categories");

        if (categories.GetArrayLength() <= 0)
        {
            throw new Exception("No categories found.");
        }

        Console.WriteLine("Categories fetched successfully.");
    }
}