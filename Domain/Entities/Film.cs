namespace Domain.Entities;
public class Film : BaseEntity
{
    public string FilmName {get; set;}
    public DateTime FilmDate {get; set;}
    public decimal Price {get; set;}
    public List<FilmCategory> FilmsCategories{get; set;}
    public List<FilmEmployee> FilmEmployees{get;set;}
    public bool isDeleted {get; set;}
    public Film() {}

    public Film(int id,string filmName):this()
    {
        Id = id;
        FilmName = filmName;
    }
    
}