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
            this.SuspendLayout();
            // 
            // Tokentext
            // 
            this.Tokentext.Location = new System.Drawing.Point(10, 62);
            this.Tokentext.Name = "Tokentext";
            this.Tokentext.Size = new System.Drawing.Size(323, 20);
            this.Tokentext.TabIndex = 0;
            // 
            // AdminSerialtext
            // 
            this.AdminSerialtext.Location = new System.Drawing.Point(10, 110);
            this.AdminSerialtext.Name = "AdminSerialtext";
            this.AdminSerialtext.Size = new System.Drawing.Size(323, 20);
            this.AdminSerialtext.TabIndex = 1;
            // 
            // Descriptiontext
            // 
            this.Descriptiontext.Location = new System.Drawing.Point(10, 148);
            this.Descriptiontext.Multiline = true;
            this.Descriptiontext.Name = "Descriptiontext";
            this.Descriptiontext.Size = new System.Drawing.Size(323, 97);
            this.Descriptiontext.TabIndex = 2;
            // 
            // ActiveButton
            // 
            this.ActiveButton.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.ActiveButton.Location = new System.Drawing.Point(75, 263);
            this.ActiveButton.Name = "ActiveButton";
            this.ActiveButton.Size = new System.Drawing.Size(185, 56);
            this.ActiveButton.TabIndex = 3;
            this.ActiveButton.Text = "فعال کردن";
            this.ActiveButton.UseVisualStyleBackColor = true;
            this.ActiveButton.Click += new System.EventHandler(this.ActiveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "توکن";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Adming chat id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "توضیحات درس";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(190, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "ربات تلگرام ارسال تمرین";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 339);
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
    }
}