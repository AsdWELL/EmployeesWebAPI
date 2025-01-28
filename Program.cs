using EmployeesWebAPI.DataAccess;
using EmployeesWebAPI.Extensions;

namespace EmployeesWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var dbSection = builder.Configuration.GetRequiredSection("EmployeesDatabase");

            builder.Services.Configure<DBSettings>(dbSection);
            
            builder.Services.MigrateDatabase(dbSection);
            
            var app = builder.Build();

            app.Run();
        }
    }
}
