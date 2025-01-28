using Dapper;
using EmployeesWebAPI.DataAccess;
using EmployeesWebAPI.Models;
using EmployeesWebAPI.Repositories.Interfaces;
using EmployeesWebAPI.Requests.Passport;
using Microsoft.Extensions.Options;
using Npgsql;

namespace EmployeesWebAPI.Repositories
{
    /// <summary>
    /// Репозиторий <see cref="Passport"/>
    /// </summary>
    /// <param name="options"></param>
    public class PassportRepository(IOptions<DBSettings> options) : IPassportRepository
    {
        private string ConnectionString => options.Value.ConnectionString;

        ///<inheritdoc/>
        public async Task<int> CreatePassport(CreatePassportRequest request)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                return (await db.QueryAsync<int>(Sql.CreatePassport, request)).FirstOrDefault();
            }
        }

        ///<inheritdoc/>
        public async Task<Passport?> GetPassportById(int id)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                return (await db.QueryAsync<Passport>(Sql.GetPassportById, new { Id = id })).FirstOrDefault();
            }
        }

        ///<inheritdoc/>
        public async Task<List<Passport>> GetAllPassports()
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                return [.. await db.QueryAsync<Passport>(Sql.GetAllPassports)];
            }
        }

        ///<inheritdoc/>
        public async Task DeletePassport(int id)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                await db.ExecuteAsync(Sql.DeletePassport, new { Id = id });
            }
        }

        ///<inheritdoc/>
        public async Task UpdatePassport(UpdatePassportRequest request)
        {
            using (var db = new NpgsqlConnection(ConnectionString))
            {
                await db.ExecuteAsync(Sql.UpdatePassport, request);
            }
        }
    }
}
