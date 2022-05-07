namespace HeliumBot;

public class Logger
{
    public static void Log(string message)
    {
        AnsiConsole.MarkupLine($"[dodgerblue1][[{DateTime.Now:s}]] - {message}[/]");
    }

    public static void Warn(string message)
    {
        AnsiConsole.MarkupLine($"[yellow][[{DateTime.Now:s}]] - {message}[/]");
    }
        
    public static void Error(string message)
    {
        AnsiConsole.MarkupLine($"[red][[{DateTime.Now:s}]] - {message}[/]");
    }
}