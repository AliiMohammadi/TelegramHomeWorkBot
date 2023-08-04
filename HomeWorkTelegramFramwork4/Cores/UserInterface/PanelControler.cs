using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usercontroles;

namespace UserInterface
{

    internal class PanelControler
    {
        public static MainPanel mainpanel;
        public static OptionsUC optionspanel;
        public static UsersControlUC userpanel;
        public static AdminControlUC adminpanel;

        public static void ShowMainPanel()
        {

            mainpanel.Show();
            optionspanel.Hide();
            userpanel.Hide();
            adminpanel.Hide();
        }
        public static void ShowOptionsPanel()
        {
            mainpanel.Hide();
            optionspanel.Show();
            userpanel.Hide();
            adminpanel.Hide();
        }
        public static void ShowUserPanel()
        {
            mainpanel.Hide();
            optionspanel.Hide();
            userpanel.Show();
            adminpanel.Hide();
        }
        public static void ShowAdminPanel()
        {
            mainpanel.Hide();
            optionspanel.Hide();
            userpanel.Hide();
            adminpanel.Show();
        }
    }
}
