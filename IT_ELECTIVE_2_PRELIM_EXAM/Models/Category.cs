namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

public class Category
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

 
    public Category()
    {
        Name = "";
        Description = "";
    }


    public Category(string name, string description)
    {
    }

    public override string ToString()
    {
        return $"Category: {Name} - {Description}";
    }
}