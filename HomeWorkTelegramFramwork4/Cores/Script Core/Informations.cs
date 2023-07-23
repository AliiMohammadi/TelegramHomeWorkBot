using TelegramHomeWorkBot.Script_Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace TelegramHomeWorkBot.Script_Core
{
    /// <summary>
    /// کلاس اطلاعات قابل تنظیم توسط سرگروه 
    /// </summary>
    internal class Informations
    {
        /// <summary>
        /// شماره سریال , شماره چت سرگروه با بات هستش که باید اینجا قرار بگیره
        /// </summary>
        public string AdminUserName { get; set; }
        /// <summary>
        /// اطلاعات , متنی است که هنگامی که کاربر روی دکمه اطلاعات درس کلیک میکند به کاربر میدهد
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// توکن باتی که استفاده میشود
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// لیست افرادی که تابه حال از بات استفاده کرده اند
        /// </summary>
        public List<TelUser> Users;

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
