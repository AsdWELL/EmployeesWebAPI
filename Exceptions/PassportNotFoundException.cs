namespace EmployeesWebAPI.Exceptions
{
    /// <summary>
    /// Исключение, которое выбрасывается, если паспорт не найден
    /// </summary>
    /// <param name="id"></param>
    public class PassportNotFoundException(int id) : NotFoundException($"Паспорт с id {id} не найден");
}
