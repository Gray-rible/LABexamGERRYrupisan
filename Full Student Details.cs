public class StudentDetailViewModel
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string HouseNumber { get; set; }
    public string BrgyName { get; set; }
    public string Municipality { get; set; }
    public string Province { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
    public string StudContactNo { get; set; }
    public string EmailAddress { get; set; }
    public string GuardianFirstName { get; set; }
    public string GuardianLastName { get; set; }
    public string Hobbies { get; set; }
    public string Nickname { get; set; }
    public string CourseName { get; set; } 
    public int YearId { get; set; } 

  
    public string FullName => $"{FirstName} {LastName}";
    public string FullAddress => $"{HouseNumber}, {BrgyName}, {Municipality}, {Province}, {Region}, {Country}";
     public string FullGuardianName => $"{GuardianFirstName} {GuardianLastName}";
}