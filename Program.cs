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

            builder.Services.AddSwagger();

            var dbSection = builder.Configuration.GetRequiredSection("EmployeesDatabase");

            builder.Services.Configure<DBSettings>(dbSection);

            builder.Services
                .MigrateDatabase(dbSection)
                .AddRepositories()
                .AddServices();

            builder.Services.AddControllers(
                options => options.Filters.Add<ExceptionFilter>());

            var app = builder.Build();

            app.UseSwagger()
               .UseSwaggerUI(options =>
               {
                   options.SwaggerEndpoint("/swagger/Employees/swagger.json", "Employees WebApi");
                   options.RoutePrefix = string.Empty;
               });

            app.MapControllers();

            app.Run();
        }
    }
}
