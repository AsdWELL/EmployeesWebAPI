namespace EmployeesWebAPI.Requests.Department
{
    /// <summary>
    /// Модель запроса на добавление отдела
    /// </summary>
    public class CreateDepartmentRequest
    {
        /// <summary>
        /// Название отдела
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Телефонный номер
        /// </summary>
        public string Phone { get; set; }
    }
}
