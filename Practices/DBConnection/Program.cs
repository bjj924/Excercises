using System;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using DBConnection;

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
//using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
//{
//    Console.WriteLine("Opening Connection with the Connection String");
//    connection.Open();
//    Console.WriteLine(connection.State);

//    Console.WriteLine("Defining Commands and parameters for a query");
//    var cmd = new SqlCommand("select * from Users where Id= @id", connection);
//    cmd.Parameters.Add(new SqlParameter("Id", id));

//    Console.WriteLine("Executing the Query");
//    using (SqlDataReader reader= cmd.ExecuteReader())
//    {
//        Console.WriteLine("Mapping to the object User");
//        while (reader.Read())
//        { 
//            user.Id = (int)reader["Id"];
//            user.Name = (string)reader["Name"];
//            user.ContactNumber = (string)reader["ContactNumber"];

//        }    
//    }
//    Console.WriteLine("Close Connection with the Using");
//}
//Console.WriteLine("");
//Console.WriteLine("Results:");
//Console.WriteLine($"    Id = {user.Id}");
//Console.WriteLine($"    Name = {user.Name}");
//Console.WriteLine($"    Contact Number = {user.ContactNumber}");
//Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine("-----------------------------------");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Using Dapper");
Console.WriteLine("");
Console.WriteLine("To work with Dapper we need two NuGet Packages");
Console.WriteLine("The Dapper nuget package by Sam Saffron, Marc Gravell and Nick Craver ");
Console.WriteLine("(We will use the version 2.1.28)");
Console.WriteLine("Then the nuget package for Microsoft.Data.SqlClient");

var connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

// Ejemplo 1 de Dapper: Query a la tabla
var query = "select * from Users";

//using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
//{
//    //var anonimusQuery = connection.Query(query).ToList();

//    // Podemos mapear el query al objecto que queramos y despues lo hacemos una lista
//    var users = connection.Query<Users>(query).ToList();
//}

//Insert con Dapper

//var insertQuery = "INSERT INTO Users (Name, ContactNumber) VALUES (@name, @contactnumber)";

//using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
//{
//    connection.Execute(insertQuery, new { name = "Prueba", contactnumber ="1134280099" });
//    var users = connection.Query<Users>(query).ToList();
//}

Console.WriteLine("-----------------------------------");
Console.WriteLine("Using EF");
Console.WriteLine("To work with EF we need two NuGet Packages");
Console.WriteLine("The Microsoft.EntityFrameworkCore.SqlServer nuget package ");
Console.WriteLine("The version for all is the 6.0.0, I have to read the documentation to see if the context is still necesary");
Console.WriteLine("The Microsoft.EntityFrameworkCore.Tools nuget package ");
Console.WriteLine("And The Microsoft.Extensions.Configuration nuget package ");
Console.WriteLine("Then we create the context for the calls");
Console.WriteLine("Once the context is done then we make the call");

using (var context = new UsersDbContext())
{
    foreach (var item in context.Users)
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"|        {item.Id}        |");
        Console.WriteLine($"|        {item.Name}        |");
        Console.WriteLine($"|        {item.ContactNumber}        |");
        Console.WriteLine("-----------------------------------");
    }

}
Console.WriteLine("The Context is the one that manage the conection in here, for more info, read the documentation");
Console.WriteLine("https://learn.microsoft.com/en-us/ef/");
Console.WriteLine("");

Console.WriteLine("-----------------------------------");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Using NHibernate");
Console.WriteLine("In Another Proyect: NHibernate");
Console.WriteLine("-----------------------------------");
Console.ReadKey();