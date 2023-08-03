using TelegramHomeWorkBot.Script_Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace TelegramHomeWorkBot.Script_Core
{
    /// <summary>
    /// کلاس اطلاعات قابل تنظیم توسط سرگروه 
    /// </summary>
    internal class Informations : LocalData
    {
        public Informations()
        {
            Description = "";
            Token = "";

            Users = new List<TelUser>();
        }

        /// <summary>
        /// ادرس محل ذخیره اطلاعات برنامه
        /// </summary>
        public static string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Homeworkbot.data";
        
        /// <summary>
        /// ذخیره اطلاعات 
        /// </summary>
        /// <param name="info"></param>
        public static void SaveInformation(Informations info)
        {
            SaveAndRetrieve.JsonSaveData.SaveData(info, SavePath);
        }
        /// <summary>
        /// بارگیری اطلاعات
        /// </summary>
        /// <returns></returns>
        public static Informations LoadInformation()
        {
            if(File.Exists(SavePath))
                return SaveAndRetrieve.JsonSaveData.LoadData<Informations>(SavePath);
            else 
                return new Informations();
        }
    }
}
