namespace EmployeesWebAPI.Requests.Passport
{
    /// <summary>
    /// Модель запроса на обновление данных о паспорте
    /// </summary>
    public class UpdatePassportRequest
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тип паспорта
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string? Number { get; set; }
    }
}
