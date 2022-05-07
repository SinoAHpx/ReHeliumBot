using System.Reflection;
using HeliumBot.Models;
using HeliumBot.Utils;
using Manganese.Array;
using Manganese.Text;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Modules;
using Mirai.Net.Utils.Scaffolds;

namespace HeliumBot.Modules;

[ModuleMetadata(Name = "帮助", Description = "提供基础信息", HelpText = "/help <模块名>")]
public class HelpModule : IModule
{
    public async void Execute(MessageReceiverBase @base)
    {
        if (!@base.MessageChain.ContainsCommand("help"))
        {
            return;
        }

        if (@base.MessageChain.HasCommandArguments("help"))
        {
            var arguments = @base.MessageChain.GetCommandArguments("help");
            if (arguments == null)
            {
                return;
            }

            var name = arguments[0];
            var module = Program.Modules
                .Select(m => m.GetType())
                .Select(x => x.GetCustomAttribute<ModuleMetadataAttribute>())
                .Where(x => x != null)
                .FirstOrDefault(x => x!.Name == name, null);

            if (module != null)
            {
                await @base.SendMessageAsync($"{module.Name} - {module.Description}\r\n用法: {module.HelpText}");
            }
        }
        else
        {
            var helpMessage = "这是一个HeliumBot，它只是Mirai .NET的模板Bot。\r\n";
            helpMessage += Program.Modules.Select(GetDescription).JoinToString("\r\n");

            await @base.SendMessageAsync(helpMessage);
        }
    }

    private string GetDescription(IModule module)
    {
        var type = module.GetType();
        var metadata = type.GetCustomAttribute<ModuleMetadataAttribute>();

        if (metadata == null)
        {
            return type.Name;
        }

        return $"{metadata.Name} - {metadata.Description ?? "没有描述"}";
    }

    public bool? IsEnable { get; set; }
}