using Krov;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Core.DatabaseTableClass;

namespace WindowsFormsApp1.Forms
{
    public partial class Suppliers : Form
    {
        SuppliersTable st;
        string sid = "";
        public Suppliers()
        {
            InitializeComponent();
            loadcb();
        }
        public Suppliers(string id)
        {
            InitializeComponent();
            loadcb();
            button1.Text = "Обновить";
            sid = id;
            int index = comboBox1.FindString(st.FilterById(id).Rows[0].ItemArray[3].ToString());
            comboBox1.SelectedIndex = index;

            tb_fio.Text = st.FilterById(id).Rows[0].ItemArray[1].ToString();
            tb_firm.Text = st.FilterById(id).Rows[0].ItemArray[2].ToString();
            tb_phone.Text = st.FilterById(id).Rows[0].ItemArray[4].ToString();
            tb_mail.Text = st.FilterById(id).Rows[0].ItemArray[5].ToString();
            tb_address.Text = st.FilterById(id).Rows[0].ItemArray[6].ToString();           
            
        }
        void loadcb()
        {
            st = new SuppliersTable();
            comboBox1.DataSource = st.type();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string _queryCommand;
                if (sid == "")
                    _queryCommand = String.Format("INSERT INTO `suppliers` (`id`, `fio`, `firm`, `type`, `phone`, `mail`, `address`) VALUES (NULL, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                    tb_fio.Text, tb_firm.Text, comboBox1.SelectedItem, tb_phone.Text, tb_mail.Text, tb_address.Text);
                else
                    _queryCommand = String.Format("UPDATE `suppliers` SET `fio` = '{1}', `firm` = '{2}', `type` =  '{3}', `phone` = '{4}', `mail` = '{5}', `address` = '{6}' WHERE `suppliers`.`id` = {0};",
                   sid, tb_fio.Text, tb_firm.Text, comboBox1.SelectedItem, tb_phone.Text, tb_mail.Text, tb_address.Text);

                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                dbConn.insertData(_queryCommand);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Заполните все значения");
            }
        }
    }
}
