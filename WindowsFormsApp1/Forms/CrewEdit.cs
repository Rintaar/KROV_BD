using Krov;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using WindowsFormsApp1.Core.DatabaseTableClass;

namespace WindowsFormsApp1.Forms
{
    public partial class CrewEdit : Form
    {
        private int id;
        public CrewEdit()
        {
            InitializeComponent();

            id = 0;
        }
        public CrewEdit(int _id)
        {
            InitializeComponent();
            id = _id;
            reload();
        }

        private void reload()
        {
            DataTable t = new DataTable();
            List<string> list = new List<string>();
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            try
            {
                t = dbConn.getData(String.Format("SELECT * FROM `Crew` WHERE `id` = {0}", id));
            }
            catch { }
            List<string> l = setXml(t.Rows[0][1].ToString());
            label13.Text = t.Rows[0][2].ToString();
            label14.Text = t.Rows[0][4].ToString();
            label15.Text = t.Rows[0][5].ToString();
            label16.Text = t.Rows[0][6].ToString();
            label17.Text = t.Rows[0][7].ToString();
            label18.Text = t.Rows[0][8].ToString();
            label19.Text = t.Rows[0][9].ToString();
            label20.Text = t.Rows[0][10].ToString();
            if (label20.Text == "") label20.Text = "Прикреплена к номеру телефона";

            label21.Text = "";
            for (int i = 0; i < l.Count; i++)
                label21.Text += l[i] + "\n";
            if(label21.Text == "") label21.Text = "Не назначено";
            CrewLog cl = new CrewLog();
            cl.createdata();
            label2.Text = cl.obj(t.Rows[0][2].ToString());
        }
        private List<string> setXml(string val)
        {
            List<string> temp = new List<string>();
            byte[] buffer1 = Encoding.UTF8.GetBytes(val);
            using (MemoryStream stream1 = new MemoryStream(buffer1))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                XmlReader reader = XmlReader.Create(stream1);
                //set1.ReadXml(reader);
                temp = (List<string>)serializer.Deserialize(reader);
            }
            return temp;
        }
        
        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form main = new NewEditCrew(id);
            main.FormClosed += updateDBCrew;
            main.Show();
        }
        private void updateDBCrew(object sender, FormClosedEventArgs e)
        {
            reload();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
