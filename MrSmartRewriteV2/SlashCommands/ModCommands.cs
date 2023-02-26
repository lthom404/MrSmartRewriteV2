using DSharpPlus;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MrSmartRewriteV2.SlashCommands
{
    public class ModCommands : ApplicationCommandModule
    {
        [SlashCommand("ban", "This command bans a user from the server")]
        public async Task BanSlashCommand(InteractionContext ctx, [Option("user", "User that you want to ban")] DiscordUser user, [Option("reason", "Reason for banning member")] string reason)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                            .WithContent("Banning member"));
            Console.WriteLine("Broke");
            var member = await ctx.Guild.GetMemberAsync(user.Id);

            var kickLog = new DiscordEmbedBuilder()
                .WithTitle("User Banned From The Server")
                .WithColor(DiscordColor.Red)
                .WithDescription($"> **User Banned:** {member.Username}\n\n" +
                $"> **User ID:** {member.Id}\n\n" +
                $"> **Banned By:** {ctx.Member.Username}\n\n" +
                $"> **Reason:** {reason}")
                .WithTimestamp(DateTime.Now)
                .WithFooter($"New Ban Logged");

            await member.BanAsync(reason: reason);

            await ctx.Channel.SendMessageAsync("Member banned from the server");
        }

        [SlashCommand("kick", "Kicks a member from your server")]
        public async Task KickSlashCommand(InteractionContext ctx, [Option("member", "member that you want to kick")] DiscordUser user, [Option("reason", "Reason for kicking member")] string reason)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent("Kicking Member..."));

            var member = await ctx.Guild.GetMemberAsync(user.Id);

            var kickLog = new DiscordEmbedBuilder()
                .WithTitle("User Kicked From The Server")
                .WithColor(DiscordColor.Red)
                .WithDescription($"> **User:** {member.Username}\n\n" +
                $"> **User ID:** {member.Id}\n\n" +
                $"> **Banned By:** {ctx.Member.Username}\n\n" +
                $"> **Reason:** {reason}")
                .WithTimestamp(DateTime.Now)
                .WithFooter($"New Kick Logged");

            await member.RemoveAsync(reason);

            var modlogChannel = ctx.Guild.GetChannel(1079417214832230421);

            await modlogChannel.SendMessageAsync(kickLog);
        }
        [SlashCommand("dchannel", "Deletes a specified channel")]
        public async Task DeleteChannelSlashCommand(InteractionContext ctx, [Option("channel", "channel to be deleted")] DiscordChannel channel, [Option("reason", "Reason for deleting channel")] string reason)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent("Deleting Channel..."));

            var deletechannelLog = new DiscordEmbedBuilder()
                .WithAuthor("Channel Deleted From The Server")
                .WithColor(DiscordColor.Red)
                .WithDescription($"> **Channel:** {channel.Name}\n\n" +
                $"> **Channel ID:** {channel.Id}\n\n" +
                $"> **Deleted By:** {ctx.Member.Username}\n\n" +
                $"> **Reason:** {reason}")
                .WithTimestamp(DateTime.Now)
                .WithFooter($"New Channel Deletion Logged");

            var deleteChannel = channel;
            var modlogChannel = ctx.Guild.GetChannel(1079417214832230421);

            await deleteChannel.DeleteAsync();

            await modlogChannel.SendMessageAsync(deletechannelLog);
        }
    }
}
