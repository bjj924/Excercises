using EntityFrameworkCodeFirstAPP.Models;
using System;
using System.Data.SqlClient;
using System.Configuration;

Console.WriteLine("Connection to a DB");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("But first let me add a app.config file for this Console Application");
Console.WriteLine("Right click on the project and then select Aplication Configuration File then add");
Console.WriteLine("Then we add to the app.config a app setting:");
Console.WriteLine("");
Console.WriteLine("   < appSettings >");

Console.WriteLine("          < add key = "+"dbConnection"+" value = "+"Server=localhost; Database=EFCode_DB; Integrated Security=true; Trusted_Connection=true"+" />");
Console.WriteLine("    </ appSettings >\"");
Console.WriteLine("");
Console.WriteLine("Add the namespace System.Configuration, for this we need the package System.Configuration.ConfigurationManager");
Console.WriteLine("Then Adding this line, we can have the value of the connection string: ConfigurationSettings.AppSettings[\"dbConnection\"]");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("We have 5 different forms to do it");
Console.WriteLine("-----------------------------------");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Using Data Sources");
Console.WriteLine("For Data Sources it can be use mostly in Windows Forms, it's kinda old TBH");
Console.WriteLine("An example for this is in this video:" +
    "https://www.youtube.com/watch?v=f1m7a1HSwcU" +
    "Or https://www.youtube.com/watch?v=TOdGZIF4N5o");
Console.WriteLine("");
Console.WriteLine("");


Console.WriteLine("-----------------------------------");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Using ADO.NET");
Console.WriteLine("For this one first of we need to install the library: System.Data.SQLClient ");

var user = new Users();
var id = 1;

Console.WriteLine("Create Connection To DB EFCode_DB");
//First Form
//using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["dbConnection"]))

//Second Form
using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
{
    Console.WriteLine("Opening Connection with the Connection String");
    connection.Open();
    Console.WriteLine(connection.State);

    Console.WriteLine("Defining Commands and parameters for a query");
    var cmd = new SqlCommand("select * from Users where Id= @id", connection);
    cmd.Parameters.Add(new SqlParameter("Id", id));

    Console.WriteLine("Executing the Query");
    using (SqlDataReader reader= cmd.ExecuteReader())
    {
        Console.WriteLine("Mapping to the object User");
        while (reader.Read())
        { 
            user.Id = (int)reader["Id"];
            user.Name = (string)reader["Name"];
            user.ContactNumber = (string)reader["ContactNumber"];

        }    
    }
    Console.WriteLine("Close Connection with the Using");
}
Console.WriteLine("");
Console.WriteLine("Results:");
Console.WriteLine($"    Id = {user.Id}");
Console.WriteLine($"    Name = {user.Name}");
Console.WriteLine($"    Contact Number = {user.ContactNumber}");
Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine("-----------------------------------");
Console.WriteLine("Using Dapper");
Console.WriteLine("-----------------------------------");
Console.WriteLine("Using EF");
Console.WriteLine("-----------------------------------");
Console.WriteLine("Using NHibernate");
Console.WriteLine("-----------------------------------");
Console.ReadKey();