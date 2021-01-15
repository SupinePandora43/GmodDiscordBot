using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace GmodDiscordBot
{
    public class VietnamCommands : BaseCommandModule
    {
        [Command("ip")]
        [Description("ip сервера")]
        [Aliases("айпи", "аипи", "айпй", "аипй", "ип", "йп", "ипи", "йпй", "ипй", "йпи")]
        public async Task Ip(CommandContext ctx)
        {
            DiscordEmbedBuilder embedBuilder = new();
            embedBuilder.WithColor(new DiscordColor(255, 255, 0));
            embedBuilder.WithTitle("steam://connect/188.120.248.55:27015/");
            embedBuilder.WithImageUrl("https://sun9-35.userapi.com/7eCcJt14QGKYgGQRyqzJc7Q9CXJ7FoQ4ZbP4Kg/EzLYCxN9sDo.jpg");
            embedBuilder.AddField("Players", "10 / 85");
            await ctx.RespondAsync("steam://connect/0.0.0.0:0", embed: embedBuilder.Build());
        }

        [Command("content")]
        [Description("контент сервера")]
        [Aliases("контент", "контэнт", "кантент", "кантэнт")]
        public async Task Content(CommandContext ctx)
        {
            await ctx.RespondAsync("a");
        }
    }
}
