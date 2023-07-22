using System;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramLean
{
    /// <summary>
    /// کلاس اطلاعاتی است که اطلاعات یک بات رو نگه میداره
    /// </summary>
    internal class TelBotInfo
    {
        public TelegramBotClient TelBotClient { get; set; }
        public string Token { get; set; }
        public ReplyKeyboardMarkup ReplyKey { get; set; }

    }
}
