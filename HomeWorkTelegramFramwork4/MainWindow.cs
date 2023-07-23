using System;
using System.Windows.Forms;
using TelegramHomeWorkBot.Script_Core;

namespace TelegramHomeWork
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            Initialize();
        }

        void Initialize()
        {
            try
            {
                InitializeComponent();
                DiActiveMode();

                Script.info = Informations.LoadInformation();

                FillForm(Script.info);
            }
            catch (Exception e )
            {
                MessageBox.Show(e.Message);
            }
        }
        void ActiveButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Tokentext.Text) || string.IsNullOrEmpty(AdminSerialtext.Text) || string.IsNullOrEmpty(Descriptiontext.Text))
            {
                MessageBox.Show("فیلد های بالا نباید خالی باشد. لطفا پرنمایید.");
                return;
            }

            if (!Script.Bot.IsActive)
            {
                Script.info.Token = Tokentext.Text;
                Script.info.AdminUserName = AdminSerialtext.Text;
                Script.info.Description = Descriptiontext.Text;

                Informations.SaveInformation(Script.info);

                Script.Initialaize();
                Script.Bot.SetActive(true);


                ActiveMode();
            }else
            if (Script.Bot.IsActive)
            {
                Script.Bot.SetActive(false);

                DiActiveMode();
            }
        }

        void FillForm(Informations info)
        {
            if (info == null)
                return;

            Tokentext.Text = info.Token;
            Descriptiontext.Text = info.Description;
            AdminSerialtext.Text = info.AdminUserName;
        }

        void ActiveMode()
        {
            ActiveButton.Text = "غیر فعال کردن";

            Tokentext.Enabled = false;
            AdminSerialtext.Enabled = false;
            Descriptiontext.Enabled = false;
        }
        void DiActiveMode()
        {
            ActiveButton.Text = "فعال کردن";

            Tokentext.Enabled = true;
            AdminSerialtext.Enabled = true;
            Descriptiontext.Enabled = true;
        }
    }
}