using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace GmodDiscordBot.Test
{
    class Program
    {
        private static readonly List<Tuple<ActivityType, string>> statuses = new() {
            new Tuple<ActivityType, string>(ActivityType.Competing, "Vietnam"),
            new Tuple<ActivityType, string>(ActivityType.Playing, "Vietnam"),
            new Tuple<ActivityType, string>(ActivityType.Watching, "Vietnam")
        };
        private const int changeStatusInterval = 10000;
        public static async Task Main()
        {
            Random random = new();
            DiscordClient Client;

            var cfg = new DiscordConfiguration
            {
                Token = "Nzk0MTY0MjMyMDE0NjU5NjM0.X-21Ew.1kaphM3s7EJ0DuXGsI_HLvVqpcc",
                TokenType = TokenType.Bot,

                AutoReconnect = true//,
                                    // MinimumLogLevel = LogLevel.Debug
            };

            Client = new DiscordClient(cfg);
            bool ready = false;

            Client.Ready += async (client, args) =>
            {
                /*await Client.UpdateStatusAsync(new DiscordActivity
                {
                    ActivityType = ActivityType.Competing,
                    Name = "Vietnam"
                },
                UserStatus.Online);
                */
                DiscordChannel channel = await Client.GetChannelAsync(700673534082416675);
                var embed = new DiscordEmbedBuilder
                {
                    Title = "Good Morning Vietnam",
                    Description = "Connect - steam://connect/188.120.248.55:27015/",
                    Color = new DiscordColor(0, 0, 50),
                    Footer = new DiscordEmbedBuilder.EmbedFooter
                    {
                        Text = "by hydra_proj"
                    },
                    Author = new DiscordEmbedBuilder.EmbedAuthor
                    {
                        Name = "Vietnam",
                        IconUrl = "https://diskomir.ru/upload/iblock/79a/79a7e4ef1582a9f30df77bd8771266c8.jpg"
                    },
                    Url = "https://github.com",
                    ImageUrl = "https://sun9-35.userapi.com/7eCcJt14QGKYgGQRyqzJc7Q9CXJ7FoQ4ZbP4Kg/EzLYCxN9sDo.jpg",
                    Timestamp = DateTimeOffset.Now
                };
                embed.AddField("Players", "14/60");
                //DiscordMessage msg = await Client.SendMessageAsync(channel, embed: embed);
                DiscordMessage msg = await channel.GetMessageAsync(794221029298798614);
                await msg.ModifyAsync(embed: embed.Build());
                ready = true;
            };

            var ccfg = new CommandsNextConfiguration
            {
                StringPrefixes = new[] { "!" },
                EnableDms = true,
                EnableMentionPrefix = true,
                EnableDefaultHelp = true
            };

            CommandsNextExtension cmds = Client.UseCommandsNext(ccfg);

            cmds.RegisterCommands<VietnamCommands>();

            await Client.ConnectAsync();

            while (!ready)
            {
                await Task.Delay(10);
            }
            while (true)
            {
                Tuple<ActivityType, string> status = statuses[random.Next(0, statuses.Count)];
                Console.WriteLine(status);
                Console.WriteLine(Client.Ping);
                await Client.UpdateStatusAsync(new DiscordActivity()
                {
                    ActivityType = status.Item1,
                    Name = status.Item2
                });
                await Task.Delay(changeStatusInterval);
            }
        }
    }
}
