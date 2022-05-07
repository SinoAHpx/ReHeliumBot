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

    public static List<string>? GetArguments(this MessageChain chain, string command, string commandPrefix = "/")
    {
        if (!chain.HasCommandArguments(command, commandPrefix))
        {
            return null;
        }
        
        
        
        return null;
    }
}