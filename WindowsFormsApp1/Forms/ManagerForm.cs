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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsApp1.Core;
using WindowsFormsApp1.Core.DatabaseTableClass;

namespace WindowsFormsApp1.Forms
{
    public partial class ManagerForm : Form
    {
        DataView dataTable;
        DataView mat;
        Manager user;
        SuppliersTable suppliers;
        CrewTable crew;
        CrewLog cl;
        public ManagerForm(Manager _user)
        {
            InitializeComponent();
            groupBox1.Visible = false;
            reloaddb();
            loadSup();
            user = _user;
            string end = ".ru";
            if (user.m_server == "gmail") end = ".com";
            tb_fio.Text = user.Fio;
            tb_pas.Text = user.password;
            tb_mlo.Text = user.m_login + "@" + user.m_server + end; 
            tb_mpa.Text = user.m_password;
            matTableGen();
            matherials.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            matherials.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            matherials.DataSource = mat;
            matherials.Columns[0].Visible = false;
            matherials.Columns[2].Width = 235;
            matherials.Columns[4].Width = 75;
            matherials.Columns[5].Width = 75;
            matherials.Columns[6].Width = 75;
            matherials.Columns[8].Width = 75;
            matherials.Columns[9].Width = 180;
            matherials.Columns[1].HeaderText = "Код";
            matherials.Columns[2].HeaderText = "Наименование";
            //matherials.Columns[3].HeaderText = "Ед. мат.";
            matherials.Columns[3].Visible = false;
            matherials.Columns[4].HeaderText = "Стоимость ед.мат.";
            matherials.Columns[5].HeaderText = "Ед. раб.";
            matherials.Columns[6].HeaderText = "Количество мат. на ед. раб.";
            matherials.Columns[7].HeaderText = "Цена материалов";
            matherials.Columns[8].HeaderText = "Цена работы";
            matherials.Columns[9].DisplayIndex = 3;
            matherials.Columns[9].HeaderText = "Названия материалов";
            
            CultureInfo ci = new CultureInfo("ru-RU");
            DateTimeFormatInfo dtfi = ci.DateTimeFormat;
           

            cb_mounth.DataSource = dtfi.MonthNames;
            cb_year.DataSource = Enumerable.Range(2018, 2100 - 2018 + 1).ToList();
            cl = new CrewLog();
            cl.createdata();
            //dgv_crew.DataSource = cl.createcalendar(1,2018);
            crew = new CrewTable();
            crew.createdata();
            filtersettings();
            //calendarFormat();
            checkTable();
            checkTable();
        }
        public void matTableGen()
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            DataTable t = dbConn.getData("SELECT * FROM `Matherials`");
            for ( int i = 0; i < t.Rows.Count; i++)
            {
                string xml = t.Rows[i][9].ToString();
                t.Rows[i][9] = XMLconverter(xml);
            }
          
            mat = new DataView(t);
            mat.Table.PrimaryKey = new DataColumn[] { mat.Table.Columns["id"] };
        }
        public void matTablereGen(string value)
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            DataTable t = dbConn.getData(String.Format("SELECT * FROM `Matherials` WHERE `id` = '{0}'", value));
            for (int j = 0;j < t.Rows.Count; j++)
            {
                string xml = t.Rows[j][9].ToString();
                t.Rows[j][9] = XMLconverter(xml);
            }
            int i = mat.Table.Rows.IndexOf(mat.Table.Rows.Find(matherials.Rows[matherials.SelectedRows[0].Index].Cells[0].Value.ToString()));
            mat.Table.Rows[i][0] = t.Rows[0][0];
            mat.Table.Rows[i][1] = t.Rows[0][1];
            mat.Table.Rows[i][2] = t.Rows[0][2];
            mat.Table.Rows[i][3] = t.Rows[0][3];
            mat.Table.Rows[i][4] = t.Rows[0][4];
            mat.Table.Rows[i][5] = t.Rows[0][5];
            mat.Table.Rows[i][6] = t.Rows[0][6];
            mat.Table.Rows[i][7] = t.Rows[0][7];
            mat.Table.Rows[i][8] = t.Rows[0][8];
            mat.Table.Rows[i][9] = t.Rows[0][9];

            matherials.DataSource = mat;
        }
        string XMLconverter(string xml)
        {
            string res = "";
            try
            {
                DataSet set1 = new DataSet();
                byte[] buffer1 = Encoding.UTF8.GetBytes(xml);
                using (MemoryStream stream1 = new MemoryStream(buffer1))
                {
                    XmlReader reader = XmlReader.Create(stream1);
                    set1.ReadXml(reader);
                }

                foreach (DataRow row in set1.Tables[0].Rows)
                {
                    try
                    {
                        res += row[0].ToString() + " \n";                       
                    }
                    catch { }
                }
            }
            catch(Exception ex) {   }
            return res;
        }
        //выгрузка поставщиков
        void loadSup()
        {
            suppliers = new SuppliersTable();
            typesbox.Items.Clear();
            foreach (string r in suppliers.type())
                typesbox.Items.Add(r.ToString());           
            updateSup();
            formatSup();
        }
        void updateSup()
        {
            List<string> res = new List<string>();
            foreach (string r in typesbox.CheckedItems)
                res.Add(r);
            SupTable.DataSource = suppliers.Filteredsuppliers(res);
            
        }
        //форматирование поставщиков
        void formatSup()
        {
            SupTable.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            SupTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            SupTable.Columns[0].Visible = false;
            SupTable.Columns[1].HeaderText = "ФИО";
            SupTable.Columns[2].HeaderText = "Фирма";
            SupTable.Columns[3].HeaderText = "Тип";
            SupTable.Columns[4].HeaderText = "Телефон";
            SupTable.Columns[5].HeaderText = "Почта";
            SupTable.Columns[6].HeaderText = "Адрес";
        }
        //Перезагрузка данных в таблицах при изменении и их форматипрование
        void reloaddb()
        {
            try
            {
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                try
                {
                    dataTable = new DataView(dbConn.getData(String.Format("SELECT * FROM `Object` WHERE `status` = '0' AND `manager` = '{0}'", user.login)));
                    dataGridView1.DataSource = dataTable;
                }
                catch { }
                try { 
                dataTable = new DataView(dbConn.getData(String.Format("SELECT * FROM `Object` WHERE `status` = '1' AND `manager` = '{0}'", user.login)));
                dataGridView2.DataSource = dataTable;
                }
                catch { }
                for (int i = 0; i <= 12; i++)
                {
                    try
                    {
                        dataGridView1.Columns[i].Visible = false;
                    }
                    catch { }
                    try
                    {
                        dataGridView2.Columns[i].Visible = false;
                    }
                    catch { }
                }
                try
                {
                    dataGridView1.Columns[1].Visible = true; dataGridView1.Columns[1].Width = 350; dataGridView1.Columns[1].HeaderText = "Имя объекта";
                    dataGridView1.Columns[2].Visible = true; dataGridView1.Columns[2].Width = 310; dataGridView1.Columns[2].HeaderText = "Адрес объекта";
                    dataGridView1.Columns[5].Visible = true; dataGridView1.Columns[5].Width = 70; dataGridView1.Columns[5].HeaderText = "Дата по договору";
                    dataGridView1.Columns[6].Visible = true; dataGridView1.Columns[6].Width = 70; dataGridView1.Columns[6].HeaderText = "Дата по плану   ";
                }
                catch { }
                try
                {
                    dataGridView2.Columns[1].Visible = true; dataGridView2.Columns[1].Width = 350; dataGridView2.Columns[1].HeaderText = "Имя объекта";
                    dataGridView2.Columns[2].Visible = true; dataGridView2.Columns[2].Width = 310; dataGridView2.Columns[2].HeaderText = "Адрес объекта";
                    dataGridView2.Columns[5].Visible = true; dataGridView2.Columns[5].Width = 70; dataGridView2.Columns[5].HeaderText = "Дата по договору";
                    dataGridView2.Columns[7].Visible = true; dataGridView2.Columns[7].Width = 70; dataGridView2.Columns[7].HeaderText = "Дата реальная";
                }
                catch { }
               
                

               // dataGridView1.Columns[3].Visible = true;        //временно для тестов
            }
            catch {}
        }
        //открытие нового или старого проекта объекта
        private void button4_Click(object sender, EventArgs e)
        {
            openObject();
        }
        public void openObject()
        {
            Form main = new Main_form(user);
            main.Show();
            this.Hide();

        }
        public void openObjectbyId(string id)
        {
            Form main = new Main_form(user,id);
            main.Show();
            this.Hide();
        }
        //таблица текущих
        private void button1_Click(object sender, EventArgs e)
        {
            openObj();
        }
        //таблица завершенных
         private void button8_Click(object sender, EventArgs e)
        {
            try { openObjectbyId(dataGridView2.SelectedCells[0].Value.ToString()); }
            catch { }
        }
        //изменение статуса объекта. перенос в завершенные
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                changeStatus(Convert.ToInt16(dataGridView1.SelectedCells[0].Value), 1);
            }
            catch { }
        }
        //изменение статуса объекта. перенос в активные
        private void button7_Click(object sender, EventArgs e)
        {
            try
            { 
            changeStatus(Convert.ToInt16(dataGridView2.SelectedCells[0].Value), 0);
             }
            catch { }
        }
        //функция изменения статуса объекта
       public void changeStatus(int id, int stat)
        {
            try
            {                
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                dbConn.updateDataById("Object", id, "status", stat.ToString());
                reloaddb();
            }
            catch { }
        }
        
        //функция удаления объекта
        public void deleteObject(int id)
        {
            try
            {
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                dbConn.deleteRawDataById("Object", id);
                reloaddb();
            }
            catch { }
        }
        //таблица завершенных
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                deleteObject(Convert.ToInt16(dataGridView2.SelectedCells[0].Value));
            }
            catch { }
        }
        //таблица текущих
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                deleteObject(Convert.ToInt16(dataGridView1.SelectedCells[0].Value));
            }
            catch { }
        }

        //закрытие формы
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //действие при закрытии формы
        private void ManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormCollection formlist = Application.OpenForms;
            formlist[0].Show();
        }

        private void ManagerForm_VisibleChanged(object sender, EventArgs e)
        {
            reloaddb();
        }
        //Добавление новой позиции в Материалы
        private void but_Add_Click(object sender, EventArgs e)
        {
            Form main = new AddMatherial();            
            main.FormClosed += updateDB;
            main.Show();
        }
        //обновление датагрида материалов 
        private void updateDB(object sender, FormClosedEventArgs e)
        {
            matTablereGen(matherials.SelectedCells[0].Value.ToString());
            matherials.DataSource = mat;
        }
        private void updateDBSup(object sender, FormClosedEventArgs e)
        {
            loadSup();
        }
        //редактирование выделенной секции
        private void but_Edit_Click(object sender, EventArgs e)
        {
            editMat();
        }
        //удаление выделенного элемента
        private void but_Delete_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(String.Format("Вы точно хотите удалить выделенные данные?"), "Подтверждение удаления", buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                    dbConn.deleteRawDataById("Matherials", Convert.ToInt16(matherials.SelectedCells[0].Value));
                    matTableGen();
                    matherials.DataSource = mat;
                }
                catch (Exception exep)
                {
                    MessageBox.Show("Невозможно получить данные из БД");
                }
            }
            

        }
        //фильтр таблица по коду или названию
            private void tb_Filter_TextChanged(object sender, EventArgs e)
        {
            mat.RowFilter = String.Format("Name LIKE '*{0}*' OR code LIKE '*{0}*' OR measure_name LIKE '*{0}*' ", tb_Filter.Text);
        }
        
        private void ManagerForm_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dbConn.deleteRawDataBykey("Manager", "login", user.login);
            set_info();
            string queryCommand = String.Format("INSERT INTO `Manager` (`login`, `password`, `FIO`, `bill`, `Em_login`, `Em_password`, `Em_Server`, `access`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                user.login, user.password, user.Fio, user.bill, user.m_login, user.m_password, user.m_server, user.access);
            dbConn.insertData(queryCommand);
            MessageBox.Show("Данные обновлены");
        }
        public void set_info()
        {
            try
            {
                user.Fio = tb_fio.Text;
                user.password = tb_pas.Text;
                user.m_login = tb_mlo.Text.Substring(0, tb_mlo.Text.IndexOf('@'));
                int a = tb_mlo.Text.IndexOf('@') + 1;
                int b = tb_mlo.Text.LastIndexOf('.');
                user.m_server = tb_mlo.Text.Substring(a, b - a);
                user.m_password = tb_mpa.Text;           
            }
            catch { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            openObj();
        }
        private void openObj()
        {
            try { openObjectbyId(dataGridView1.SelectedCells[0].Value.ToString()); }
            catch { }
        }
        private void editMat()
        {
            try
            {
                Matherials item = new Matherials();
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                DataTable dt = dbConn.getData(String.Format("SELECT `measure_name` FROM `Matherials` WHERE `code` = '{0}'", matherials.SelectedCells[1].Value.ToString()));               
                item.code = matherials.SelectedCells[1].Value.ToString();
                item.name = matherials.SelectedCells[2].Value.ToString();
                item.mat_measure = matherials.SelectedCells[3].Value.ToString();
                item.mat_price = matherials.SelectedCells[4].Value.ToString();
                item.measure = matherials.SelectedCells[5].Value.ToString();
                item.mat_for_one = matherials.SelectedCells[6].Value.ToString();
                item.full_price = matherials.SelectedCells[7].Value.ToString();
                item.measure_name = dt.Rows[0][0].ToString();
                item.work_price = matherials.SelectedCells[8].Value.ToString();
                int id = Convert.ToInt16(matherials.SelectedCells[0].Value.ToString());
                Form main = new AddMatherial(item, id);
                main.FormClosed += updateDB;
                main.Show();
            }
            catch { }
        }
        private void matherials_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void matherials_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editMat();
        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try { openObjectbyId(dataGridView2.SelectedCells[0].Value.ToString()); }
            catch { }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openObj();
        }

        private void cb_mounth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //checkTable();
        }
        public void checkTable()
        {
            dgv_crew.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_crew.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            try
            {
                if (radioButton1.Checked)
                {
                    label8.Visible = true;
                    label14.Visible = true;
                    button13.Visible = true;
                    cb_mounth.Visible = true;
                    cb_year.Visible = true;
                    groupBox1.Visible = false;

                    cl = new CrewLog();
                    cl.createdata();
                    dgv_crew.DataSource = cl.createcalendar(cb_mounth.SelectedIndex + 1, Convert.ToInt16(cb_year.SelectedItem));
                    calendarFormat();
                }
                else
                {
                    label8.Visible = false;
                    label14.Visible = false;
                    button13.Visible = false;
                    cb_mounth.Visible = false;
                    cb_year.Visible = false;
                    groupBox1.Visible = true;
                    dgv_crew.DataSource = crew.crew;
                    Crew_listFormat();
                }


            }
            catch
            { }
        }

        private void calendarFormat()
        {
            dgv_crew.Columns[0].Visible = false;
            CultureInfo ci = new CultureInfo("ru-RU");
            DateTimeFormatInfo dtfi = ci.DateTimeFormat;
            DateTime dt = new DateTime(Convert.ToInt16(cb_year.SelectedItem), cb_mounth.SelectedIndex+1, 1);
            DateTime dt1 = new DateTime(Convert.ToInt16(cb_year.SelectedItem), cb_mounth.SelectedIndex + 1, DateTime.DaysInMonth(Convert.ToInt16(cb_year.SelectedItem), cb_mounth.SelectedIndex + 1));
            DayOfWeek dw = dt.DayOfWeek;
            DayOfWeek dw1 = dt1.DayOfWeek;
            DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;
            DateTime eowf = dt1.AddDays(-(dw1 - fdow) - 1).Date;
            dgv_crew.Columns[1].HeaderText = "Бригады";
            string date;
            DateTime sow = dt.AddDays(-(dw - fdow)).Date;
            DateTime eow = dt.AddDays(-(dw - fdow) + 6).Date;
            date = String.Format("{0} - {1}", sow.ToShortDateString(), eow.ToShortDateString());
            dgv_crew.Columns[2].HeaderText = date;

            sow = dt.AddDays(-(dw - fdow) + 7).Date;
            eow = dt.AddDays(-(dw - fdow) + 6 + 7).Date;
            date = String.Format("{0} - {1}", sow.ToShortDateString(), eow.ToShortDateString());
            dgv_crew.Columns[3].HeaderText = date;

            sow = dt.AddDays(-(dw - fdow) + 14).Date;
            eow = dt.AddDays(-(dw - fdow) + 6 + 14).Date;
            date = String.Format("{0} - {1}", sow.ToShortDateString(), eow.ToShortDateString());
            dgv_crew.Columns[4].HeaderText = date;

            sow = dt.AddDays(-(dw - fdow) + 21).Date;
            date = String.Format("{0} - {1}", sow.ToShortDateString(), eowf.ToShortDateString());
            dgv_crew.Columns[5].HeaderText = date;
        }
        private void Crew_listFormat()
        {
            
            dgv_crew.Columns[0].Visible = false;
            dgv_crew.Columns[2].HeaderText = "Название";
            dgv_crew.Columns[1].HeaderText = "Выполняемые работы"; dgv_crew.Columns[1].Width = 350;
            dgv_crew.Columns[3].HeaderText = "Количество рабочих";
            dgv_crew.Columns[4].HeaderText = "Машина";
            dgv_crew.Columns[5].HeaderText = "Инструменты";
            dgv_crew.Columns[6].HeaderText = "Гражданство";
            dgv_crew.Columns[7].HeaderText = "Телефон";
            dgv_crew.Columns[8].Visible = false;
            
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Form main = new NewEditCrew();
            main.FormClosed += updateDBCrew;
            main.Show();
        }
       private void filtersettings()
       {
            cb_car.Items.Clear();
            cb_car.Items.Add("Все равно");
            cb_car.Items.Add("Есть");
            cb_car.Items.Add("Нет");

            cb_tools.Items.Clear();
            cb_tools.Items.Add("Все равно");
            cb_tools.Items.Add("Есть");
            cb_tools.Items.Add("Нет");
            cb_tools.Items.Add("Частично");

            cb_nat.Items.Clear();
            cb_nat.Items.Add("Все равно");
            cb_nat.Items.Add("Есть");
            cb_nat.Items.Add("Нет");
            cb_nat.Items.Add("Патент");

            cb_car.SelectedIndex = 0;
            cb_tools.SelectedIndex = 0;
            cb_nat.SelectedIndex = 0;
            List<string> list = new List<string>();
            list.Add("Все равно");          
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            try
            {
                DataTable t = dbConn.getData(String.Format("SELECT * FROM `JobKind` WHERE  `id` < 100"));
                foreach (DataRow r in t.Rows)
                    list.Add(r[0].ToString() + ". " + r[1].ToString());
            }
            catch { }
            cb_type.DataSource = list;
        }
        private void filter()
        {
            try
            {
                int count = 0;
                try
                {
                    count = Convert.ToInt32(tb_count.Text);
                }
                catch { }
                string filter = String.Format("workers >= {0}", count);
                string i = cb_tools.SelectedItem.ToString(); if (i != "Все равно") filter += String.Format(" AND tools LIKE '{0}'", i);
                string n = cb_nat.SelectedItem.ToString(); if (n != "Все равно") filter += String.Format(" AND national LIKE '{0}'", n); ;
                string c = cb_car.SelectedItem.ToString(); if (c != "Все равно") filter += String.Format(" AND car LIKE '{0}'", c); ;
                string t = cb_type.SelectedItem.ToString(); if (t != "Все равно") filter += String.Format(" AND type LIKE '*{0}*'", t); ;
                
                crew.crew.RowFilter = filter;
            }
            catch { }
        }
        //обновление датагрида материалов 
        private void updateDBCrew(object sender, FormClosedEventArgs e)
        {
            crew = new CrewTable();
            Thread th = new Thread(crew.createdata);
            th.Start();
            filtersettings();
            th.Join();
            checkTable();

        }

        private void dgv_crew_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form main = new CrewEdit(Convert.ToInt32(dgv_crew.SelectedCells[0].Value));
            main.FormClosed += updateDBCrew;
            main.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form main = new CrewEdit(Convert.ToInt32(dgv_crew.SelectedRows[0].Cells[0].Value));
            main.FormClosed += updateDBCrew;
            main.Show();
        }

        private void dgv_crewinfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form main = new NewEditCrew();
            main.FormClosed += updateDBCrew;
            main.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                calendarFormat();
            }
            catch { }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(String.Format("Вы точно хотите удалить выделенные данные?"), "Подтверждение удаления", buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                    dbConn.deleteRawDataById("Crew", Convert.ToInt16(dgv_crew.SelectedCells[0].Value));
                    crew = new CrewTable();
                    crew.createdata();
                    checkTable();

                }
                catch (Exception exep)
                {
                    MessageBox.Show("Невозможно получить данные из БД");
                }
            }
        }

      

        private void button14_Click(object sender, EventArgs e)
        {
            Form main = new CrewSettings();
            main.FormClosed += updateDBCrew;
            main.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form main = new NewEditCrew(Convert.ToInt32(dgv_crew.SelectedCells[0].Value));
            main.FormClosed += updateDBCrew;
            main.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            cb_car.SelectedIndex = 0;
            cb_tools.SelectedIndex = 0;
            cb_nat.SelectedIndex = 0;
            cb_type.SelectedIndex = 0;
            tb_count.Text = "";
            filter();
        }

        private void tb_count_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkTable();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkTable();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            cl = new CrewLog();
            cl.createdata();
            calendarFormat();
            dgv_crew.DataSource = cl.createcalendar(cb_mounth.SelectedIndex + 1, Convert.ToInt16(cb_year.SelectedItem));
        }

        private void typesbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSup();
        }

        private void typesbox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            updateSup();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form main = new Types();
            main.FormClosed += updateDBSup;
            main.Show();
        }

        private void typesbox_MouseMove(object sender, MouseEventArgs e)
        {
            try { typesbox.SetSelected(typesbox.IndexFromPoint(e.X, e.Y), true); }
            catch { }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(String.Format("Вы точно хотите удалить выделенные данные?"), "Подтверждение удаления", buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                    dbConn.deleteRawDataById("suppliers", Convert.ToInt16(SupTable.SelectedCells[0].Value));
                    loadSup();

                }
                catch (Exception exep)
                {
                    MessageBox.Show("Невозможно получить данные из БД");
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form main = new Suppliers();
            main.FormClosed += updateDBSup;
            main.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form main = new Suppliers(SupTable.SelectedCells[0].Value.ToString());
            main.FormClosed += updateDBSup;
            main.Show();
        }
    }
}
