using Krov;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp1.Forms
{
    public partial class AddMat : Form
    {
        DataTable table;
        public AddMat(DataTable dt)
        {
            InitializeComponent();
            table = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBox2.Text);
                double b = Convert.ToDouble(textBox3.Text);
                double c = a * b;
                table.Rows.Add(textBox1.Text, a, b, c, textBox4.Text);
                string xml = getXML(table);
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                dbConn.insertData(String.Format("INSERT INTO `temp` (`temp`) VALUES ('{0}');", xml));                
            }
            catch (Exception e1) { MessageBox.Show(e1.ToString()); }
            this.Close();
        }
        private string getXML(DataTable t)
        {
            DataSet ds = new DataSet("table");

            ds.Tables.Add(t);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataSet));
                    xmlSerializer.Serialize(streamWriter, ds);
                    string xml = Encoding.UTF8.GetString(memoryStream.ToArray());
                    return xml;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string xml = getXML(table);
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                dbConn.insertData(String.Format("INSERT INTO `temp` (`temp`) VALUES ('{0}');", xml));
                
            }
            catch { }
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            count();
        }
        void count()
        {
            try
            {
                double a = Convert.ToDouble(textBox2.Text);
                double b = Convert.ToDouble(textBox3.Text);
                double c = a * b;
                label5.Text = c.ToString() + " руб.";
            }
            catch { }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            count();
        }
    }
}
