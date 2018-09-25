namespace WindowsFormsApp1.Forms
{
    partial class AddMatherial
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_code = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_matforone = new System.Windows.Forms.TextBox();
            this.tb_measure = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tb_workprice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_coll = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.OK_sinchro = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tb_mat_measure = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Коды услуги";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Полное название услуги";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Единица измерения услуги";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Стоимость единицы блока материалов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 397);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Количество материалов на единицу услуги";
            // 
            // tb_code
            // 
            this.tb_code.Location = new System.Drawing.Point(258, 15);
            this.tb_code.Multiline = true;
            this.tb_code.Name = "tb_code";
            this.tb_code.Size = new System.Drawing.Size(459, 82);
            this.tb_code.TabIndex = 7;
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(258, 103);
            this.tb_name.Multiline = true;
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(459, 63);
            this.tb_name.TabIndex = 8;
            // 
            // tb_matforone
            // 
            this.tb_matforone.Location = new System.Drawing.Point(258, 397);
            this.tb_matforone.Name = "tb_matforone";
            this.tb_matforone.Size = new System.Drawing.Size(459, 20);
            this.tb_matforone.TabIndex = 13;
            // 
            // tb_measure
            // 
            this.tb_measure.Location = new System.Drawing.Point(258, 172);
            this.tb_measure.Name = "tb_measure";
            this.tb_measure.Size = new System.Drawing.Size(459, 20);
            this.tb_measure.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 523);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(695, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Добавить в базу данных материалов";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 552);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(325, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Не добавлять";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(366, 552);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(351, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Отмена";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tb_workprice
            // 
            this.tb_workprice.Location = new System.Drawing.Point(258, 426);
            this.tb_workprice.Name = "tb_workprice";
            this.tb_workprice.Size = new System.Drawing.Size(459, 20);
            this.tb_workprice.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 426);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Стоимость работы";
            // 
            // cb_coll
            // 
            this.cb_coll.Enabled = false;
            this.cb_coll.FormattingEnabled = true;
            this.cb_coll.Location = new System.Drawing.Point(257, 459);
            this.cb_coll.Name = "cb_coll";
            this.cb_coll.Size = new System.Drawing.Size(460, 21);
            this.cb_coll.TabIndex = 20;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(22, 459);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(222, 23);
            this.button4.TabIndex = 21;
            this.button4.Text = "Синхронизировать материал:";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // OK_sinchro
            // 
            this.OK_sinchro.Location = new System.Drawing.Point(22, 492);
            this.OK_sinchro.Name = "OK_sinchro";
            this.OK_sinchro.Size = new System.Drawing.Size(695, 23);
            this.OK_sinchro.TabIndex = 22;
            this.OK_sinchro.Text = "Подтвердить синхронизацию";
            this.OK_sinchro.UseVisualStyleBackColor = true;
            this.OK_sinchro.Visible = false;
            this.OK_sinchro.Click += new System.EventHandler(this.OK_sinchro_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Название материалов";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(255, 339);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(258, 198);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(459, 133);
            this.dataGridView1.TabIndex = 25;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(573, 337);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(144, 23);
            this.button5.TabIndex = 26;
            this.button5.Text = "Удалить материал";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(418, 337);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(149, 23);
            this.button6.TabIndex = 27;
            this.button6.Text = "Добавить материал";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tb_mat_measure
            // 
            this.tb_mat_measure.Location = new System.Drawing.Point(258, 367);
            this.tb_mat_measure.Name = "tb_mat_measure";
            this.tb_mat_measure.Size = new System.Drawing.Size(459, 20);
            this.tb_mat_measure.TabIndex = 9;
            this.tb_mat_measure.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Единица измерения материала";
            this.label5.Visible = false;
            // 
            // AddMatherial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 586);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.OK_sinchro);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cb_coll);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_workprice);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_matforone);
            this.Controls.Add(this.tb_measure);
            this.Controls.Add(this.tb_mat_measure);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_code);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(753, 625);
            this.MinimumSize = new System.Drawing.Size(753, 625);
            this.Name = "AddMatherial";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_code;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_matforone;
        private System.Windows.Forms.TextBox tb_measure;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tb_workprice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_coll;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button OK_sinchro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox tb_mat_measure;
        private System.Windows.Forms.Label label5;
    }
}