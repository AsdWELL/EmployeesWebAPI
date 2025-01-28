using EmployeesWebAPI.DataAccess;
using EmployeesWebAPI.Extensions;
using EmployeesWebAPI.Filters;

namespace EmployeesWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var dbSection = builder.Configuration.GetRequiredSection("EmployeesDatabase");

            builder.Services.Configure<DBSettings>(dbSection);

            builder.Services
                .MigrateDatabase(dbSection)
                .AddRepositories()
                .AddServices();
            
            var app = builder.Build();

            app.Run();
        }
    }
}
