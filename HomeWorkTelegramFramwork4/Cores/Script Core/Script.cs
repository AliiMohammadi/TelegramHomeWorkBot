using System;
using System.Linq;
using System.Collections.Generic;
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

        public static List<long> adminschatid;

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

                adminschatid = GetChatIdOfAdmin(info.Users, info.Admins);
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
                string textmessage = update.Message.Text;

                if (textmessage == "اطلاعات درس")
                    Proposals.StudyInformationRequest(update.Message.Chat.Id);
                else if (ItIsRequest(textmessage, "/start"))
                    Proposals.ChatInformationRequest(update.Message.Chat.Id);
                else if (ItIsRequest(textmessage, "/code") )
                    Proposals.SourceCodeRequest(update.Message.Chat.Id);
                else if (ItIsRequest(textmessage , "/to "))
                    Proposals.LeaveFeedBackTo(update.Message.Chat.Id, textmessage);
                else if (ItIsRequest(textmessage, "/toall "))
                    Proposals.SendMessageToAllUsers(update.Message.Chat.Id, textmessage);
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
                Proposals.HomeWorkSendRequest(update.Message,adminschatid);
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
                if (adminschatid.Count == 0)
                    System.Windows.Forms.MessageBox.Show("اخطار: ای دی شما در بات ثبت نام نشده. برای حل این مشکل لطفا به بات بروید و دستور /start را وارد کنید تا ثبت نام شوید.");

                Proposals.HomeWorkSendRequest(update.Message, adminschatid);

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
            adminschatid = GetChatIdOfAdmin(info.Users, info.Admins);

        }
        static bool ItIsRequest(string message,string command)
        {
            string text = string.Copy(message);

            if(message.Length == command.Length)
                return (string.Equals(text, command));
            else
                return (string.Equals(text.Remove(command.Length), command));
        }

        /// <summary>
        /// محسابه ای دی چت های ادمین ها با پیدا کردنشون از لیست افراد
        /// </summary>
        /// <returns></returns>
        static List<long> GetChatIdOfAdmin(List<TelUser> users,List<string> admins)
        {
            List<long> foundedadmins = new List<long>();

            foreach (var user in users)
            {
                foreach (var admin in admins)
                {
                    if (string.Equals(user.Username, admin.Replace("@", "")))
                        foundedadmins.Add(user.ChatID);
                }
            }
            
            return foundedadmins;
        }
    }
}

//Ali Mohammadi
