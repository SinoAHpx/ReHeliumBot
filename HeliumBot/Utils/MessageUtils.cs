using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;

namespace HeliumBot.Utils;

public static class MessageUtils
{
    public static async Task SendMessageAsync(this MessageReceiverBase @base, MessageChain toSay)
    {
        if (@base is GroupMessageReceiver groupMessageReceiver)
        {
            await MiraiScaffold.SendMessageAsync(groupMessageReceiver, toSay);
        }
        else if (@base is FriendMessageReceiver friendMessageReceiver)
        {
            await MiraiScaffold.SendMessageAsync(friendMessageReceiver, toSay);

        }
        else if (@base is TempMessageReceiver tempMessageReceiver)
        {
            await MiraiScaffold.SendMessageAsync(tempMessageReceiver, toSay);
        }
        else
        {
            throw new Exception("Unknown message receiver!");
        }
    }

    public static async Task SendMessageAsync(this MessageReceiverBase @base, string toSay)
    {
        await @base.SendMessageAsync(new MessageChain { new PlainMessage(toSay) });
    }
}