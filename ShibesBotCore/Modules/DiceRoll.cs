using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using System.Linq;

namespace ShibesBotCore.Modules
{
    public class DiceRoll : ModuleBase<SocketCommandContext>
    {
        //TODO: account for "d" in command
        //TODO: fix order of messages from bot. Perhaps assign to strings?
        [Command("Roll")]
        public async Task RollDice(int numDice, int die) //might need to include error handling for putting "d" in front of number
        {
            /*char[] deleteChars = { ' ', 'd', 'D' };
            string[] inputText = input.Split(deleteChars);
            int numDice = int.Parse(inputText[0]);
            int die = int.Parse(inputText[2]);*/
            int diceLimit = 15;
            Random random = new Random();
            // For all but d20
            int[] validDice = { 4, 6, diceLimit, 10, 12 };
            if (validDice.Contains(die) && (numDice <= diceLimit && numDice > 0))
            {
                diceEmoji();

                int diceTotal = 0;
                string result = null;

                // this If statement activates if more than 1 die rolled
                if (numDice > 1)
                {
                    for (int i = 1; i <= numDice; i++)
                    {
                        int rand = random.Next(1, die + 1);
                        diceTotal += rand;
                        if (i != numDice) // for all but last roll
                        {
                            result += $"{rand} + ";
                        }
                        
                        else // for last roll
                        {
                            result += $"{rand}";
                        }
                    }

                    await Context.Channel.SendMessageAsync($"Your Roll: {result} = **{diceTotal}**");
                }
                else
                {
                    int rand = random.Next(1, die + 1);
                    diceTotal += rand;
                    await Context.Channel.SendMessageAsync($"Your Roll: **{diceTotal}**");
                }
                
            }
            // Coin flip
            else if (die == 2 && (numDice <= diceLimit && numDice > 0))
            {
                coinFlipEmoji();
                string result = null;
                string headsOrTails = null;

                if (numDice > 1)
                {
                    for (int i = 1; i <= numDice; i++)
                    {
                        int rand = random.Next(1, die + 1);
                        if (rand == 1)
                        { headsOrTails = "Heads"; }
                        else
                        { headsOrTails = "Tails"; }
                        if (i != numDice) // for all but last roll
                        {
                            result += $"{headsOrTails} + ";
                        }

                        else // for last roll
                        {
                            result += $"{headsOrTails}";
                        }
                    }

                    await Context.Channel.SendMessageAsync($"Your Coin Flips: {result}");
                }
                else
                {
                    int rand = random.Next(1, die + 1);
                    if (rand == 1)
                    { headsOrTails = "Heads"; }
                    else
                    { headsOrTails = "Tails"; }
                    await Context.Channel.SendMessageAsync($"Your Coin Flip: **{headsOrTails}**");
                }
            }
            // d20 CODE HERE
            else if (die == 20 && (numDice <= diceLimit && numDice > 0))
            {
                
                string emojiExtra = null;
                if (numDice == 2)
                {
                    diceEmoji();
                    string result = null;
                    for (int i = 1; i <= numDice; i++)
                    {
                        int rand = random.Next(1, die + 1);
                        if (rand == 1)
                        { emojiExtra = ":boom:"; }
                        else if (rand == 20)
                        { emojiExtra = "!:tada:"; }
                        else
                        { emojiExtra = null; }

                        if (i != numDice)
                        {
                            result += $"{rand}{emojiExtra} & ";
                        }

                        else
                        {
                            result += $"{rand}{emojiExtra}";
                        }
                    }
                    await Context.Channel.SendMessageAsync($"Your Roll: {result}");
                }
                else if (numDice == 1)
                {
                    diceEmoji();
                    int rand = random.Next(1, die + 1);
                    if (rand == 1)
                    { emojiExtra = ":boom:"; }
                    else if (rand == 20)
                    { emojiExtra = "!:tada:"; }
                    else
                    { emojiExtra = null; }
                    await Context.Channel.SendMessageAsync($"Your Roll: {rand}{emojiExtra}");
                }
                else if (numDice == 4)
                {
                    await Context.Channel.SendMessageAsync("<:420blazeit:347429803483332623> <:420blazeit:347429803483332623> <:420blazeit:347429803483332623> **BLAZE IT** <:420blazeit:347429803483332623> <:420blazeit:347429803483332623> <:420blazeit:347429803483332623>");
                    await Context.Channel.SendFileAsync(@"Images\Snoop.gif");
                }
                else
                {
                    await Context.Channel.SendMessageAsync("Why are you trying to roll more than 2 d20s? That's silly. Please be reasonable, I am but a simple shibe bot.");
                }
            }
            // EXCEPTION HANDLING
            else
            {
                // Too many dice exception
                if ((numDice > diceLimit || numDice < 1) && (validDice.Contains(die) || die == 2 || die == 20))
                {
                    await Context.Channel.SendMessageAsync($"Invalid dice number! Please roll/flip between 1 and {diceLimit} dice/coins at a time");
                }
                // Invalid die choice
                else if (!validDice.Contains(die) && die != 2 && die != 20)
                {
                    await Context.Channel.SendMessageAsync("Please roll a normal DnD die or choose \"2\" to flip a coin!");
                }
                // Improper formatting of command
                else
                {
                    await Context.Channel.SendMessageAsync("Invalid Dice command! \nPlease format your dice roll like this: !roll {number of dice} {sides of dice}");
                }
            }
            async void diceEmoji()
            {
                if (numDice != 1)
                {
                    string emojiDice = null;
                    for (int i = 1; i <= numDice; i++)
                    {
                        emojiDice += ":game_die: ";
                    }

                    await Context.Channel.SendMessageAsync($"Rolling {numDice} d{die}s! {emojiDice}");
                }
                else
                {
                    await Context.Channel.SendMessageAsync($"Rolling d{die}! :game_die:");
                }
                const int delay = 3000;
                await Task.Delay(delay);
                
            }
            async void coinFlipEmoji()
            {
                if (numDice !=1)
                {
                    await Context.Channel.SendMessageAsync($"Flipping {numDice} coins! :money_with_wings:");
                }
                else
                {
                    await Context.Channel.SendMessageAsync($"Flipping a coin! :money_with_wings:");
                }

                const int delay = 3000;
                await Task.Delay(delay);
            }
        }
    }
}
