using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using System.Threading.Tasks;

namespace ShibesBotCore.Modules
{
    /** 
     * 8Ball command
     * This Module prints a random response from
     * the magic 8-ball phrases contained in a string array
     * 
     * The command takes a param string[] in order to accept
     * infinite parameters (meaning someone may ask a question,
     * or not and the bot will still respond)
     * 
     * @author OptimisticShibe
     */ 
     
    public class _8Ball : ModuleBase<SocketCommandContext>  
    {
        //creating random instance
        Random random = new Random();
        private string[] eightBallPhrases = new string[]
        {
            //TODO: Create DnD versions of these
            "It is certain",
            "It is decidedly so",
            "Without a doubt",
            "Yes definitely",
            "You may rely on it",
            "As I see it, yes",
            "Most likely",
            "Outlook good",
            "Yes",
            "Signs point to yes",
            "Reply hazy try again",
            "Ask again later",
            "Better not tell you now",
            "Cannot predict now",
            "Concentrate and ask again",
            "Don't count on it",
            "My reply is no",
            "My sources say no",
            "Outlook not so good",
            "Very doubtful"
        };
        
        [Command("8ball")]
        public async Task _8BallCommand(params string[] question) //Params and array so as to accept infinite parameters
        {
            //uses Random function whose range is defined as between 0 and the size of the array
            int rand = random.Next(0, eightBallPhrases.Length);
            string response = eightBallPhrases[rand];

            await Context.Channel.SendMessageAsync(response);
        }
    }
}
