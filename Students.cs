using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

public class StudentsModel : PageModel
{
    private readonly DatabaseHelper _dbHelper; 
    public List<StudentSummaryViewModel> Students { get; set; } = new List<StudentSummaryViewModel>();

   
    public StudentsModel()
    {
         _dbHelper = new DatabaseHelper("localhost", "StudentInfoDB", "root", ""); 
    }


    public void OnGet()
    {
        using (MySqlConnection conn = _dbHelper.GetConnection())
        {
            if (conn == null)
            {
                
                return;
            }

            string query = "SELECT studentId, CONCAT(firstName, ' ', lastName) AS fullName FROM StudentRecordTB";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Students.Add(new StudentSummaryViewModel
                        {
                            StudentId = reader.GetInt32("studentId"),
                            FullName = reader.GetString("fullName")
                        });
                    }
                }
            }
        } 
    }
}