namespace EmployeesWebAPI.Exceptions
{
    /// <summary>
    /// Абстрактный класс исключения NotFound
    /// </summary>
    /// <param name="message"></param>
    public abstract class NotFoundException(string message) : Exception(message);
}
