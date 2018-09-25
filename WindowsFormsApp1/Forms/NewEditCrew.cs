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
using System.Xml;
using System.Xml.Serialization;
using WindowsFormsApp1.Core.DatabaseTableClass;

namespace WindowsFormsApp1.Forms
{
    public partial class NewEditCrew : Form
    {
        private int id = 0;
        private bool check = false;
        public NewEditCrew()
        {
            InitializeComponent();
            startinfo();        
        }

        private void startinfo()
        {
            DataTable t = new DataTable();
            List<string> list = new List<string>();
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            try
            {
                t = dbConn.getData(String.Format("SELECT * FROM `JobKind` WHERE  `id` < 100"));
                foreach (DataRow r in t.Rows)
                    list.Add(r[0].ToString() + ". " + r[1].ToString());
            }
            catch { }
            lb_info.DataSource = list;
            cb_car.Items.Add("Есть");
            cb_car.Items.Add("Нет");

            cb_instr.Items.Add("Есть");
            cb_instr.Items.Add("Нет");
            cb_instr.Items.Add("Частично");

            cb_nat.Items.Add("Есть");
            cb_nat.Items.Add("Нет");
            cb_nat.Items.Add("Патент");

            cb_car.SelectedIndex = 1;
            cb_nat.SelectedIndex = 1;
            cb_instr.SelectedIndex = 1;
        }
        public NewEditCrew(int _id)
        {
            try
            {

                id = _id;
                check = true;
                InitializeComponent();
                startinfo();
                button1.Text = "Обновить";
                DataTable t = new DataTable();
                List<string> list = new List<string>();
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                try
                {
                    t = dbConn.getData(String.Format("SELECT * FROM `Crew` WHERE `id` = {0}", id));
                }
                catch { }

                //string type = getxml();
                List<string> l = setXml(t.Rows[0][1].ToString());
                for (int i = 0; i < lb_info.Items.Count; i++)
                    for (int j = 0; j < l.Count; j++)
                    {
                        if (lb_info.Items[i].ToString() == l[j])
                        {
                            lb_info.SetItemChecked(i, true);
                        }
                    }

                tb_name.Text = t.Rows[0][2].ToString();
                tb_count.Text = t.Rows[0][4].ToString();               
                tb_phone.Text = t.Rows[0][8].ToString(); 
                tb_mail.Text = t.Rows[0][9].ToString(); 
                tb_card.Text = t.Rows[0][10].ToString(); 
                labor.Text = t.Rows[0][12].ToString();

                int index = cb_car.FindString(t.Rows[0][5].ToString());
                cb_car.SelectedIndex = index;

                index = cb_instr.FindString(t.Rows[0][6].ToString());
                cb_instr.SelectedIndex = index;

                index = cb_nat.FindString(t.Rows[0][7].ToString());
                cb_nat.SelectedIndex = index;
            }
            catch(Exception e){ MessageBox.Show(e.ToString()); }
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
        private void button1_Click(object sender, EventArgs e)
        {
            
            string type = getxml(); 
            string name = "";
            int workers;
            try { workers = Convert.ToInt32(tb_count.Text); }
            catch { workers = 0; }
            double lab = Convert.ToDouble(labor.Text);
            string car = "";
            string instr = "";
            string nation = "";
            string phone = "";
            string mail = "";
            string card = "";

            try
            {
                name = tb_name.Text;
                car = cb_car.SelectedItem.ToString();
                instr = cb_instr.SelectedItem.ToString();
                nation = cb_nat.SelectedItem.ToString();
                phone = tb_phone.Text;
                mail = tb_mail.Text;
                card = tb_card.Text;
            }
            catch { }
            CrewTable cr = new CrewTable();
            //int count = Convert.ToInt32(tb_count.Text);
            if (!check)
                cr.addCrew(type,name,workers,car,instr,nation,phone,mail,card,"",lab);
            else
                cr.updateCrew(id, type, name, workers, car, instr, nation, phone, mail, card, "",lab);
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string getxml()
        {
            List<string> temp = new List<string>();
            foreach (string s in lb_info.CheckedItems)
                temp.Add(s);
            string xml;           
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
                    xmlSerializer.Serialize(streamWriter, temp);
                    xml = Encoding.UTF8.GetString(memoryStream.ToArray());
                }
            }
            return xml;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form main = new CrewSettings();
            main.FormClosed += updateDBCrew;
            main.Show();
        }
        private void updateDBCrew(object sender, FormClosedEventArgs e)
        {
            List<string> temp = new List<string>();
            foreach (string s in lb_info.CheckedItems)
                temp.Add(s);
            startinfo();
            for (int i = 0; i < lb_info.Items.Count; i++)
                lb_info.SetItemChecked(i, false);
            for (int i = 0; i < lb_info.Items.Count; i++)
                for (int j = 0; j < temp.Count; j++)
                {
                    if(lb_info.Items[i].ToString() == temp[j])
                    {
                        lb_info.SetItemChecked(i, true);
                    }
                }                   

        }
    }
}
