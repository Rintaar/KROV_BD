namespace WindowsFormsApp1.Forms
{
    partial class Mailform
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
            this.tb_sub = new System.Windows.Forms.TextBox();
            this.tb_text = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_adr = new System.Windows.Forms.ComboBox();
            this.Del_but = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_sub
            // 
            this.tb_sub.Location = new System.Drawing.Point(94, 52);
            this.tb_sub.Name = "tb_sub";
            this.tb_sub.Size = new System.Drawing.Size(392, 20);
            this.tb_sub.TabIndex = 1;
            // 
            // tb_text
            // 
            this.tb_text.Location = new System.Drawing.Point(95, 82);
            this.tb_text.Multiline = true;
            this.tb_text.Name = "tb_text";
            this.tb_text.Size = new System.Drawing.Size(391, 163);
            this.tb_text.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Отправить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(294, 257);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Отменить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Кому:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Текст:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Тема:";
            // 
            // cb_adr
            // 
            this.cb_adr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cb_adr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_adr.FormattingEnabled = true;
            this.cb_adr.Location = new System.Drawing.Point(94, 18);
            this.cb_adr.Name = "cb_adr";
            this.cb_adr.Size = new System.Drawing.Size(284, 21);
            this.cb_adr.TabIndex = 9;
            this.cb_adr.SelectedIndexChanged += new System.EventHandler(this.cb_adr_SelectedIndexChanged);
            this.cb_adr.TextUpdate += new System.EventHandler(this.cb_adr_TextUpdate);
            this.cb_adr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_adr_KeyDown);
            // 
            // Del_but
            // 
            this.Del_but.Location = new System.Drawing.Point(384, 17);
            this.Del_but.Name = "Del_but";
            this.Del_but.Size = new System.Drawing.Size(101, 23);
            this.Del_but.TabIndex = 10;
            this.Del_but.Text = "Удалить адрес";
            this.Del_but.UseVisualStyleBackColor = true;
            this.Del_but.Click += new System.EventHandler(this.Del_but_Click);
            // 
            // Mailform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 295);
            this.Controls.Add(this.Del_but);
            this.Controls.Add(this.cb_adr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_text);
            this.Controls.Add(this.tb_sub);
            this.Name = "Mailform";
            this.Text = "Отправка письма";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_sub;
        private System.Windows.Forms.TextBox tb_text;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_adr;
        private System.Windows.Forms.Button Del_but;
    }
}