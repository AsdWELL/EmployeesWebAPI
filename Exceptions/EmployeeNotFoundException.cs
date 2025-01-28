namespace EmployeesWebAPI.Exceptions
{
    /// <summary>
    /// Исключение, которое выбрасывается, если сотрудник не найден
    /// </summary>
    /// <param name="id"></param>
    public class EmployeeNotFoundException(int id) : NotFoundException($"Сотрудник с id {id} не найден");
}
