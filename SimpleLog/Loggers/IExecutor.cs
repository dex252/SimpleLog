namespace SimpleLog.Loggers
{
    internal interface IExecutor
    {
         void Write(string message);
         void AddSource(Source constructor);
    }
}
