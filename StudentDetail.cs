using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

public class StudentDetailModel : PageModel
{
    private readonly DatabaseHelper _dbHelper;
    public StudentDetailViewModel? Student { get; set; } 
    public bool StudentFound { get; set; } = false; 

   
     public StudentDetailModel()
    {
         _dbHelper = new DatabaseHelper("localhost", "StudentInfoDB", "root", ""); 
    }


 
    public IActionResult OnGet(int? id)
    {
        if (id == null)
        {
            
            return Page(); 

        using (MySqlConnection conn = _dbHelper.GetConnection())
        {
             if (conn == null)
            {
                
                return Page();
            }

          
            string query = @"
                SELECT s.*, c.courseName
                FROM StudentRecordTB s
                INNER JOIN CourseTB c ON s.courseId = c.courseId
                WHERE s.studentId = @studentId"; 

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
               
                cmd.Parameters.AddWithValue("@studentId", id.Value);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) 
                    {
                        Student = new StudentDetailViewModel
                        {
                            StudentId = reader.GetInt32("studentId"),
                            FirstName = reader.GetString("firstName"),
                            LastName = reader.GetString("lastName"),
                            HouseNumber = reader.GetString("houseNumber"),
                            BrgyName = reader.GetString("brgyName"),
                            Municipality = reader.GetString("Municipality"), 
                            Province = reader.GetString("Province"),       
                            Region = reader.GetString("Region"),           
                            Country = reader.GetString("Country"),         
                            StudContactNo = reader.GetString("studContactNo"),
                            EmailAddress = reader.GetString("emailAddress"),
                            GuardianFirstName = reader.GetString("GuardianFirstName"), 
                            GuardianLastName = reader.GetString("GuardianLastName"),   
                            Hobbies = reader.GetString("hobbies"),
                            Nickname = reader.GetString("nickname"),
                            CourseName = reader.GetString("courseName"),
                            YearId = reader.GetInt32("yearId")
                           
                        };
                        StudentFound = true;
                    }
                }
            }
        } 

        return Page(); 
    }
}