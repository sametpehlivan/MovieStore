namespace Domain.Entities;
public class Category : BaseEntity
{
    public string CategoryName { get; set; }
    public List<FilmCategory> FilmsCategories {get; set;}
    public Category() {}
    public Category(int id,string categoryName):this()
    {   Id = id;
        CategoryName = categoryName;
    }

}