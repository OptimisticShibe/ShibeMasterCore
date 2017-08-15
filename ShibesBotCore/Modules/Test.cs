using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using System.Threading.Tasks;

namespace ShibesBotCore.Modules
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        [Command("Test")]
        public async Task TestCommand(string repeat)
        {
            await Context.Channel.SendMessageAsync(repeat);
        }
    }
}
