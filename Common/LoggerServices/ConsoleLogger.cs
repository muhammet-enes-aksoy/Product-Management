namespace ProductManagement.LoggerServices;

public class ConsoleLogger : ILoggerService
{
    public void LogInfo(string message)
    {
        Console.WriteLine("[ConsoleLogger] - " + message);
    }
}