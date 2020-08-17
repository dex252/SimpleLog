namespace SimpleLog
{
    public interface ILogger
    {
        /// <summary>
        /// Записать лог
        /// </summary>
        /// <param name="message"></param>
        void Write(string message);

        /// <summary>
        /// Добавить источники из конструктора по именам
        /// </summary>
        /// <param name="constructors"></param>
        void AddSources(Area area, params string[] sources);
    }
}
