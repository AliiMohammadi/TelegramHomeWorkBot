using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramHomeWorkBot.Script_Core
{
    internal class Proposals
    {
        public static void HomeWorkSendRequest(Message homework, List<long> adminchatid)
        {
            try
            {
                foreach (long admin in adminchatid)
                {
                    Script.Bot.SendMessage(admin, $"تمرین ارسال شده از طرف: @{homework.Chat.Username} در زمان: {homework.Date}", Script.Bot.ReplyKey);
                    Script.Bot.ForwardMessage(admin, homework.Chat.Id, homework);
                }

                Script.Bot.SendMessage(homework.Chat.Id, $"تمرین شما ثبت شد.", Script.Bot.ReplyKey);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static void StudyInformationRequest(long chatid)
        {
            Script.Bot.SendMessage(chatid, Script.info.Description, Script.Bot.ReplyKey);
        }
        public static void ChatInformationRequest(long chatid)
        {
            Script.Bot.SendMessage(chatid, "سلام.\n این بات برای ارسال تمرینات دانشجویان است.\n تمرینات شما باید در قالب فایل یا تصویر باشد. \n در این صورت است که تمرین شما ارسال میشود. \n شماره چت شما: " + chatid + "\n توسعه بات توسط @Mohamadyali", Script.Bot.ReplyKey);
        }
        public static void SourceCodeRequest(long chatid)
        {
            //source code = https://github.com/AliiMohammadi/TelegramHomeWorkBot
            Script.Bot.SendMessage(chatid, "سورس کد این بات: \r\n https://github.com/AliiMohammadi/TelegramHomeWorkBot", Script.Bot.ReplyKey);
        }
        public static void LeaveFeedBackTo(long chatid, string message)
        {
            try
            {
                if (!IsAdmin(chatid))
                    return; // Users do not have premission to send feed back to others.

                char[] separators = new char[] { ' ' };
                string[] commandparts = string.Copy(message).Split(separators);

                if (!string.Equals(commandparts[0], "/to") || !commandparts[1].Contains('@'))
                    return;

                //commandparts[0] دستور
                //commandparts[1] یوزر دریافت کننده

                string Cleanmessage = string.Copy(message).Replace("/to", "").Replace(commandparts[1], "");

                TelUser user = Script.info.GetUserByUsername(commandparts[1]);

                Script.Bot.SendMessage(user.ChatID, $"پیام از طرف سرگروه به شما : \r\n {Cleanmessage}", Script.Bot.ReplyKey);
                Script.Bot.SendMessage(chatid, $"پیغام شما به {commandparts[1]} ارسال شد.", Script.Bot.ReplyKey);
            }
            catch (Exception e)
            {
                Script.Bot.SendMessage(chatid, $"خطای برنامه نویسی: \r\n {e.Message}", Script.Bot.ReplyKey);
            }
        }
        public static void SendMessageToAllUsers(long chatid, string message)
        {
            try
            {
                if (!IsAdmin(chatid))
                    return; // Users do not have premission to send feed back to others.


                if (!string.Equals(string.Copy(message).Substring(0,7), "/toall "))
                    return;

                //commandparts[0] دستور
                //commandparts[1] یوزر دریافت کننده

                string Cleanmessage = string.Copy(message).Replace("/toall ", "");

                foreach (TelUser user in Script.info.Users)
                {
                    if(!IsAdmin(user.ChatID))
                        Script.Bot.SendMessage(user.ChatID, $"پیام از طرف سرگروه به همه : \r\n {Cleanmessage}", Script.Bot.ReplyKey);
                }

                Script.Bot.SendMessage(chatid, $"پیام شما به همه کابرها ارسال شد.", Script.Bot.ReplyKey);
            }
            catch (Exception e)
            {
                Script.Bot.SendMessage(chatid, $"خطای برنامه نویسی: \r\n {e.Message}", Script.Bot.ReplyKey);
            }
        }

        static bool IsAdmin(long chatid)
        {
            return Script.adminschatid.Contains(chatid);
        }
    }
}
