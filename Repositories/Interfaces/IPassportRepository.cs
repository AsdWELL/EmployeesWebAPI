using EmployeesWebAPI.Models;
using EmployeesWebAPI.Requests.Passport;

namespace EmployeesWebAPI.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория <see cref="Passport"/>
    /// </summary>
    public interface IPassportRepository
    {
        /// <summary>
        /// Возвращает паспорт по <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id паспорта</param>
        /// <returns>Паспорт с указанным id или null, если паспорта с таким id нет</returns>
        Task<Passport?> GetPassportById(int id);

        /// <summary>
        /// Возвращает все паспорта
        /// </summary>
        /// <returns>Коллекция всех паспортов</returns>
        Task<List<Passport>> GetAllPassports();

        /// <summary>
        /// Добавляет новый паспорт в бд
        /// </summary>
        /// <param name="request">Запрос на добавление паспорта</param>
        /// <returns>Id добавленного паспорта</returns>
        Task<int> CreatePassport(CreatePassportRequest request);

        /// <summary>
        /// Обновляет информацию о паспорте
        /// </summary>
        /// <param name="request">Запрос на обновление данных паспорта</param>
        Task UpdatePassport(UpdatePassportRequest request);

        /// <summary>
        /// Удаляет отдел с <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id удаляемого паспорта</param>
        Task DeletePassport(int id);
    }
}