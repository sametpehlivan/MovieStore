namespace Domain.Entities;
public class Employee : Person
{
    public List<FilmEmployee> FilmEmployees {get; set;}
    public Employee(){}
    
    public Employee(int id, string firstName,string lastName):this()
    {
        Id = id;
        FirstName = firstName;
        LastName = LastName;
    }
    

}