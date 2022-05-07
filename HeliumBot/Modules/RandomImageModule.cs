using HeliumBot.Models;
using HeliumBot.Utils;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Modules;
using Mirai.Net.Utils.Scaffolds;

namespace HeliumBot.Modules;

[ModuleMetadata(Name = "随机图片", Description = "发送一张随机图片", HelpText = "/img")]
public class RandomImageModule : IModule
{
    public async void Execute(MessageReceiverBase @base)
    {
        //todo: more decent way to check if this module is route of some commands
        if (!@base.MessageChain.ContainsCommand("img"))
        {
            return;
        }

        var url = "https://picsum.photos/1920/1080";
        
        //构造一个图片消息
        var toSend = new ImageMessage
        {
            Url = url
        };
        
        //todo: add extension method "SendMessageAsync" directly to MessageReceiverBase at the main project
        await @base.SendMessageAsync(toSend);
    }

    public bool? IsEnable { get; set; }
}