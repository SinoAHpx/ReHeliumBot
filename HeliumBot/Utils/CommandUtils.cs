using Manganese.Array;
using Manganese.Text;
using Mirai.Net.Data.Messages;

namespace HeliumBot.Utils;

public static class CommandUtils
{
    public static bool ContainsCommand(this MessageChain chain, string command, string commandPrefix = "/")
    {
        var plainMessages = chain.GetSeparatedPlainMessage();
        if (plainMessages.Any())
        {
            return plainMessages.Any(s => s.StartsWith($"{commandPrefix}{command}"));
        }

        return false;
    }

    public static bool HasCommandArguments(this MessageChain chain, string command, string commandPrefix = "/")
    {
        if (!chain.ContainsCommand(command, commandPrefix))
        {
            return false;
        }

        var match = $"{commandPrefix}{command}";
        var plainMessages = chain.GetSeparatedPlainMessage();
        
        return !plainMessages.Any(s => s.Empty(match).Trim().IsNullOrEmpty());
    }

    public static List<string>? GetCommandArguments(this MessageChain chain, string command, string commandPrefix = "/")
    {
        if (!chain.HasCommandArguments(command, commandPrefix))
        {
            return null;
        }
        
        var match = $"{commandPrefix}{command}";
        var firstMatch = chain.GetSeparatedPlainMessage()
            .Where(m => m.StartsWith(match))
            .First(m => !m.Empty(match).Trim().IsNullOrEmpty());

        return firstMatch?.Split(' ')[1..].ToList();
    }
}