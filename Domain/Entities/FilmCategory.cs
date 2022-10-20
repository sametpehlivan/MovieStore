namespace Domain.Entities;
public class FilmCategory : BaseEntity
{
    public int CategoryId {get; set;}
    public int FilmId {get; set;}
    public Film Film {get; set;}
    public Category Category {get; set;}

    public FilmCategory() {}
    public FilmCategory(int id,int filmId,int categoryId): this()
    {   Id = id;
        CategoryId = categoryId;
        FilmId = filmId;
    }
    
}