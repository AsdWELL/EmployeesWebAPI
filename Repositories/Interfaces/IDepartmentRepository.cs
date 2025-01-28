using EmployeesWebAPI.Models;
using EmployeesWebAPI.Requests.Department;

namespace EmployeesWebAPI.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория <see cref="Department"/>
    /// </summary>
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Добавляет новый отдел в бд
        /// </summary>
        /// <param name="request">Запрос на добавление отдела</param>
        /// <returns>id добавленного отдела</returns>
        Task<int> CreateDepartment(CreateDepartmentRequest request);

        /// <summary>
        /// Возвращает отдел по <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id отдела</param>
        /// <returns>Отдел с указанным id или null, если отдела с таким id нет</returns>
        Task<Department?> GetDepartmentById(int id);

        /// <summary>
        /// Возвращает все отделы
        /// </summary>
        /// <returns>Коллекция всех отделов</returns>
        Task<List<Department>> GetAllDepartments();

        /// <summary>
        /// Обновляет информацию об отделе
        /// </summary>
        /// <param name="request">Запрос на обновление данных об отделе</param>
        Task UpdateDepartment(UpdateDepartmentRequest request);

        /// <summary>
        /// Удаляет отдел с <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id удаляемого отдела</param>
        Task DeleteDepartment(int id);
    }
}