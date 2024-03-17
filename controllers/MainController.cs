using System;
using System.Collections.Generic;
using System.Configuration; // Add this namespace for ConfigurationManager
using System.Data;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace help4u.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            List<string> dataFromDatabase = GetDataFromDatabase();
            return View(dataFromDatabase);
        }

        // Method to retrieve data from the database
        private List<string> GetDataFromDatabase()
        {
            List<string> result = new List<string>();

            string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to MySQL database!");

                    // Perform database operations here
                    string sqlQuery = "SELECT * FROM your_table";
                    MySqlCommand command = new MySqlCommand(sqlQuery, connection);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string data = reader["column_name"].ToString(); // Adjust column_name as per your database schema
                            result.Add(data);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return result;
        }
    }
}
