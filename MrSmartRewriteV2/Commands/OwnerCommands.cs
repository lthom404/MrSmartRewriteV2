using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MrSmartRewriteV2.Commands
{
    public class OwnerCommands : BaseCommandModule
    {
        public DiscordClient Client { get; private set; }
        [Command("disconnect")]
        public async Task DisconnectBotCommand(CommandContext ctx)
        {
            await Client.DisconnectAsync();
        }
    }
}
