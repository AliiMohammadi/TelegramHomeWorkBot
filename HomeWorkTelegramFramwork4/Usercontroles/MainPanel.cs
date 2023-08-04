using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface;

namespace Usercontroles
{
    public partial class MainPanel : UserControl
    {
        public MainPanel()
        {
            InitializeComponent();
        }

        private void Optionsbtn_Click(object sender, EventArgs e)
        {
            PanelControler.ShowOptionsPanel();
        }

        private void Usersbtn_Click(object sender, EventArgs e)
        {
            PanelControler.ShowUserPanel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PanelControler.ShowAdminPanel();
        }
    }
}
