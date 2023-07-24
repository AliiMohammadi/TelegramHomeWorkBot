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

        public static long Adminchatid = -1;

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
                    Proposals.StudyInformationRequest(update.Message.Chat.Id);
                else if (update.Message.Text == "/start")
                    Proposals.ChatInformationRequest(update.Message.Chat.Id);
                else if (update.Message.Text == "/code")
                    Proposals.SourceCodeRequest(update.Message.Chat.Id);
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
                Proposals.HomeWorkSendRequest(update.Message);
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

                Proposals.HomeWorkSendRequest( update.Message);

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
