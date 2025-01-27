namespace EmployeesWebAPI.Entities
{
    /// <summary>
    /// Модель паспорта
    /// </summary>
    public class Passport
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тип паспорта
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string Number { get; set; }
    }
}
