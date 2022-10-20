namespace Domain.Entities;
public class FilmEmployee : Person
{
    public int FilmId {get; set;}
    public int EmployeeId {get; set;}
    public Employee Employee {get; set;}
    public Film Film {get; set;}
    public FilmEmployee(){}
    public FilmEmployee(int filmId,int employeeId):this()
    {
        FilmId = filmId;
        EmployeeId = EmployeeId;
    }
}