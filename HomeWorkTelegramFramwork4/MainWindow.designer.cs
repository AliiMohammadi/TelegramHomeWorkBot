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
            this.Tokentext = new System.Windows.Forms.TextBox();
            this.AdminSerialtext = new System.Windows.Forms.TextBox();
            this.Descriptiontext = new System.Windows.Forms.TextBox();
            this.ActiveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Adminslistbox = new System.Windows.Forms.ListBox();
            this.Addbtn = new System.Windows.Forms.Button();
            this.Removebtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Tokentext
            // 
            this.Tokentext.Location = new System.Drawing.Point(224, 60);
            this.Tokentext.Name = "Tokentext";
            this.Tokentext.Size = new System.Drawing.Size(367, 20);
            this.Tokentext.TabIndex = 0;
            // 
            // AdminSerialtext
            // 
            this.AdminSerialtext.Location = new System.Drawing.Point(3, 60);
            this.AdminSerialtext.Name = "AdminSerialtext";
            this.AdminSerialtext.Size = new System.Drawing.Size(215, 20);
            this.AdminSerialtext.TabIndex = 1;
            // 
            // Descriptiontext
            // 
            this.Descriptiontext.Location = new System.Drawing.Point(224, 101);
            this.Descriptiontext.Multiline = true;
            this.Descriptiontext.Name = "Descriptiontext";
            this.Descriptiontext.Size = new System.Drawing.Size(367, 97);
            this.Descriptiontext.TabIndex = 2;
            this.Descriptiontext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ActiveButton
            // 
            this.ActiveButton.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.ActiveButton.Location = new System.Drawing.Point(224, 204);
            this.ActiveButton.Name = "ActiveButton";
            this.ActiveButton.Size = new System.Drawing.Size(364, 76);
            this.ActiveButton.TabIndex = 3;
            this.ActiveButton.Text = "فعال کردن";
            this.ActiveButton.UseVisualStyleBackColor = true;
            this.ActiveButton.Click += new System.EventHandler(this.ActiveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "توکن";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ادمین جدید";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "توضیحات درس";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(425, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "ربات تلگرام ارسال تمرین";
            // 
            // Adminslistbox
            // 
            this.Adminslistbox.FormattingEnabled = true;
            this.Adminslistbox.Location = new System.Drawing.Point(3, 101);
            this.Adminslistbox.Name = "Adminslistbox";
            this.Adminslistbox.Size = new System.Drawing.Size(215, 82);
            this.Adminslistbox.TabIndex = 8;
            // 
            // Addbtn
            // 
            this.Addbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addbtn.Location = new System.Drawing.Point(3, 189);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(103, 23);
            this.Addbtn.TabIndex = 9;
            this.Addbtn.Text = "+";
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Removebtn
            // 
            this.Removebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Removebtn.Location = new System.Drawing.Point(115, 189);
            this.Removebtn.Name = "Removebtn";
            this.Removebtn.Size = new System.Drawing.Size(103, 23);
            this.Removebtn.TabIndex = 10;
            this.Removebtn.Text = "-";
            this.Removebtn.UseVisualStyleBackColor = true;
            this.Removebtn.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "لیست ادمین ها";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 294);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Removebtn);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.Adminslistbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ActiveButton);
            this.Controls.Add(this.Descriptiontext);
            this.Controls.Add(this.AdminSerialtext);
            this.Controls.Add(this.Tokentext);
            this.Name = "MainWindow";
            this.Text = "ربات ارسال تمرین- توسعه توسط علی محمدی";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox Tokentext;
        private TextBox AdminSerialtext;
        private TextBox Descriptiontext;
        private Button ActiveButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListBox Adminslistbox;
        private Button Addbtn;
        private Button Removebtn;
        private Label label5;
    }
}