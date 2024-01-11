using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate_DBConnection;
using System.Configuration;
using System.Reflection;

Console.WriteLine("-----------------------------------");
Console.WriteLine("Using NHibernate to connect to a DB");
Console.WriteLine("To work with NHibernate we need two NuGet Packages");
Console.WriteLine("The Nhibernate nuget package Latest stable 5.4.0 ");
Console.WriteLine("");
Console.WriteLine("-----------------------------------");
Console.WriteLine("");
Console.WriteLine("Then We Create a new Nhibernate configuration");
var config = new NHibernate.Cfg.Configuration();

Console.WriteLine("");
Console.WriteLine("Then add a new database integration to our connection string");
config.DataBaseIntegration( d =>
{
    d.ConnectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
    d.Dialect<MsSql2012Dialect>();
    d.Driver<SqlClientDriver>();
});

Console.WriteLine("");
Console.WriteLine("Then using reflection we add our assembly");
config.AddAssembly(Assembly.GetExecutingAssembly());

Console.WriteLine("");
Console.WriteLine("Then we create a Session Factory");
var sessionFactory = config.BuildSessionFactory();

Console.WriteLine("");
Console.WriteLine("And we make a using to open a session");
Console.WriteLine("But first we create a XML file for the mapping between our table and our object");

Console.WriteLine("");
Console.WriteLine("Now we open a sesion to try an insert");
using (var session = sessionFactory.OpenSession())
{
    var user = new Users { Name = "Prueba Hibernate", ContactNumber = "123456789" };
    session.Save(user);
}