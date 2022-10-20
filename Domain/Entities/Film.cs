namespace Domain.Entities;
public class Film : BaseEntity
{
    public string Name {get; set;}
    public Film() {}
    public Film(int id,string name):this()
    {
        Id = id;
        Name = name;
    }
    
}