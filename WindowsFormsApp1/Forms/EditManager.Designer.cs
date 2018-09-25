namespace WindowsFormsApp1.Forms
{
    partial class EditManager
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
            this.Ok = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rb_a = new System.Windows.Forms.RadioButton();
            this.rb_u = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_mp = new System.Windows.Forms.TextBox();
            this.tb_ml = new System.Windows.Forms.TextBox();
            this.tb_pa = new System.Windows.Forms.TextBox();
            this.tb_lo = new System.Windows.Forms.TextBox();
            this.tb_fi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Ok
            // 
            this.Ok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok.Location = new System.Drawing.Point(12, 217);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(385, 23);
            this.Ok.TabIndex = 0;
            this.Ok.Text = "ОК";
            this.Ok.UseMnemonic = false;
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.Location = new System.Drawing.Point(12, 251);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(385, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseMnemonic = false;
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ф.И.О.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Адрес почты";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Пароль почты";
            // 
            // rb_a
            // 
            this.rb_a.AutoSize = true;
            this.rb_a.Location = new System.Drawing.Point(146, 194);
            this.rb_a.Name = "rb_a";
            this.rb_a.Size = new System.Drawing.Size(104, 17);
            this.rb_a.TabIndex = 7;
            this.rb_a.Text = "Администратор";
            this.rb_a.UseVisualStyleBackColor = true;
            // 
            // rb_u
            // 
            this.rb_u.AutoSize = true;
            this.rb_u.Checked = true;
            this.rb_u.Location = new System.Drawing.Point(146, 171);
            this.rb_u.Name = "rb_u";
            this.rb_u.Size = new System.Drawing.Size(98, 17);
            this.rb_u.TabIndex = 8;
            this.rb_u.TabStop = true;
            this.rb_u.Text = "Пользователь";
            this.rb_u.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Уровень доступа";
            // 
            // tb_mp
            // 
            this.tb_mp.Location = new System.Drawing.Point(146, 134);
            this.tb_mp.Name = "tb_mp";
            this.tb_mp.Size = new System.Drawing.Size(251, 20);
            this.tb_mp.TabIndex = 10;
            // 
            // tb_ml
            // 
            this.tb_ml.Location = new System.Drawing.Point(146, 103);
            this.tb_ml.Name = "tb_ml";
            this.tb_ml.Size = new System.Drawing.Size(251, 20);
            this.tb_ml.TabIndex = 11;
            this.tb_ml.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // tb_pa
            // 
            this.tb_pa.Location = new System.Drawing.Point(146, 71);
            this.tb_pa.Name = "tb_pa";
            this.tb_pa.Size = new System.Drawing.Size(251, 20);
            this.tb_pa.TabIndex = 12;
            // 
            // tb_lo
            // 
            this.tb_lo.Location = new System.Drawing.Point(146, 39);
            this.tb_lo.Name = "tb_lo";
            this.tb_lo.Size = new System.Drawing.Size(251, 20);
            this.tb_lo.TabIndex = 13;
            this.tb_lo.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // tb_fi
            // 
            this.tb_fi.Location = new System.Drawing.Point(146, 10);
            this.tb_fi.Name = "tb_fi";
            this.tb_fi.Size = new System.Drawing.Size(251, 20);
            this.tb_fi.TabIndex = 14;
            // 
            // EditManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 283);
            this.Controls.Add(this.tb_fi);
            this.Controls.Add(this.tb_lo);
            this.Controls.Add(this.tb_pa);
            this.Controls.Add(this.tb_ml);
            this.Controls.Add(this.tb_mp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rb_u);
            this.Controls.Add(this.rb_a);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Ok);
            this.MaximumSize = new System.Drawing.Size(425, 322);
            this.MinimumSize = new System.Drawing.Size(425, 322);
            this.Name = "EditManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rb_a;
        private System.Windows.Forms.RadioButton rb_u;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_mp;
        private System.Windows.Forms.TextBox tb_ml;
        private System.Windows.Forms.TextBox tb_pa;
        private System.Windows.Forms.TextBox tb_lo;
        private System.Windows.Forms.TextBox tb_fi;
    }
}