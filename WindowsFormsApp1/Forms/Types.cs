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
    public partial class Types : Form
    {
        SuppliersTable st;
        public Types()
        {
            InitializeComponent();
            loadinfo();
        }
        void loadinfo()
        {
            st = new SuppliersTable();
            listBox1.DataSource = st.type();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dbConn.insertData(String.Format("INSERT INTO `suptypes` (`id`, `type`) VALUES (NULL, '{0}')", textBox1.Text));
            textBox1.Text = "";
            loadinfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(String.Format("Вы точно хотите удалить выделенные данные?"), "Подтверждение удаления", buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                    dbConn.deleteRawDataBykey("suptypes", "type", listBox1.SelectedItem.ToString());
                    loadinfo();

                }
                catch (Exception exep)
                {
                    MessageBox.Show("Невозможно получить данные из БД");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
