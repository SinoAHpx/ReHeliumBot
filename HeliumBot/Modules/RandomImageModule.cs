using HeliumBot.Models;
using Mirai.Net.Data.Messages;
using Mirai.Net.Modules;

namespace HeliumBot.Modules;

[ModuleMetadata(Name = "随机图片", Description = "发送一张随机图片", HelpText = "/img")]
public class RandomImageModule : IModule
{
    public void Execute(MessageReceiverBase @base)
    {
        
    }

    public bool? IsEnable { get; set; }
}