using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using System.Threading.Tasks;
using Discord;

namespace ShibesBotCore.Modules
{
    public class Clear : ModuleBase<SocketCommandContext>
    {
        [Command("clear", RunMode = RunMode.Async)]
        [Summary("Deletes the specified amount of messages.")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]
        public async Task ClearChat(uint amount)
        {
            var messages = await this.Context.Channel.GetMessagesAsync((int)amount + 1).Flatten();

            await this.Context.Channel.DeleteMessagesAsync(messages);
            const int delay = 5000;
            var m = await this.ReplyAsync($"Chat Cleared. _This message will be deleted in {delay / 1000} seconds._");
            //if (delay != 0)
            //{
            //    var mm = await this.ReplyAsync($"Cannot clear chat right now!");
            //}
            await Task.Delay(delay);
            await m.DeleteAsync();
            
            

        }
    }
}
