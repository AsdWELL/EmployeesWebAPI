namespace EmployeesWebAPI.Requests.Department
{
    /// <summary>
    /// Моедель запроса на обновленине данных об отделе
    /// </summary>
    public class UpdateDepartmentRequest
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название отдела
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Телефонный номер
        /// </summary>
        public string? Phone { get; set; }
    }
}
