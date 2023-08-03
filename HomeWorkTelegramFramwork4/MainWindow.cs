using System;
using System.Linq;
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
            if(string.IsNullOrEmpty(Tokentext.Text) || Adminslistbox.Items.Count == 0|| string.IsNullOrEmpty(Descriptiontext.Text))
            {
                MessageBox.Show("فیلد های بالا نباید خالی باشد. لطفا پرنمایید.");
                return;
            }

            if (!Script.Bot.IsActive)
            {
                SaveInformations();

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

            foreach (string adminusername in info.Admins)
            {
                Adminslistbox.Items.Add(adminusername);
            }
        }

        void SaveInformations()
        {
            Script.info.Token = Tokentext.Text;
            Script.info.Admins = Adminslistbox.Items.Cast<string>().ToList();
            Script.info.Description = Descriptiontext.Text;

            Informations.SaveInformation(Script.info);
        }

        void ActiveMode()
        {
            ActiveButton.Text = "غیر فعال کردن";

            Tokentext.Enabled = false;
            AdminSerialtext.Enabled = false;
            Descriptiontext.Enabled = false;
            Adminslistbox.Enabled = false;
            Addbtn.Enabled = false;
            Removebtn.Enabled = false;
        }
        void DiActiveMode()
        {
            ActiveButton.Text = "فعال کردن";

            Tokentext.Enabled = true;
            AdminSerialtext.Enabled = true;
            Descriptiontext.Enabled = true;
            Adminslistbox.Enabled = true;
            Addbtn.Enabled = true;
            Removebtn.Enabled = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AdminSerialtext.Text))
                return;

            Adminslistbox.Items.Add(AdminSerialtext.Text);
            AdminSerialtext.Clear();
            SaveInformations();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (Adminslistbox.SelectedIndex < 0)
                return;

            Adminslistbox.Items.RemoveAt(Adminslistbox.SelectedIndex);
            SaveInformations();

        }
    }
}