using HeliumBot.Modules;
using HeliumBot.Utils;
using Manganese.Array;
using Manganese.Text;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Modules;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Scaffolds;
using Spectre.Console;

namespace HeliumBot
{
    public class Program
    {
        public static List<IModule> Modules => new HelpModule().GetModules().ToList();

        public static async Task Main()
        {
            AnsiConsole.Write(new FigletText("HeliumBot").LeftAligned().Color(Color.DodgerBlue1));
            
            var bot = new MiraiBot
            {
                Address = "localhost:8080",
                QQ = "1590454991",
                VerifyKey = "1145141919810"
            };
            
            await bot.LaunchAsync();

            Logger.Log("Launched");
            
            bot.MessageReceived.Subscribe(r =>
            {
                Modules.Raise(r);
            });

            while (true)
            {
                var command = AnsiConsole.Ask<string>("[red]>[/]");
                if (command == "/exit")
                {
                    if (AnsiConsole.Confirm("Are you sure you want to exit?"))
                    {
                        Logger.Log("Exiting...");
                        bot.Dispose();
                    }
                }
            }
        }
    }
}