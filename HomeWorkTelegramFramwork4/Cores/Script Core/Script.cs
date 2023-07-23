using System;
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

        static long Adminchatid = -1;

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

                Adminchatid = GetChatIdOfAdmin();
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }

        }

        public static void OnMessageReceive(ITelegramBotClient bot, Update update)
        {
            //ثبت نام کاربر

            TelUser newuser = new TelUser(update.Message.Chat.Username, update.Message.Chat.Id);

            if (info.Users.Contains(newuser))
                return;

            RigesterNewUser(newuser);
        }
        public static void OnTextMessageReceive(ITelegramBotClient bot, Update update)
        {
            try
            {
                if (update.Message.Text == "اطلاعات درس")
                    StudyInformationRequest(update.Message.Chat.Id);
                else if (update.Message.Text == "/start")
                    ChatInformationRequest(update.Message.Chat.Id);
                else if (update.Message.Text == "/code")
                    SourceCodeRequest(update.Message.Chat.Id);
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
                if (Adminchatid == -1)
                    System.Windows.Forms.MessageBox.Show("اخطار: ای دی شما در بات ثبت نام نشده. برای حل این مشکل لطفا به بات بروید و دستور /start را وارد کنید تا ثبت نام شوید.");

                HomeWorkSendRequest( update.Message);

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
        static void RigesterNewUser(TelUser newuser)
        {
            info.Users.Add(newuser);
            Informations.SaveInformation(info);
            Adminchatid = GetChatIdOfAdmin();

        }
        static void HomeWorkSendRequest(Message homework)
        {
            try
            {
                Bot.SendMessage(Adminchatid, $"تمرین ارسال شده از طرف: @{homework.Chat.Username} در زمان: {homework.Date}", Bot.ReplyKey);
                Bot.ForwardMessage(Adminchatid, homework.Chat.Id, homework);
                Bot.SendMessage(homework.Chat.Id, $"تمرین شما ثبت شد.", Bot.ReplyKey);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void StudyInformationRequest(long chatid)
        {
            Bot.SendMessage(chatid, info.Description, Bot.ReplyKey);
        }
        static void ChatInformationRequest(long chatid)
        {
            Bot.SendMessage(chatid, "سلام.\n این بات برای ارسال تمرینات دانشجویان است.\n تمرینات شما باید در قالب فایل یا تصویر باشد. \n در این صورت است که تمرین شما ارسال میشود. \n شماره چت شما: " + chatid + "\n توسعه بات توسط @Mohamadyali", Bot.ReplyKey);
        }

        //source code = https://github.com/AliiMohammadi/TelegramHomeWorkBot
        static void SourceCodeRequest(long chatid)
        {
            Bot.SendMessage(chatid, "سورس کد این بات: \r\n https://github.com/AliiMohammadi/TelegramHomeWorkBot", Bot.ReplyKey);
        }

        /// <summary>
        /// محسابه ای دی چت ادمین با پیدا کردنش از لیست افراد
        /// </summary>
        /// <returns></returns>
        static long GetChatIdOfAdmin()
        {
            foreach (var item in info.Users)
            {
                if (string.Equals(item.Username, info.AdminUserName.Replace("@","")))
                    return item.ChatID;
            }

            return -1;
        }
    }
}

//Ali Mohammadi
