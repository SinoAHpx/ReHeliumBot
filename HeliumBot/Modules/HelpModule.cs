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

[ModuleMetadata(Name = "帮助", Description = "提供基础信息", HelpText = "使用/help <模块名>来查看详细帮助")]
public class HelpModule : IModule
{
    public async void Execute(MessageReceiverBase @base)
    {
        if (!@base.MessageChain.ContainsCommand("help"))
        {
            return;
        }

        var helpMessage = "这是一个HeliumBot，它只是Mirai .NET的模板Bot。\r\n";
        helpMessage += Program.Modules.Select(GetHelpText).JoinToString("\r\n");

        await @base.SendMessageAsync(helpMessage);
    }

    private string GetHelpText(IModule module)
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