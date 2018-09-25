namespace WindowsFormsApp1.Forms
{
    partial class NewEditCrew
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
            this.cb_car = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.lb_info = new System.Windows.Forms.CheckedListBox();
            this.tb_count = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_instr = new System.Windows.Forms.ComboBox();
            this.cb_nat = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_card = new System.Windows.Forms.TextBox();
            this.tb_mail = new System.Windows.Forms.TextBox();
            this.tb_phone = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.labor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_car
            // 
            this.cb_car.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_car.FormattingEnabled = true;
            this.cb_car.Location = new System.Drawing.Point(154, 84);
            this.cb_car.Name = "cb_car";
            this.cb_car.Size = new System.Drawing.Size(332, 21);
            this.cb_car.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(506, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Тип работ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количество работников";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Автомобиль";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(269, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(243, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Название бригады";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(154, 22);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(332, 20);
            this.tb_name.TabIndex = 15;
            // 
            // lb_info
            // 
            this.lb_info.FormattingEnabled = true;
            this.lb_info.Location = new System.Drawing.Point(588, 22);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(208, 304);
            this.lb_info.TabIndex = 16;
            // 
            // tb_count
            // 
            this.tb_count.Location = new System.Drawing.Point(154, 52);
            this.tb_count.Name = "tb_count";
            this.tb_count.Size = new System.Drawing.Size(332, 20);
            this.tb_count.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Инструменты";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Гражданство";
            // 
            // cb_instr
            // 
            this.cb_instr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_instr.FormattingEnabled = true;
            this.cb_instr.Location = new System.Drawing.Point(154, 116);
            this.cb_instr.Name = "cb_instr";
            this.cb_instr.Size = new System.Drawing.Size(332, 21);
            this.cb_instr.TabIndex = 20;
            // 
            // cb_nat
            // 
            this.cb_nat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_nat.FormattingEnabled = true;
            this.cb_nat.Location = new System.Drawing.Point(154, 147);
            this.cb_nat.Name = "cb_nat";
            this.cb_nat.Size = new System.Drawing.Size(332, 21);
            this.cb_nat.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_card);
            this.groupBox1.Controls.Add(this.tb_mail);
            this.groupBox1.Controls.Add(this.tb_phone);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 133);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Контактные данные";
            // 
            // tb_card
            // 
            this.tb_card.Location = new System.Drawing.Point(142, 87);
            this.tb_card.Name = "tb_card";
            this.tb_card.Size = new System.Drawing.Size(332, 20);
            this.tb_card.TabIndex = 24;
            // 
            // tb_mail
            // 
            this.tb_mail.Location = new System.Drawing.Point(142, 55);
            this.tb_mail.Name = "tb_mail";
            this.tb_mail.Size = new System.Drawing.Size(332, 20);
            this.tb_mail.TabIndex = 23;
            // 
            // tb_phone
            // 
            this.tb_phone.Location = new System.Drawing.Point(142, 23);
            this.tb_phone.Name = "tb_phone";
            this.tb_phone.Size = new System.Drawing.Size(332, 20);
            this.tb_phone.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Номер карты";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Телефон";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(588, 355);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(208, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Настройки типов";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labor
            // 
            this.labor.Location = new System.Drawing.Point(154, 178);
            this.labor.Name = "labor";
            this.labor.Size = new System.Drawing.Size(332, 20);
            this.labor.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Производительность";
            // 
            // NewEditCrew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 390);
            this.Controls.Add(this.labor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cb_nat);
            this.Controls.Add(this.cb_instr);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_count);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_car);
            this.Name = "NewEditCrew";
            this.Text = "NewEditCrew";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_car;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.CheckedListBox lb_info;
        private System.Windows.Forms.TextBox tb_count;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_instr;
        private System.Windows.Forms.ComboBox cb_nat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_card;
        private System.Windows.Forms.TextBox tb_mail;
        private System.Windows.Forms.TextBox tb_phone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox labor;
        private System.Windows.Forms.Label label10;
    }
}