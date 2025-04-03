using MySql.Data.MySqlClient;
using System;

public class DatabaseHelper
{
    private string connectionString;

    public DatabaseHelper(string server, string database, string user, string password)
    {
        
        connectionString = $"Server={server};Database={database};User ID={user};Password={password};";
    }

    public MySqlConnection GetConnection()
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            Console.WriteLine("Connection Successful!");
            return connection;
        }
        catch (MySqlException ex)
        {
          
            Console.WriteLine($"Connection failed: {ex.Message}");
           
            return null;
        }
    }

   
}