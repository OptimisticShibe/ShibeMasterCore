using System;
using System.Linq;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using System.IO;
using Discord.Commands;

namespace ShibesBotCore
{
    public class Program : ModuleBase<SocketCommandContext>
    {
        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        private CommandHandler.CommandHandler _handler;

        public async Task StartAsync()
        {
            _client = new DiscordSocketClient();

            string token = File.ReadLines(@"token.txt").Take(1).First();
            /*var tokenArray = File.ReadAllLines("token.txt");
            string token = tokenArray[0];*/

            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();

            _handler = new CommandHandler.CommandHandler();

            await _handler.InitializeAsync(_client);

            await Task.Delay(-1);
        }
    }
}