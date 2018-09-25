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

namespace WindowsFormsApp1.Forms
{
    public partial class CrewSettings : Form
    {
        public CrewSettings()
        {
            InitializeComponent();
            List<string> list = new List<string>();
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            try
            {
                DataTable t = dbConn.getData(String.Format("SELECT * FROM `JobKind` WHERE  `id` < 100"));
                foreach (DataRow r in t.Rows)
                    list.Add(r[0].ToString() + ". " + r[1].ToString());
            }
            catch { }
            listBox1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                dbConn.getData(String.Format("INSERT INTO `JobKind` (`id`, `name`) VALUES ({1}, '{0}');", textBox1.Text, Convert.ToInt16(textBox2.Text)));
                List<string> list = new List<string>();
                try
                {
                    DataTable t = dbConn.getData(String.Format("SELECT * FROM `JobKind` WHERE  `id` < 100"));
                    foreach (DataRow r in t.Rows)
                        list.Add(r[0].ToString() + ". " + r[1].ToString());
                }
                catch { }
                textBox1.Text = "";
                listBox1.DataSource = list;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dbConn.getData(String.Format("DELETE FROM `JobKind` WHERE `JobKind`.`id` = '{0}';", listBox1.SelectedValue.ToString().Substring(0,2)));
            List<string> list = new List<string>();
            try
            {
                DataTable t = dbConn.getData(String.Format("SELECT * FROM `JobKind` WHERE  `id` < 100"));
                foreach (DataRow r in t.Rows)
                    list.Add(r[0].ToString() + ". " + r[1].ToString());
            }
            catch { }
            listBox1.DataSource = list;
        }
    }
}
