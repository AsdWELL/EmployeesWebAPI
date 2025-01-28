using EmployeesWebAPI.Models;
using EmployeesWebAPI.Requests.Employee;

namespace EmployeesWebAPI.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория <see cref="Employee"/>
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Добавляет нового сотрудника в бд
        /// </summary>
        /// <param name="request">Запрос на добавление сотрудника</param>
        /// <returns>Id добавленного сотрудника</returns>
        Task<int> CreateEmployee(CreateEmployeeRequest request);

        /// <summary>
        /// Возвращает сотрудника по <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns>Сотрудник с указанным id или null, если паспорта с таким id нет</returns>
        Task<Employee?> GetEmployeeById(int id);

        /// <summary>
        /// Возвращает всех сотрудников
        /// </summary>
        /// <returns>Коллекция всех сотрудников</returns>
        Task<List<Employee>> GetAllEmployees();

        /// <summary>
        /// Возвращает всех сотрудников для указанной компании
        /// </summary>
        /// <param name="companyId">Id компании</param>
        /// <returns>Коллекция сотрудников, работающих в компании с указанным id</returns>
        Task<List<Employee>> GetEmployeesByCompanyId(int companyId);

        /// <summary>
        /// Возвращает всех сотрудников для указанного отдела компании
        /// </summary>
        /// <param name="companyId">Id компании</param>
        /// <param name="departmentId">Id отдела</param>
        /// <returns>Коллекция сотрудников, работающих в указанном отделе компании</returns>
        Task<List<Employee>> GetEmployeesByCompanyIdAndDepartmentId(int companyId, int departmentId);

        /// <summary>
        /// Удаляет сотрудника с указанным id
        /// </summary>
        /// <param name="id">Id удаляемого сотрудника</param>
        Task DeleteEmployee(int id);

        /// <summary>
        /// Обновляет информацию о сотруднике
        /// </summary>
        /// <param name="request">Запрос на обновление информации о сотруднике</param>
        Task UpdateEmployee(UpdateEmployeeRequest request);
    }
}