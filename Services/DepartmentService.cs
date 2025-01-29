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
    /// <param name="departmentRepository"></param>
    public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
    {
        ///<inheritdoc/>
        public Task<int> CreateDepartment(CreateDepartmentRequest request)
        {
            return departmentRepository.CreateDepartment(request);
        }

        ///<inheritdoc/>
        public async Task<Department> GetDepartmentById(int id)
        {
            return await departmentRepository.GetDepartmentById(id)
                ?? throw new DepartmentNotFoundException(id);
        }

        ///<inheritdoc/>
        public Task<List<Department>> GetAllDepartments()
        {
            return departmentRepository.GetAllDepartments();
        }

        ///<inheritdoc/>
        public async Task UpdateDepartment(UpdateDepartmentRequest request)
        {
            if ((await departmentRepository.GetDepartmentById(request.Id)) == null)
                throw new DepartmentNotFoundException(request.Id);

            await departmentRepository.UpdateDepartment(request);
        }

        ///<inheritdoc/>
        public async Task DeleteDepartment(int id)
        {
            if ((await departmentRepository.GetDepartmentById(id)) == null)
                throw new DepartmentNotFoundException(id);

            await departmentRepository.DeleteDepartment(id);
        }
    }
}
