namespace EmployeesWebAPI.Models
{
    /// <summary>
    /// Модель отдела
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

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
