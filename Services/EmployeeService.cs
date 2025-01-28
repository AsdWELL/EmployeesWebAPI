using EmployeesWebAPI.Models;
using EmployeesWebAPI.Repositories.Interfaces;
using EmployeesWebAPI.Requests.Employee;
using EmployeesWebAPI.Exceptions;
using EmployeesWebAPI.Services.Interfaces;

namespace EmployeesWebAPI.Services
{
    /// <summary>
    /// Сервис <see cref="Employee"/>
    /// </summary>
    public class EmployeeService(IEmployeeRepository repository) : IEmployeeService
    {
        ///<inheritdoc/>
        public Task<int> CreateEmployee(CreateEmployeeRequest request)
        {
            return repository.CreateEmployee(request);
        }

        ///<inheritdoc/>
        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await repository.GetEmployeeById(id)
                ?? throw new EmployeeNotFoundException(id);
        }

        ///<inheritdoc/>
        public Task<List<Employee>> GetAllEmployees()
        {
            return repository.GetAllEmployees();
        }

        ///<inheritdoc/>
        public Task<List<Employee>> GetEmployeesByCompanyId(int companyId)
        {
            return repository.GetEmployeesByCompanyId(companyId);
        }

        ///<inheritdoc/>
        public Task<List<Employee>> GetEmployeesByCompanyIdAndDepartmentId(int companyId, int departmentId)
        {
            return repository.GetEmployeesByCompanyIdAndDepartmentId(companyId, departmentId);
        }

        ///<inheritdoc/>
        public Task DeleteEmployee(int id)
        {
            if (repository.GetEmployeeById(id) == null)
                throw new EmployeeNotFoundException(id);

            return repository.DeleteEmployee(id);
        }

        ///<inheritdoc/>
        public Task UpdateEmployee(UpdateEmployeeRequest request)
        {
            if (repository.GetEmployeeById(request.Id) == null)
                throw new EmployeeNotFoundException(request.Id);

            return repository.UpdateEmployee(request);
        }
    }
}
