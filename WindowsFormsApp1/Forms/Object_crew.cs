using Krov;
using Krov.Core;
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
    public partial class Object_crew : Form
    {
        string obj;
        string crew;
        string part;
        int id;
        int obj_id;
        int crew_id;
        DataView crews;
        CrewTable ct = new CrewTable();
        public Object_crew()
        {
            InitializeComponent();
        }

        public Object_crew(int _crew_id, int _id, string _part, string _obj_id, DataView _crews)
        {
            InitializeComponent();
            ct.createdata();
            
            comboBox2.DataSource = Enumerable.Range(1, 12).ToList();
            comboBox3.DataSource = Enumerable.Range(1, 12).ToList();
            comboBox4.DataSource = Enumerable.Range(2018, 2100 - 2018 + 1).ToList();
            comboBox5.DataSource = Enumerable.Range(2018, 2100 - 2018 + 1).ToList();
            crews = _crews;
            id = _id; //id этапа
            obj = _obj_id;//id объекта
            crew_id = _crew_id; //id бригады
            part = _part; //название этапа
            label6.Text = id.ToString() + ". " + part;
            label5.Text = crews.Table.Rows[_crew_id][5].ToString();
            dgvinfo();
            dgvinfo();

        }
        private void dgvinfo()
        {
            try
            {
                dataGridView1.DataSource = ct.crew;
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Выполняемые работы";
                dataGridView1.Columns[2].HeaderText = "Название бригады"; dataGridView1.Columns[2].DisplayIndex = 1;
                dataGridView1.Columns[7].HeaderText = "Телефон";

                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[7].Width = 100;
            }
            catch { }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = new DateTime(Convert.ToInt16(comboBox4.SelectedItem), Convert.ToInt16(comboBox2.SelectedItem), Convert.ToInt16(textBox1.Text));
            DateTime end = new DateTime(Convert.ToInt16(comboBox5.SelectedItem), Convert.ToInt16(comboBox3.SelectedItem), Convert.ToInt16(textBox2.Text));
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            string query = String.Format("SELECT * FROM Crew_log WHERE crew = '{0}' AND end >= '{1}' AND start <= '{2}'", dataGridView1.SelectedCells[2].Value, start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"));
            DataTable dt = dbConn.getData(query);
            if(dt.Rows.Count  == 0)
            {
                goodending();
            }
            else
            {
                string message = String.Format("Бригада {0} работает\n", dt.Rows[0].ItemArray[1].ToString());
                for (int i = 0; i < dt.Rows.Count; i++)                        
                message += String.Format("\n   c {0} по {1} \nна объекте:\n   {2}\nвыполняя работу:\n   {3}\n",
                    Convert.ToDateTime(dt.Rows[i][3].ToString()).ToShortDateString(), //начало работы
                    Convert.ToDateTime(dt.Rows[i][4].ToString()).ToShortDateString(), //конец работы
                    dt.Rows[i].ItemArray[2].ToString(), //объект
                    dt.Rows[i].ItemArray[5].ToString() //dsвыполняемые работы
                    );

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, "", buttons);

                //если все успешно инициализирует процесс заполнения данных в БД запуская форму материалов
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    goodending();
                }
            }

            /* string val = start.ToShortDateString() + " - " + end.ToShortDateString() + " Бригада: " + crew + "\n";
             dt.Rows[id][6] = val;
             dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
             CrewLog log = new CrewLog();
             log.createdata();
             if (!label1.Text.Contains("(план)"))
             {
                 DataTable t = dbConn.getData(String.Format("SELECT `labor` FROM `Crew` WHERE `id` = {0}", crew_id));
                 TimeSpan diff = end.Subtract(start);
                 int days = diff.Days;
                 double work = Convert.ToDouble(t.Rows[0][0]);
                 string query = String.Format("INSERT INTO `Crew_log` (`id`, `crew`, `object`, `start`, `end`, `info`, `labor`) VALUES (NULL, '{0}', '{1}', '{2}', '{3}', '{4}','{5}')",
                   crew, obj, start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"), dt.Rows[id][1].ToString(), (days * work).ToString().Replace(",", "."));
                 dbConn.insertData(query);

                 if (id % 2 != 0)
                 {
                     DataTable temp = log.getbyWork(w);
                     if (temp.Rows.Count > 0)
                     {
                         dt.Rows[id][6] = "";
                         for (int i = 0; i < temp.Rows.Count; i++)
                         {
                             dt.Rows[id][6] = dt.Rows[id][6] + Convert.ToDateTime(temp.Rows[i][3].ToString()).ToShortDateString() + " - " + Convert.ToDateTime(temp.Rows[i][4].ToString()).ToShortDateString() + " " + temp.Rows[i][2].ToString() + "\n";
                         }
                     }
                     dt.Rows[id][2] = Convert.ToDouble(dt.Rows[id][2]) + days * work;
                     dt.Rows[id][4] = Convert.ToInt16(100 * Convert.ToDouble(dt.Rows[id][2]) / Convert.ToDouble(dt.Rows[id - 1][2]));
                 }
             }
             dbConn.updateDataById("Object", Convert.ToInt32(obj_id), "crew", getXML(dt));
             this.Close();
             */

        }
        public void goodending()
        {
            DateTime start = new DateTime(Convert.ToInt16(comboBox4.SelectedItem), Convert.ToInt16(comboBox2.SelectedItem), Convert.ToInt16(textBox1.Text));
            DateTime end = new DateTime(Convert.ToInt16(comboBox5.SelectedItem), Convert.ToInt16(comboBox3.SelectedItem), Convert.ToInt16(textBox2.Text));
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            //заполняем этап, планируемые даты работы, название 
            crews.Table.Rows[crew_id][12] = id;
            crews.Table.Rows[crew_id][3] = start.ToString("yyyy-MM-dd");
            crews.Table.Rows[crew_id][4] = end.ToString("yyyy-MM-dd");
            crews.Table.Rows[crew_id][1] = dataGridView1.SelectedCells[2].Value;
            string s = getXML(crews.Table);
            dbConn.updateDataById("Object", Convert.ToInt32(obj), "crew", s);


            //имя объекта
            DataTable dt = dbConn.getData(String.Format("SELECT name FROM Object WHERE id = {0}", obj));
            string name = dt.Rows[0][0].ToString();
            //запись в лог
            string query = String.Format("INSERT INTO `Crew_log` (`id`, `crew`, `object`, `start`, `end`, `info`, `labor`) VALUES (NULL, '{0}', '{1}', '{2}', '{3}', '{4}','{5}')",
                 dataGridView1.SelectedCells[2].Value, //бригада
                 name, // объект 
                 start.ToString("yyyy-MM-dd"), //начало работы
                 end.ToString("yyyy-MM-dd"), //конец работы
                 crews.Table.Rows[crew_id][5].ToString(), //выполняемые работы
                 0);//заглушка работ уточнить у насяльников. кусок кода выше туда же
            dbConn.insertData(query);

            this.Close();
        }

        public string getXML(DataTable t)
        {
            DataSet ds = new DataSet("table");

            ds.Tables.Add(t.Copy());
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
            this.Close();
        }
    }
}
