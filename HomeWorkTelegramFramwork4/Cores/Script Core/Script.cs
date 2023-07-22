using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramLean;


namespace TelegramHomeWorkBot.Script_Core
{
    /// <summary>
    /// کد ها و دستورات برای اجرای عملیات دریافت تکالیف توسط بات
    /// </summary>
    internal class Script
    {
        /// <summary>
        /// اطلاعات برنامه و فرم 
        /// </summary>
        public static Informations info;
        /// <summary>
        /// بات مورد نظر در حال استفاده 
        /// </summary>
        public static TelegramBot Bot = new TelegramBot("");

        /// <summary>
        /// فقط یک بار خوانده شود.
        /// </summary>
        public static void Initialaize()
        {
            try
            {
                Bot = new TelegramBot(info.Token);

                Bot.OnMessageReceive += OnMessageReceive;
                Bot.OnTextMessageReceive += OnTextMessageReceive;
                Bot.OnPhotoMessageReceive += OnPhotoMessageReceive;
                Bot.OnDocumentMessageReceive += OnDocumentMessageReceive;

                AddReplykeys();
            }
            catch (Exception e) 
            {

                throw new Exception(e.Message);
            }

        }

        public static void OnMessageReceive(ITelegramBotClient bot, Update update)
        {

        }
        public static void OnTextMessageReceive(ITelegramBotClient bot, Update update)
        {
            try
            {
                if (update.Message.Text == "اطلاعات درس")
                    StudyInformationRequest(update.Message.Chat.Id);
                else if (update.Message.Text == "/start")
                    ChatInformationRequest(update.Message.Chat.Id);
                else
                    Bot.SendMessage(update.Message.Chat.Id, ".تمرین رو به صورت فایل یکجا بفرستید. متن قابل قبول نیست", Bot.ReplyKey);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void OnPhotoMessageReceive(ITelegramBotClient bot, Update update)
        {
            try
            {
                HomeWorkSendRequest(update.Message);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void OnDocumentMessageReceive(ITelegramBotClient bot, Update update)
        {
            try
            {
                HomeWorkSendRequest(update.Message);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void AddReplykeys()
        {
            Bot.SetReplyKeyboard(new ReplyKeyboardMarkup(new KeyboardButton[][]
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("اطلاعات درس"),
                }
            }));
        }

        static void HomeWorkSendRequest(Telegram.Bot.Types.Message homework)
        {
            Bot.ForwardMessage(info.AdminSerial, homework.Chat.Id,homework);
            Bot.SendMessage(homework.Chat.Id, "تمرین دریافت شد.", Bot.ReplyKey);

        }
        static void StudyInformationRequest(long chatid)
        {
            Bot.SendMessage(chatid, info.Description, Bot.ReplyKey);
        }
        static void ChatInformationRequest(long chatid)
        {
            Bot.SendMessage(chatid, "سلام.\n این بات برای ارسال تمرینات دانشجویان است.\n تمرینات شما باید در قالب فایل یا تصویر باشد. \n در این صورت است که تمرین شما ارسال میشود. \n شماره چت شما: " + chatid + "\n توسعه بات توسط @Mohamadyali", Bot.ReplyKey);
        }
    }
}
