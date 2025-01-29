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
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        ///<inheritdoc/>
        public Task<int> CreateEmployee(CreateEmployeeRequest request)
        {
            return employeeRepository.CreateEmployee(request);
        }

        ///<inheritdoc/>
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await employeeRepository.GetEmployeeById(id)
                ?? throw new EmployeeNotFoundException(id);
        }

        ///<inheritdoc/>
        public Task<List<Employee>> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }

        ///<inheritdoc/>
        public Task<List<Employee>> GetEmployeesByCompanyId(int companyId)
        {
            return employeeRepository.GetEmployeesByCompanyId(companyId);
        }

        ///<inheritdoc/>
        public Task<List<Employee>> GetEmployeesByCompanyIdAndDepartmentId(int companyId, int departmentId)
        {
            return employeeRepository.GetEmployeesByCompanyIdAndDepartmentId(companyId, departmentId);
        }

        ///<inheritdoc/>
        public async Task DeleteEmployee(int id)
        {
            if ((await employeeRepository.GetEmployeeById(id)) == null)
                throw new EmployeeNotFoundException(id);

            await employeeRepository.DeleteEmployee(id);
        }

        ///<inheritdoc/>
        public async Task UpdateEmployee(UpdateEmployeeRequest request)
        {
            if ((await employeeRepository.GetEmployeeById(request.Id)) == null)
                throw new EmployeeNotFoundException(request.Id);

            await employeeRepository.UpdateEmployee(request);
        }
    }
}
