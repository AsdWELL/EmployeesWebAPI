namespace EmployeesWebAPI.Requests.Passport
{
    /// <summary>
    /// Модель запроса на добавление нового паспорта
    /// </summary>
    public class CreatePassportRequest
    {
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
