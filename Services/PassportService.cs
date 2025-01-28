using EmployeesWebAPI.Exceptions;
using EmployeesWebAPI.Models;
using EmployeesWebAPI.Repositories.Interfaces;
using EmployeesWebAPI.Requests.Passport;
using EmployeesWebAPI.Services.Interfaces;

namespace EmployeesWebAPI.Services
{
    /// <summary>
    /// Сервис <see cref="Passport"/>
    /// </summary>
    /// <param name="repository"></param>
    public class PassportService(IPassportRepository repository) : IPassportService
    {
        ///<inheritdoc/>
        public Task<Passport?> GetPassportById(int id)
        {
            return repository.GetPassportById(id)
                ?? throw new PassportNotFoundException(id);
        }

        ///<inheritdoc/>
        public Task<List<Passport>> GetAllPassports()
        {
            return repository.GetAllPassports();
        }

        ///<inheritdoc/>
        public Task<int> CreatePassport(CreatePassportRequest request)
        {
            return repository.CreatePassport(request);
        }

        ///<inheritdoc/>
        public Task UpdatePassport(UpdatePassportRequest request)
        {
            if (repository.GetPassportById(request.Id) == null)
                throw new PassportNotFoundException(request.Id);

            return repository.UpdatePassport(request);
        }

        ///<inheritdoc/>
        public Task DeletePassport(int id)
        {
            if (repository.GetPassportById(id) == null)
                throw new PassportNotFoundException(id);

            return repository.DeletePassport(id);
        }
    }
}
