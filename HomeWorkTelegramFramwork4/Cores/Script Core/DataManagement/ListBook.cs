using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramHomeWorkBot.Script_Core
{
    internal class ListBook
    {
        /// <summary>
        /// لیست افرادی که تابه حال از بات استفاده کرده اند
        /// </summary>
        public List<TelUser> Users;

        /// <summary>
        /// پیدا کردن یک یوز خاص با یوزر نیم ان
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public TelUser GetUserByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                return new TelUser();

            foreach (TelUser key in Users)
            {
                if (string.Equals(Melt(key.Username), Melt(username.Replace("@",""))))
                    return key;
            }

            return new TelUser();
        }

        static string Melt(string name)
        {
            return name.ToLower();
        }
    }
}
