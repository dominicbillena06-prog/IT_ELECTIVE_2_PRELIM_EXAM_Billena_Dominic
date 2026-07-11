using IT_ELECTIVE_2_PRELIM_EXAM.Models;

namespace IT_ELECTIVE_2_PRELIM_EXAM.Services;

public class RecipeBook
{
    public string Name { get; set; }
    public int Capacity { get; set; }
    private List<Meal> meals;

    public RecipeBook(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        meals = new List<Meal>();
    }

    public RecipeBook(string name)
        : this(name, 10)
    {
    }

    public void AddMeal(Meal meal)
    {
        if (meals.Count < Capacity)
        {
            meals.Add(meal);
        }
    }

    public List<Meal> Search(string term)
    {
        return meals.Where(m =>
            m.Name.Contains(term, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Meal> Search(string term, string category)
    {
        return meals.Where(m =>
            m.Name.Contains(term, StringComparison.OrdinalIgnoreCase) &&
            m.Category.Contains(category, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }

    public List<Meal> Search(int maxPrepTime)
    {
        return meals.ToList();
    }

    public int GetMealCount()
    {
        return meals.Count;
    }

    public List<Meal> GetAllMeals()
    {
        return new List<Meal>(meals);
    }
}