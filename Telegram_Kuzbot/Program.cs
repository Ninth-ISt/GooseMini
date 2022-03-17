using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Telegram_Kuzbot
{
    public class Program
    {
        public static TelegramBotClient client;
        private static string Token { get; set; } = Settings.Token;

        [Obsolete]
        public static void Main()
        {
            client = new TelegramBotClient(Token);
            client.StartReceiving();
            client.OnMessage += BotOnMessageReceived;
            Console.ReadLine();
            client.StopReceiving();
        }

        [Obsolete]
        public static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            switch (message.Text)
            {
                case "/start":
                    Console.WriteLine($"Пришло сообщение с текстом: {message.Text}");
                    await client.SendTextMessageAsync(message.Chat.Id, "Приветствую тебя, странник мира под названием «Интернет»! Чем могу быть полезен? (/help - помощь)");
                    break;

                case "/lessons":
                    Console.WriteLine($"Пришло сообщение с текстом: {message.Text}");
                    await client.SendTextMessageAsync(message.Chat.Id, "Введите группу и желаемую дату. Формат входной строки группа:день-месяц");
                    break;
                case "/room":
                    Console.WriteLine($"Пришло сообщение с текстом: {message.Text}");
                    await client.SendTextMessageAsync(message.Chat.Id, "Введите номер аудитории и желаемую дату. Формат входной строки аудитория:дата");
                    break;
                case "/teacher":
                    Console.WriteLine($"Пришло сообщение с текстом: {message.Text}");
                    await client.SendTextMessageAsync(message.Chat.Id, "Введите преподавателя и желаемую дату. Формат входной строки полное ФИО:дата");
                    break;
                case "/help":
                    Console.WriteLine($"Пришло сообщение с текстом: {message.Text}");
                    await client.SendTextMessageAsync(message.Chat.Id, "/start — начало общения с KuzBot");
                    break;
            }
        }
    }
}