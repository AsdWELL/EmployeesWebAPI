using DbUp;
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
            string connectionString = dbSection["ConnectionString"];

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
    }
}
