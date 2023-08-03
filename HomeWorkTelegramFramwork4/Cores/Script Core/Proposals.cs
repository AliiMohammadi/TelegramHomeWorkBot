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
                foreach(long admin in adminchatid)
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
    }
}
