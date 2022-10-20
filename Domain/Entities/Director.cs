namespace Domain.Entities;
public class Director : Employee 
{
    public Director(){}
    public Director(int id, string firstName,string lastName):this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
   
}