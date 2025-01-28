namespace EmployeesWebAPI.Models
{
    /// <summary>
    /// Модель сотрудника
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Телефонный номер
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Идентификатор компании
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Идентификатор паспорта
        /// </summary>
        public int PassportId { get; set; }

        /// <summary>
        /// Идентификатор отдела
        /// </summary>
        public int DepartmentId { get; set; }
    }
}