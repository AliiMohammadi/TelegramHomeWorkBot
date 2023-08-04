using System;
using System.Linq;
using System.Windows.Forms;
using TelegramHomeWorkBot.Script_Core;
using Usercontroles;
using UserInterface;

namespace TelegramHomeWork
{
    public partial class MainWindow : Form
    {
        public static MainWindow Mainwindow;

        public MainWindow()
        {
            Initialize();
        }

        void Initialize()
        {
            try
            {
                InitializeComponent();
                Mainwindow = this;
                PanelmanagerRefrencesset();
                PanelControler.ShowMainPanel();
                DiactiveMode();

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
            if(string.IsNullOrEmpty(optionsUC1.Tokentext.Text) || adminControlUC1.Adminslistbox.Items.Count == 0|| string.IsNullOrEmpty(optionsUC1.Descriptiontext.Text))
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

                DiactiveMode();
            }
        }

        void PanelmanagerRefrencesset()
        {
            PanelControler.mainpanel = mainPanel1;
            PanelControler.optionspanel = optionsUC1;
            PanelControler.adminpanel = adminControlUC1;
            PanelControler.userpanel = usersControlUC1;
        }
        void FillForm(Informations info)
        {
            if (info == null)
                return;

            optionsUC1.Tokentext.Text = info.Token;
            optionsUC1.Descriptiontext.Text = info.Description;
            usersControlUC1.Usercounttxt.Text = info.Users.Count.ToString();

            //پرکردن لیست کاربران
            foreach (var users in info.Users)
            {
                usersControlUC1.UsersListBox.Items.Add(users.Username);
            }
            //پرکدن لیست ادمین ها
            foreach (string adminusername in info.Admins)
            {
                adminControlUC1.Adminslistbox.Items.Add(adminusername);
            }
        }

        void SaveInformations()
        {
            Script.info.Token = optionsUC1.Tokentext.Text;
            Script.info.Admins = adminControlUC1.Adminslistbox.Items.Cast<string>().ToList();
            Script.info.Description = optionsUC1.Descriptiontext.Text;

            Informations.SaveInformation(Script.info);
        }
        void ActiveMode()
        {
            ActiveButton.Text = "غیر فعال کردن";

            optionsUC1.Tokentext.Enabled = false;
            adminControlUC1.AdminSerialtext.Enabled = false;
            optionsUC1.Descriptiontext.Enabled = false;
            adminControlUC1.Adminslistbox.Enabled = false;
            adminControlUC1.Addbtn.Enabled = false;
            adminControlUC1.Removebtn.Enabled = false;
            usersControlUC1.UsersListBox.Enabled = false;

        }
        void DiactiveMode()
        {
            ActiveButton.Text = "فعال کردن";

            optionsUC1.Tokentext.Enabled = true;
            adminControlUC1.AdminSerialtext.Enabled = true;
            optionsUC1.Descriptiontext.Enabled = true;
            adminControlUC1.Adminslistbox.Enabled = true;
            adminControlUC1.Addbtn.Enabled = true;
            adminControlUC1.Removebtn.Enabled = true;
            usersControlUC1.UsersListBox.Enabled = true;
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(adminControlUC1.AdminSerialtext.Text))
                return;

            adminControlUC1.Adminslistbox.Items.Add(adminControlUC1.AdminSerialtext.Text);
            adminControlUC1.AdminSerialtext.Clear();
            SaveInformations();
        }

        public void RemoveButton_Click(object sender, EventArgs e)
        {
            if (adminControlUC1.Adminslistbox.SelectedIndex < 0)
                return;

            adminControlUC1.Adminslistbox.Items.RemoveAt(adminControlUC1.Adminslistbox.SelectedIndex);
            SaveInformations();

        }
    }
}