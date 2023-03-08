using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MrSmartRewriteV2.SlashCommands
{
    public class EmbedSL : ApplicationCommandModule
    {
        [SlashCommand("embed", "Creates a Custom Embed")]
        public async Task EmbedSlashCommand(InteractionContext ctx, [Option("Title", "Title Of Embed")] string title, [Option("Description", "Body of Embed")] string description, [Option("Channel", "Channel to send embed to.")]DiscordChannel channel)
        {
            var embedChannel = channel;
            var embedMessage = new DiscordEmbedBuilder()
            {
                Title = title,
                Description = description,
                Color = DiscordColor.Purple,
            };
            embedMessage.WithThumbnail(ctx.Guild.IconUrl);
            embedMessage.WithFooter(ctx.Member.Username, ctx.Member.AvatarUrl);

            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder()
                .WithContent("Embed Building and Sending..."));

            

            await embedChannel.SendMessageAsync(embedMessage);
        }
    }
}
