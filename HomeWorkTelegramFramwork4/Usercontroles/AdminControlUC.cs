using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelegramHomeWork;
using UserInterface;

namespace Usercontroles
{
    public partial class AdminControlUC : UserControl
    {
        public AdminControlUC()
        {
            InitializeComponent();
        }

        private void Removebtn_Click(object sender, EventArgs e)
        {
            MainWindow.Mainwindow.RemoveButton_Click(sender, e);
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            MainWindow.Mainwindow.AddButton_Click(sender, e);
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            PanelControler.ShowMainPanel();
        }
    }
}
