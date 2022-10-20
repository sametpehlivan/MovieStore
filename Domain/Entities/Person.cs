namespace Domain.Entities;
public class Person : BaseEntity
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public Person() {}
    public  Person(int id,string firstName, string lastName):this()
    {
        Id = id; 
        FirstName = firstName;
        LastName = lastName ; 
    }
}
