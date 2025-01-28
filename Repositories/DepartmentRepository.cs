using Dapper;
using EmployeesWebAPI.DataAccess;
using EmployeesWebAPI.Models;
using EmployeesWebAPI.Repositories.Interfaces;
using EmployeesWebAPI.Requests.Department;
using Microsoft.Extensions.Options;
using Npgsql;

namespace EmployeesWebAPI.Repositories
{
    /// <summary>
    /// Реопзиторий <see cref="Department"/>
    /// </summary>
    /// <param name="options"></param>
    public class DepartmentRepository(IOptions<DBSettings> options) : IDepartmentRepository
    {
        private string ConnectionString => options.Value.ConnectionString;

        ///<inheritdoc/>
        public async Task<int> CreateDepartment(CreateDepartmentRequest request)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                return (await db.QueryAsync<int>(Sql.CreateDepartment, request)).FirstOrDefault(); ;
            }
        }

        ///<inheritdoc/>
        public async Task<Department?> GetDepartmentById(int id)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                return (await db.QueryAsync<Department>(Sql.GetDepartmentById, new { Id = id })).FirstOrDefault();
            }
        }

        ///<inheritdoc/>
        public async Task<List<Department>> GetAllDepartments()
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                return [.. await db.QueryAsync<Department>(Sql.GetAllDepartments)];
            }
        }

        ///<inheritdoc/>
        public async Task DeleteDepartment(int id)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                await db.ExecuteAsync(Sql.DeleteDepartment, new { Id = id });
            }
        }

        ///<inheritdoc/>
        public async Task UpdateDepartment(UpdateDepartmentRequest request)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                await db.ExecuteAsync(Sql.UpdateDepartment, request);
            }
        }
    }
}
