using Krov;
using Krov.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using WindowsFormsApp1.Core;

namespace WindowsFormsApp1.Forms
{
    public partial class AddMatherial : Form
    {
        Matherials obj = new Matherials();
        DataView table = new DataView();
        DataTable mat = new DataTable();
        List<DataRow> lists = new List<DataRow>();
        string code;
        string xmlmat;
        int id = -1;
        public AddMatherial()
        {
            InitializeComponent();
            Table();
        }
        public AddMatherial(List<DataRow> list)
        {
            InitializeComponent();
            AMatherial(list);
        }
        public void AMatherial(List<DataRow> list)
        {
            DataRow thisItem = list[0];
            tb_code.Text = thisItem[0].ToString();
            tb_name.Text = thisItem[1].ToString();
            tb_mat_measure.Text = thisItem[2].ToString();
            list.RemoveAt(0);
            lists = list;
            this.Text = String.Format("Количество добавляемых наименований: {0}", list.Count + 1);
            //tb_mat_price.Text = "";
            tb_measure.Text = "";
            tb_matforone.Text = "";
            Table();
        }
        public AddMatherial(Matherials data, int _id)
        {
            InitializeComponent();
            tb_code.Text = data.code;
            tb_name.Text = data.name;
            tb_mat_measure.Text = data.mat_measure;
           // tb_mat_price.Text = data.mat_price;
            tb_measure.Text = data.measure;
            xmlmat = data.measure_name;
            tb_matforone.Text = data.mat_for_one;
            tb_workprice.Text = data.work_price;
            id = _id;
            Table();
            label9.Text = count().ToString() + " руб.";
        }
        public AddMatherial(string data, string name, string mat_measure)
        {
            InitializeComponent();
            tb_code.Text = data;
            tb_name.Text = name;
            tb_mat_measure.Text = mat_measure;
            Table();

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
        void Table()
        {
            try
            {
                mat.Clear();
                mat.Columns.Add("name", typeof(String));
                mat.Columns.Add("price", typeof(String));
                mat.Columns.Add("count", typeof(String));
                mat.Columns.Add("fullprice", typeof(String));
                mat.Columns.Add("val", typeof(String));
            }
            catch { }
            
            dataGridView1.DataSource = mat;
            tableformat();
            try
            {
                DataSet set1 = new DataSet();
                byte[] buffer1 = Encoding.UTF8.GetBytes(xmlmat);
                using (MemoryStream stream1 = new MemoryStream(buffer1))
                {
                    XmlReader reader = XmlReader.Create(stream1);
                    set1.ReadXml(reader);
                }

                foreach (DataRow row in set1.Tables[0].Rows)
                {
                    try
                    {
                        mat.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
                    }
                    catch { }
                }
            }
            catch { }
        }
        void tableformat()
        {
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[0].HeaderText = "Наименование";
            dataGridView1.Columns[1].HeaderText = "Цена";
            dataGridView1.Columns[2].HeaderText = "Количество"; 
            dataGridView1.Columns[3].HeaderText = "Полная цена";
            dataGridView1.Columns[4].HeaderText = "Идиница измерения"; dataGridView1.Columns[4].DisplayIndex = 2;
        }
        double price()
        {
            try
            {
                return Convert.ToDouble(label9.Text.Substring(0, label9.Text.IndexOf(" ")));
            }
            catch
            {
                return 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                if (id == -1)
                {
                    string queryCommand = "";
                    try
                    {
                        double m = 0;                        
                        //if (tb_mat_price.Text != "" && tb_matforone.Text != "") mat = Convert.ToDouble(tb_mat_price.Text) * Convert.ToDouble(tb_matforone.Text);
                        queryCommand = String.Format("INSERT INTO `Matherials` " +
                        "(`code`, `name`, `mat_measure`, `mat_price`, `measure`, `mat_for_one`, `full_price`, `work_price`, `measure_name`) " +
                        "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')",
                        tb_code.Text, tb_name.Text, tb_mat_measure.Text, price() , tb_measure.Text, Convert.ToDouble(tb_matforone.Text), m, tb_workprice.Text, getXML(mat));
                    }
                    //catch
                    //{

                    //    MessageBox.Show("Неправильный формат введенных данных");
                    //}
                    catch (Exception e1) { MessageBox.Show("Заполните корректно поля с данными."); }
                    dbConn.getData(queryCommand);
                    this.Close();
                }
                else
                {
                    dbConn.updateDataById("Matherials", id, "code", tb_code.Text);
                    dbConn.updateDataById("Matherials", id, "name", tb_name.Text);
                    dbConn.updateDataById("Matherials", id, "mat_measure", tb_mat_measure.Text);
                    dbConn.updateDataById("Matherials", id, "mat_price", price().ToString());
                    dbConn.updateDataById("Matherials", id, "measure", tb_measure.Text);
                    dbConn.updateDataById("Matherials", id, "mat_for_one", tb_matforone.Text);
                    dbConn.updateDataById("Matherials", id, "full_price", (price()* Convert.ToDouble(tb_matforone.Text)).ToString());
                    dbConn.updateDataById("Matherials", id, "work_price", tb_workprice.Text);
                    dbConn.updateDataById("Matherials", id, "measure_name", getXML(mat));
                    this.Close();
                }               
                if(lists.Count >0)
                {
                    Form main = new AddMatherial(lists);
                    main.Show();
                    this.Close();
                }
                else { }
                
            }
            catch (Exception exep)
            {
                MessageBox.Show("Невозможно получить данные из БД");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lists.Count > 0)
            {
                Form main = new AddMatherial(lists);
                main.Show();
                this.Close();
            }
            else
            { this.Close(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            
            OK_sinchro.Visible = true;
            cb_coll.Enabled = true;
            code = tb_code.Text;
            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            label7.Enabled = false;
            tb_code.Enabled = false;
            tb_code.Text = "";
            //tb_mesName.Enabled = false;
            //tb_mesName.Text = "";
            tb_mat_measure.Enabled = false;
            tb_mat_measure.Text = "";
            tb_matforone.Enabled = false;
            tb_matforone.Text = "";
           // tb_mat_price.Enabled = false;
           // tb_mat_price.Text = "";
            tb_measure.Enabled = false;
            tb_measure.Text = "";
            tb_name.Enabled = false;
            tb_name.Text = "";
            tb_workprice.Enabled = false;
            tb_workprice.Text = "";
            table = new DataView(dbConn.getData("SELECT * FROM `Matherials`"));
            if (code != "")
            {
                table.RowFilter = String.Format("code LIKE '{0}*' ", code.Substring(0,3));
            }
            foreach (DataRow rows in table.ToTable().Rows)
            {
                cb_coll.Items.Add(rows.ItemArray[1] + " " + rows.ItemArray[2]);
            }
        }

        private void OK_sinchro_Click(object sender, EventArgs e)
        {
            if(cb_coll.Text != "")
            {
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                id = Convert.ToInt16(table.ToTable().Rows[cb_coll.SelectedIndex].ItemArray[0].ToString());
                DataTable temptable = dbConn.getData(String.Format("SELECT * FROM `Matherials` WHERE `Matherials`.`id` = '{0}'", id));
                OK_sinchro.Visible = false;
                cb_coll.Enabled = false;
                cb_coll.Visible = false;
                button4.Visible = false;
                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
                label4.Enabled = true;
                label5.Enabled = true;
                label6.Enabled = true;
                label7.Enabled = true;
                tb_code.Enabled = true;
                tb_code.Text = temptable.Rows[0].ItemArray[1].ToString()+ "\r\n" + code;
                tb_mat_measure.Enabled = true;
                //tb_mesName.Enabled = true;
                //tb_mesName.Text = temptable.Rows[0].ItemArray[9].ToString();
                tb_mat_measure.Text = temptable.Rows[0].ItemArray[3].ToString();
                tb_matforone.Enabled = true;
                tb_matforone.Text = temptable.Rows[0].ItemArray[6].ToString();
                //tb_mat_price.Enabled = true;
                //tb_mat_price.Text = temptable.Rows[0].ItemArray[4].ToString();
                tb_measure.Enabled = true;
                tb_measure.Text = temptable.Rows[0].ItemArray[5].ToString();
                tb_name.Enabled = true;
                tb_name.Text = temptable.Rows[0].ItemArray[2].ToString(); ;
                tb_workprice.Enabled = true;
                tb_workprice.Text = temptable.Rows[0].ItemArray[8].ToString(); 

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form main = new AddMat(mat);
            main.FormClosed += updateDB;
            main.Show();
        }
        private void updateDB(object sender, FormClosedEventArgs e)
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            DataTable table1 = dbConn.getData("SELECT * FROM `temp`");
            DataTable mat1 = new DataTable();
            mat1.Clear();
            mat1.Columns.Add("name", typeof(String));
            mat1.Columns.Add("price", typeof(String));
            mat1.Columns.Add("count", typeof(String));
            mat1.Columns.Add("fullprice", typeof(String));
            mat1.Columns.Add("val", typeof(String));
            try
            {
                DataSet set1 = new DataSet();
                string s = table1.Rows[0].ItemArray[1].ToString();
                byte[] buffer1 = Encoding.UTF8.GetBytes(table1.Rows[0][1].ToString());
                using (MemoryStream stream1 = new MemoryStream(buffer1))
                {
                    XmlReader reader = XmlReader.Create(stream1);
                    set1.ReadXml(reader);
                }

                foreach (DataRow row in set1.Tables[0].Rows)
                {
                    try
                    {
                        mat1.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
                    }
                    catch { }
                }
            }
            catch { }
            mat = mat1;
            dataGridView1.DataSource = mat;
            tableformat();
            dbConn.getData(String.Format("DELETE FROM `temp` WHERE `temp`.`id` = {0};", table1.Rows[0][0].ToString()));
            double data = count();
            label9.Text = data.ToString() + " руб.";
        }
        double count()
        {
            double res = 0;
            for (int i = 0; i < mat.Rows.Count; i++)
                res += Convert.ToDouble(mat.Rows[i][3]);
            return res;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int a = dataGridView1.Rows.IndexOf(dataGridView1.SelectedRows[0]);
                mat.Rows[a].Delete();
                dataGridView1.DataSource = mat;
                tableformat();
                label9.Text = count().ToString() + " руб.";
            }
            catch { }
        }
    }
}
