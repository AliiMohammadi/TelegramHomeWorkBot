using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramLean
{
    /// <summary>
    /// کلاس سطح بالا برای ارسال درخواست یا دستور دادن به بات تلگرام
    /// </summary>
    internal class TelegramBot : TelBotInfo
    {
        private bool Active = false;

        public delegate void OnMessage(ITelegramBotClient bot, Update update);

        public OnMessage OnMessageReceive;
        public OnMessage OnTextMessageReceive;
        public OnMessage OnPhotoMessageReceive;
        public OnMessage OnDocumentMessageReceive;

        public bool IsActive
        {
            get { return Active; }
        }

        public TelegramBot(string token)
        {
            ReceiverOptions reciveroptions = new ReceiverOptions();
            reciveroptions.AllowedUpdates = new UpdateType[] { UpdateType.Message, UpdateType.EditedMessage };
            SetToken(token);
            TelBotClient = new TelegramBotClient(token);
            TelBotClient.StartReceiving(OnReceive,ErrorHandeler, reciveroptions);
        }

        async Task ErrorHandeler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            Console.WriteLine(arg2.Message);
        }

        async Task OnReceive(ITelegramBotClient bot, Update update, CancellationToken arg3)
        {
            try
            {
                if (!Active)
                    return;

                OnMessageReceive(bot, update);

                if (update.Type != UpdateType.Message)
                    return;

                if (update.Message.Type == MessageType.Text)
                    OnTextMessageReceive(bot, update);

                if (update.Message.Type == MessageType.Photo)
                    OnPhotoMessageReceive(bot, update);

                if (update.Message.Type == MessageType.Document)
                    OnDocumentMessageReceive(bot, update);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// حالت فعال سازی کذار بات
        /// </summary>
        /// <param name="active"></param>
        public void SetActive(bool active)
        {
            Active = active;
        }
        /// <summary>
        /// مقدار توکن بات
        /// </summary>
        /// <param name="token"></param>
        public void SetToken(string token)
        {
            Token = token;
        }
        /// <summary>
        /// توکن حال حاظر بات
        /// </summary>
        /// <returns></returns>
        public string GetToken()
        {
            return Token;
        }

        /// <summary>
        /// ارسال پیغام به چت
        /// </summary>
        /// <param name="ChatID"></param>
        /// <param name="message"></param>
        /// <param name="rkm"></param>
        public async void SendMessage(long ChatID,string message)
        {
            try
            {
                await TelBotClient.SendTextMessageAsync(ChatID, message);

            }
            catch (Exception) { 
                throw;
            }
        }
        /// <summary>
        /// ارسال پیغام به چت
        /// </summary>
        /// <param name="ChatID"></param>
        /// <param name="message"></param>
        /// <param name="rkm"></param>
        public async void SendMessage(long ChatID, string message,int replymessage)
        {
            try
            {
                await TelBotClient.SendTextMessageAsync(ChatID, message, null, null,null,null,null,null, replymessage);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// ارسال پیغام به چت
        /// </summary>
        /// <param name="ChatID"></param>
        /// <param name="message"></param>
        /// <param name="rkm"></param>
        public async void SendMessage(long ChatID, string message,ReplyKeyboardMarkup rkm)
        {
            try
            {
                await TelBotClient.SendTextMessageAsync(ChatID, message, null, null, null, null, null, null, null, null, rkm);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// ارسال پیغام به چت
        /// </summary>
        /// <param name="ChatID"></param>
        /// <param name="message"></param>
        /// <param name="rkm"></param>
        public async void SendMessage(long ChatID, string message,int replymessgae, ReplyKeyboardMarkup rkm)
        {
            try
            {
                await TelBotClient.SendTextMessageAsync(ChatID, message, null, null, null, null, null, null, replymessgae, null, rkm);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// فروارد پیغام
        /// </summary>
        /// <param name="ChatID"></param>
        /// <param name="message"></param>
        /// <param name="rkm"></param>
        public async void ForwardMessage(long chatid, long Fromchatid, Message message)
        {
            try
            {
                await TelBotClient.ForwardMessageAsync(chatid, Fromchatid, message.MessageId);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// مشخص کردن دکمه های اماده چت بات
        /// </summary>
        /// <param name="rk"></param>
        public void SetReplyKeyboard(ReplyKeyboardMarkup rk)
        {
            ReplyKey = rk;
        }
        public void SaveImage(PhotoSize[] photo,string path)
        {
            DownloadFile(TelBotClient, photo.Last().FileId,path);
        }
        public void SaveDocument(Document doc, string path)
        {
            DownloadFile(TelBotClient, doc.FileId, path);
        }

        async void DownloadFile(ITelegramBotClient bot, string fileId, string path)
        {
            try
            {
                var file = await bot.GetFileAsync(fileId);

                using (var saveImageStream = new FileStream(path, FileMode.Create))
                {
                    await bot.DownloadFileAsync(file.FilePath, saveImageStream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Can not donload media : {ex.Message}");
            }
        }
    }
}
