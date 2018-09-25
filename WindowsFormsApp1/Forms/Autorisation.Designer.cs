namespace WindowsFormsApp1
{
    partial class Autorisation
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.login_p = new System.Windows.Forms.TextBox();
            this.password_p = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dbname = new System.Windows.Forms.TextBox();
            this.host = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 208);
            this.button1.MaximumSize = new System.Drawing.Size(141, 23);
            this.button1.MinimumSize = new System.Drawing.Size(141, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Вход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // login_p
            // 
            this.login_p.Location = new System.Drawing.Point(12, 37);
            this.login_p.Name = "login_p";
            this.login_p.Size = new System.Drawing.Size(260, 20);
            this.login_p.TabIndex = 1;
            // 
            // password_p
            // 
            this.password_p.Location = new System.Drawing.Point(12, 84);
            this.password_p.Name = "password_p";
            this.password_p.Size = new System.Drawing.Size(260, 20);
            this.password_p.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(9, 256);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 173);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тестировочная панель";
            // 
            // dbname
            // 
            this.dbname.Location = new System.Drawing.Point(12, 177);
            this.dbname.Name = "dbname";
            this.dbname.Size = new System.Drawing.Size(260, 20);
            this.dbname.TabIndex = 3;
            // 
            // host
            // 
            this.host.Location = new System.Drawing.Point(12, 131);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(260, 20);
            this.host.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(20, 146);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(237, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "обновить конфиги";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "загрузить конфиги";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Хост";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Имя БД";
            // 
            // Autorisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 245);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dbname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.host);
            this.Controls.Add(this.password_p);
            this.Controls.Add(this.login_p);
            this.Controls.Add(this.button1);
            this.Name = "Autorisation";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox login_p;
        private System.Windows.Forms.TextBox password_p;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox dbname;
        private System.Windows.Forms.TextBox host;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}