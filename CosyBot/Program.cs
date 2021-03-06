﻿using System;
using System.Threading.Tasks;
using System.Timers;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace CosyBot
{
    public class Program
    {
        private static System.Timers.Timer timer;
        DiscordSocketClient discord;

        public static void Main(string[] args)
        {
            timer = new Timer( 60 * 1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            new Program().MainAsync().GetAwaiter().GetResult();

        }

        public async Task MainAsync()
        {
            discord = new DiscordSocketClient();
            discord.Log += Log;
            await LoginDiscord("NTM2NTQwMzczMjAwMTQyMzQ2.DyYNTQ.RmsYj6lMnNAB-1PCVxBKd1-5XFs", discord);
            discord.MessageReceived += MessageReceived;
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task LoginDiscord(String token, DiscordSocketClient client)
        {
            client.LoginAsync(TokenType.Bot, token);
            client.StartAsync();
            return Task.CompletedTask;
        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == "!Bonjour")
            {
                await message.Channel.SendMessageAsync("Greetings!");
            }

            if (message.Content == "!Aurevoir")
            {
                await message.Channel.SendMessageAsync("Have a nice day, Sir!");
            }

        }
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("still active",
                              e.SignalTime);
        }


    }
}

