namespace EmployeesWebAPI.Exceptions
{
    /// <summary>
    /// Исключение, которое выбрасывается, если отдел не найден
    /// </summary>
    /// <param name="id"></param>
    public class DepartmentNotFoundException(int id) : NotFoundException($"Отдел с id {id} не найден");
}
