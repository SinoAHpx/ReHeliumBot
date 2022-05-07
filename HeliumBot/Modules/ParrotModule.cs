using HeliumBot.Models;
using HeliumBot.Utils;
using Manganese.Text;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Modules;
using Mirai.Net.Utils.Scaffolds;

namespace HeliumBot.Modules;

[ModuleMetadata(Name = "复读", Description = "再说一遍你的话", HelpText = "/say <话>")]
public class ParrotModule : IModule
{
    public async void Execute(MessageReceiverBase @base)
    {
        if (!@base.MessageChain.ContainsCommand("say"))
        {
            return;
        }

        var toSay = @base.MessageChain.GetCommandArguments("say") ?? new List<string> { "无言以说" };

        var toSend = toSay.JoinToString(" ");
        await @base.SendMessageAsync(toSend);
    }

    public bool? IsEnable { get; set; }
}