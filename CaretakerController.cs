using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace help4u.Controllers
{
    public class CaretakerController : Controller
    {
        [HttpPost]
        public ActionResult Signup(FormCollection form)
        {
            string connectionString = "server=sql11.freesqldatabase.com;user=sql11690812;password=ttccuRbCJR;database=sql11690812";

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Retrieve form data
                    string firstName = form["firstname"];
                    string lastName = form["lastname"];
                    string email = form["email"];
                    string password = form["password"];
                    string languages = form["languages"];
                    string availability = form["availability"];
                    string experience = form["experience"];
                    string phone = form["phone"];
                    string gender = form["gender"];
                    string pets = form["pets"];
                    string smoking = form["smoking"];
                    string ownSmoking = form["own_smoking"];
                    string contactPref = form["contact_preference"];
                    string hobbies = form["hobbies"];
                    string skills = form["skills"];
                    string specificExp = form["specific_experience"];
                    string comments = form["comments"];

                    // Prepare SQL statement to insert data into the database
                    string query = "INSERT INTO caretaker (FirstName, LastName, Email, Password, Languages, Availability, Experience, Phone, Gender, Pets, Smoking, OwnSmoking, ContactPref, Hobbies, Skills, SpecificExp, Comments) VALUES (@FirstName, @LastName, @Email, @Password, @Languages, @Availability, @Experience, @Phone, @Gender, @Pets, @Smoking, @OwnSmoking, @ContactPref, @Hobbies, @Skills, @SpecificExp, @Comments)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        // Bind parameters
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Languages", languages);
                        command.Parameters.AddWithValue("@Availability", availability);
                        command.Parameters.AddWithValue("@Experience", experience);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Pets", pets);
                        command.Parameters.AddWithValue("@Smoking", smoking);
                        command.Parameters.AddWithValue("@OwnSmoking", ownSmoking);
                        command.Parameters.AddWithValue("@ContactPref", contactPref);
                        command.Parameters.AddWithValue("@Hobbies", hobbies);
                        command.Parameters.AddWithValue("@Skills", skills);
                        command.Parameters.AddWithValue("@SpecificExp", specificExp);
                        command.Parameters.AddWithValue("@Comments", comments);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }

                    // Close connection
                    connection.Close();
                }

                return Content("Signup successful");
            }
            catch (MySqlException ex)
            {
                return Content("Error: " + ex.Message);
            }
        }
    }
}