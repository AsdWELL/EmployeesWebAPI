using Dapper;
using EmployeesWebAPI.DataAccess;
using EmployeesWebAPI.Models;
using EmployeesWebAPI.Repositories.Interfaces;
using EmployeesWebAPI.Requests.Employee;
using Microsoft.Extensions.Options;
using Npgsql;

namespace EmployeesWebAPI.Repositories
{
    /// <summary>
    /// Репозиторий <see cref="Employee"/>
    /// </summary>
    /// <param name="options"></param>
    public class EmployeeRepository(IOptions<DBSettings> options) : IEmployeeRepository
    {
        private string ConnectionString => options.Value.ConnectionString;

        ///<inheritdoc/>
        public async Task<int> CreateEmployee(CreateEmployeeRequest request)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                return (await db.QueryAsync<int>(Sql.CreateEmployee, request)).FirstOrDefault();
            }
        }

        ///<inheritdoc/>
        public async Task<Employee?> GetEmployeeById(int id)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                return (await db.QueryAsync<Employee>(Sql.GetEmployeeById, new { Id = id })).FirstOrDefault();
            }
        }

        ///<inheritdoc/>
        public async Task<List<Employee>> GetAllEmployees()
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                return [.. await db.QueryAsync<Employee>(Sql.GetAllEmployees)];
            }
        }

        ///<inheritdoc/>
        public async Task<List<Employee>> GetEmployeesByCompanyId(int companyId)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                return [.. await db.QueryAsync<Employee>(Sql.GetEmployeesByCompanyId, new { CompanyId = companyId })];
            }
        }

        ///<inheritdoc/>
        public async Task<List<Employee>> GetEmployeesByCompanyIdAndDepartmentId(int companyId, int departmentId)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                return [.. await db.QueryAsync<Employee>(Sql.GetEmployeesByCompanyIdAndDepartmentId,
                    new { CompanyId = companyId, DepartmentId = departmentId })];
            }
        }

        ///<inheritdoc/>
        public async Task UpdateEmployee(UpdateEmployeeRequest request)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                await db.ExecuteAsync(Sql.UpdateEmployee, request);
            }
        }

        ///<inheritdoc/>
        public async Task DeleteEmployee(int id)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                await db.ExecuteAsync(Sql.DeleteEmployee, new { Id = id });
            }
        }
    }
}