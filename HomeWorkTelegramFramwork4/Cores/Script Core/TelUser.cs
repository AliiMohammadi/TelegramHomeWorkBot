using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramHomeWorkBot.Script_Core
{
    internal struct TelUser
    {
        public string Username { get; set; }
        public long ChatID { get; set; }

        public TelUser(string user , long chatid)
        {
            Username = user;
            ChatID = chatid;
        }
    }
}
