using DbUp;
using EmployeesWebAPI.Repositories;
using EmployeesWebAPI.Repositories.Interfaces;
using EmployeesWebAPI.Services;
using EmployeesWebAPI.Services.Interfaces;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace EmployeesWebAPI.Extensions
{
    public static class ServiceCollectionExtension
    {       
        /// <summary>
        /// Выполняет миграцию бд
        /// </summary>
        /// <param name="services"></param>
        /// <param name="dbSection"><see cref="IConfigurationSection"/> для бд</param>
        /// <returns></returns>
        public static IServiceCollection MigrateDatabase(this IServiceCollection services,
            IConfigurationSection dbSection)
        {            
            var connectionString = dbSection["ConnectionString"];

            EnsureDatabase.For.PostgresqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())                
                .WithTransaction()
                .WithVariablesDisabled()
                .LogToConsole()
                .Build();

            if (upgrader.IsUpgradeRequired())
            {
                upgrader.PerformUpgrade();
            }

            return services;
        }

        /// <summary>
        /// Добавляет репозитории моделей
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IPassportRepository, PassportRepository>()
                .AddScoped<IDepartmentRepository, DepartmentRepository>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        /// <summary>
        /// Добавляет сервисы моделей
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<IPassportService, PassportService>()
                .AddScoped<IDepartmentService, DepartmentService>()
                .AddScoped<IEmployeeService, EmployeeService>();
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddEndpointsApiExplorer()
                            .AddSwaggerGen(options =>
                            {
                                options.SwaggerDoc("Employees", new OpenApiInfo
                                {
                                    Version = "v1",
                                    Title = "Сотрудники",
                                    Description = "Тестовое задание"
                                });
                            });
        }
    }
}
