using EmployeesWebAPI.Models;
using EmployeesWebAPI.Repositories.Interfaces;
using EmployeesWebAPI.Requests.Department;
using EmployeesWebAPI.Exceptions;
using EmployeesWebAPI.Services.Interfaces;

namespace EmployeesWebAPI.Services
{
    /// <summary>
    /// Сервис <see cref="Department"/>
    /// </summary>
    /// <param name="repository"></param>
    public class DepartmentService(IDepartmentRepository repository) : IDepartmentService
    {
        ///<inheritdoc/>
        public Task<int> CreateDepartment(CreateDepartmentRequest request)
        {
            return repository.CreateDepartment(request);
        }

        ///<inheritdoc/>
        public Task<Department?> GetDepartmentById(int id)
        {
            return repository.GetDepartmentById(id)
                ?? throw new DepartmentNotFoundException(id);
        }

        ///<inheritdoc/>
        public Task<List<Department>> GetAllDepartments()
        {
            return repository.GetAllDepartments();
        }

        ///<inheritdoc/>
        public Task UpdateDepartment(UpdateDepartmentRequest request)
        {
            if (repository.GetDepartmentById(request.Id) == null)
                throw new DepartmentNotFoundException(request.Id);

            return repository.UpdateDepartment(request);
        }

        ///<inheritdoc/>
        public Task DeleteDepartment(int id)
        {
            if (repository.GetDepartmentById(id) == null)
                throw new DepartmentNotFoundException(id);

            return repository.DeleteDepartment(id);
        }
    }
}
