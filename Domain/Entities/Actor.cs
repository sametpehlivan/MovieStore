namespace Domain.Entities;
public class Actor : Employee 
{
    public Actor(){}
    public Actor(int id, string firstName,string lastName):this()
    {
        Id = id;
        FirstName = firstName;
        LastName = LastName;
    }
   
}