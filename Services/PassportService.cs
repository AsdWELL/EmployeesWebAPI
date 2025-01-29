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
    /// <param name="passportRepository"></param>
    public class PassportService(IPassportRepository passportRepository) : IPassportService
    {
        ///<inheritdoc/>
        public async Task<Passport> GetPassportById(int id)
        {
            return await passportRepository.GetPassportById(id)
                ?? throw new PassportNotFoundException(id);
        }

        ///<inheritdoc/>
        public Task<List<Passport>> GetAllPassports()
        {
            return passportRepository.GetAllPassports();
        }

        ///<inheritdoc/>
        public Task<int> CreatePassport(CreatePassportRequest request)
        {
            return passportRepository.CreatePassport(request);
        }

        ///<inheritdoc/>
        public async Task UpdatePassport(UpdatePassportRequest request)
        {
            if ((await passportRepository.GetPassportById(request.Id)) == null)
                throw new PassportNotFoundException(request.Id);

            await passportRepository.UpdatePassport(request);
        }

        ///<inheritdoc/>
        public async Task DeletePassport(int id)
        {
            if ((await passportRepository.GetPassportById(id)) == null)
                throw new PassportNotFoundException(id);

            await passportRepository.DeletePassport(id);
        }
    }
}
