using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramHomeWorkBot.Script_Core
{
    internal class LocalData : ListBook
    {
        /// <summary>
        /// شماره سریال , شماره چت سرگروه با بات هستش که باید اینجا قرار بگیره
        /// </summary>
        public List<string> Admins { get; set; }
        /// <summary>
        /// اطلاعات , متنی است که هنگامی که کاربر روی دکمه اطلاعات درس کلیک میکند به کاربر میدهد
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// توکن باتی که استفاده میشود
        /// </summary>
        public string Token { get; set; }
    }
}
