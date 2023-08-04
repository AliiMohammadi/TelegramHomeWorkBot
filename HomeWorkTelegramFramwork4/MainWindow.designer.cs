using System.Windows.Forms;

namespace TelegramHomeWork
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ActiveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mainPanel1 = new Usercontroles.MainPanel();
            this.adminControlUC1 = new Usercontroles.AdminControlUC();
            this.usersControlUC1 = new Usercontroles.UsersControlUC();
            this.optionsUC1 = new Usercontroles.OptionsUC();
            this.SuspendLayout();
            // 
            // ActiveButton
            // 
            this.ActiveButton.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.ActiveButton.Location = new System.Drawing.Point(7, 234);
            this.ActiveButton.Name = "ActiveButton";
            this.ActiveButton.Size = new System.Drawing.Size(364, 76);
            this.ActiveButton.TabIndex = 3;
            this.ActiveButton.Text = "فعال کردن";
            this.ActiveButton.UseVisualStyleBackColor = true;
            this.ActiveButton.Click += new System.EventHandler(this.ActiveButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(210, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "ربات تلگرام ارسال تمرین";
            // 
            // mainPanel1
            // 
            this.mainPanel1.Location = new System.Drawing.Point(7, 91);
            this.mainPanel1.Name = "mainPanel1";
            this.mainPanel1.Size = new System.Drawing.Size(375, 85);
            this.mainPanel1.TabIndex = 8;
            // 
            // adminControlUC1
            // 
            this.adminControlUC1.Location = new System.Drawing.Point(72, 33);
            this.adminControlUC1.Name = "adminControlUC1";
            this.adminControlUC1.Size = new System.Drawing.Size(224, 195);
            this.adminControlUC1.TabIndex = 11;
            // 
            // usersControlUC1
            // 
            this.usersControlUC1.Location = new System.Drawing.Point(73, 45);
            this.usersControlUC1.Name = "usersControlUC1";
            this.usersControlUC1.Size = new System.Drawing.Size(223, 183);
            this.usersControlUC1.TabIndex = 10;
            // 
            // optionsUC1
            // 
            this.optionsUC1.Location = new System.Drawing.Point(2, 33);
            this.optionsUC1.Name = "optionsUC1";
            this.optionsUC1.Size = new System.Drawing.Size(380, 195);
            this.optionsUC1.TabIndex = 9;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 314);
            this.Controls.Add(this.optionsUC1);
            this.Controls.Add(this.usersControlUC1);
            this.Controls.Add(this.mainPanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ActiveButton);
            this.Controls.Add(this.adminControlUC1);
            this.Name = "MainWindow";
            this.Text = "ربات ارسال تمرین- توسعه توسط علی محمدی";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button ActiveButton;
        private Label label4;
        private Usercontroles.MainPanel mainPanel1;
        private Usercontroles.OptionsUC optionsUC1;
        private Usercontroles.UsersControlUC usersControlUC1;
        private Usercontroles.AdminControlUC adminControlUC1;
    }
}