using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace ShibesBotCore.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("Help")]
        public async Task About(params string[] input)
        {
            await Context.Channel.SendMessageAsync("hello");
        }
    }
}
