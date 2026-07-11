using System.Net;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 1: GET Random Meal
// TheMealDB API: https://themealdb.com/api/json/v1/1/random.php

public static class GetRandomMeal
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        var url = "https://themealdb.com/api/json/v1/1/random.php";

        var response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("Expected status code 200 OK.");
        }

        var body = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(body))
        {
            throw new Exception("Response body is empty.");
        }

        Console.WriteLine("Random meal fetched successfully.");
    }
}