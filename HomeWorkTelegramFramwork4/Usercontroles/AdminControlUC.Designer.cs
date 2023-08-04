namespace Usercontroles
{
    partial class AdminControlUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.Removebtn = new System.Windows.Forms.Button();
            this.Addbtn = new System.Windows.Forms.Button();
            this.Adminslistbox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AdminSerialtext = new System.Windows.Forms.TextBox();
            this.BackBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "لیست ادمین ها";
            // 
            // Removebtn
            // 
            this.Removebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Removebtn.Location = new System.Drawing.Point(118, 165);
            this.Removebtn.Name = "Removebtn";
            this.Removebtn.Size = new System.Drawing.Size(103, 23);
            this.Removebtn.TabIndex = 16;
            this.Removebtn.Text = "-";
            this.Removebtn.UseVisualStyleBackColor = true;
            this.Removebtn.Click += new System.EventHandler(this.Removebtn_Click);
            // 
            // Addbtn
            // 
            this.Addbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addbtn.Location = new System.Drawing.Point(6, 165);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(103, 23);
            this.Addbtn.TabIndex = 15;
            this.Addbtn.Text = "+";
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // Adminslistbox
            // 
            this.Adminslistbox.FormattingEnabled = true;
            this.Adminslistbox.Location = new System.Drawing.Point(6, 77);
            this.Adminslistbox.Name = "Adminslistbox";
            this.Adminslistbox.Size = new System.Drawing.Size(215, 82);
            this.Adminslistbox.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "ادمین جدید";
            // 
            // AdminSerialtext
            // 
            this.AdminSerialtext.Location = new System.Drawing.Point(6, 36);
            this.AdminSerialtext.Name = "AdminSerialtext";
            this.AdminSerialtext.Size = new System.Drawing.Size(215, 20);
            this.AdminSerialtext.TabIndex = 12;
            // 
            // BackBTN
            // 
            this.BackBTN.Location = new System.Drawing.Point(6, 10);
            this.BackBTN.Name = "BackBTN";
            this.BackBTN.Size = new System.Drawing.Size(75, 23);
            this.BackBTN.TabIndex = 22;
            this.BackBTN.Text = "برگشت";
            this.BackBTN.UseVisualStyleBackColor = true;
            this.BackBTN.Click += new System.EventHandler(this.BackBTN_Click);
            // 
            // AdminControlUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BackBTN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Removebtn);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.Adminslistbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AdminSerialtext);
            this.Name = "AdminControlUC";
            this.Size = new System.Drawing.Size(224, 190);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button Removebtn;
        public System.Windows.Forms.Button Addbtn;
        public System.Windows.Forms.ListBox Adminslistbox;
        public System.Windows.Forms.TextBox AdminSerialtext;
        private System.Windows.Forms.Button BackBTN;
    }
}
