


using System.Data.SqlClient;


namespace Shoprite_Product_Manager_IA
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RoleCb = new System.Windows.Forms.ComboBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_userpasword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(255, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shoprite Ghana LTD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(355, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "LOGIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(255, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "USERNAME";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(190, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 28);
            this.label4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(254, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "PASSWORD";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // RoleCb
            // 
            this.RoleCb.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RoleCb.ForeColor = System.Drawing.Color.Red;
            this.RoleCb.FormattingEnabled = true;
            this.RoleCb.Items.AddRange(new object[] {
            "ADMIN",
            "ATTENDANT"});
            this.RoleCb.Location = new System.Drawing.Point(298, 135);
            this.RoleCb.Name = "RoleCb";
            this.RoleCb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RoleCb.Size = new System.Drawing.Size(135, 23);
            this.RoleCb.TabIndex = 5;
            this.RoleCb.Text = "SELECT A ROLE ";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(395, 196);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(136, 23);
            this.txt_username.TabIndex = 6;
            // 
            // txt_userpasword
            // 
            this.txt_userpasword.Location = new System.Drawing.Point(395, 240);
            this.txt_userpasword.Name = "txt_userpasword";
            this.txt_userpasword.Size = new System.Drawing.Size(136, 23);
            this.txt_userpasword.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(409, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(448, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "Clear";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(559, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 29);
            this.label7.TabIndex = 10;
            this.label7.Text = "x";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Shoprite_Product_Manager_IA.Properties.Resources.shoprite_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(586, 366);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_userpasword);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.RoleCb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox1;
        private TextBox txt_username;
        private TextBox txt_userpasword;
        public Button button1;
        private Label label6;
        private Label label7;
        private ComboBox RoleCb;
    }
}