using Krov.Core;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using WindowsFormsApp1.Core;
using WindowsFormsApp1.Core.DatabaseTableClass;
using WindowsFormsApp1.Forms;

namespace Krov
{
    public partial class Main_form : Form
    {
        Manager user;
        BudgetTable t;
        CrewTable ct;
        CrewLog cl = new CrewLog();
        BDObject this_obj;
        DataTable part;
        string this_id = "";
        //базовый конструктор
        public Main_form(Manager _user)
        {
            InitializeComponent();
            tableinf();
            partstart();
            user = _user;
            dgv_part.DataSource = part;
        }
        //конструктор инициализирующий загрузку данных объекта из БД
        public Main_form(Manager _user,string id)
        {
            InitializeComponent();
            partstart();
            this.Text = name_box.Text + " " + addres.Text;
            user = _user;
            /* а вот тут выгрузка данных из БД по нужному id*/
            this_obj = Download(id);
            Thread th = new Thread(XMLConvert);
            th.Start();
            th.Join();
            foreach (string a in t.l_mat)
            {
                clb1.Items.Add(a);
            }
            foreach (string a in t.l_wor)
            {
                clb2.Items.Add(a);
                clb_crew.Items.Add(a);
            }
            name_box.Text = this_obj.name;
            addres.Text = this_obj.address;
            info.Text = this_obj.info;
            Date_auc_MTB.Text = this_obj.d_auction.ToString();
            Date_contract_MTB.Text = this_obj.d_contract.ToString();
            Date_plan_MTB.Text = this_obj.d_planned.ToString();
            Date_real_MTB.Text = this_obj.d_real.ToString();
            Date_payment_MTB.Text = this_obj.d_payment.ToString();
            this_id = id;            
            tableinf();
            tableinf();
            tableinf();
            dgv_part.DataSource = part;
            colors();
            filterfirst();
        }
        public void partstart()
        {
            try
            {
                part = new DataTable();
                part.Columns.Add("id", typeof(Int16));       //id для привязки строк
                part.Columns.Add("name", typeof(String));    //название этапа
                part.Columns.Add("proc", typeof(Double));
            }
            catch { }
        }
        private void cblist()
        {
            try
            {
                comboBox1.Items.Clear();
                for (int i = 0; i < part.Rows.Count; i++)
                    comboBox1.Items.Add(part.Rows[i][1]);
                comboBox1.SelectedIndex = 0;
            }
            catch { }
        }
        public void XMLConvert()
        {
            t = new BudgetTable(this_obj.workstype, this_obj.workskind, this_obj.crew, this_obj.crew_list);
            try
            {
                DataSet set1 = new DataSet();
                byte[] buffer1 = Encoding.UTF8.GetBytes(this_obj.part_list);
                using (MemoryStream stream1 = new MemoryStream(buffer1))
                {
                    XmlReader reader = XmlReader.Create(stream1);
                    set1.ReadXml(reader);
                }
                foreach (DataRow row in set1.Tables[0].Rows)
                {
                    try
                    {
                        part.Rows.Add(row[0], row[1], row[2]);
                        cblist();
                    }
                    catch { }
                }
            }
            catch{  }
        }
        //форматирование таблиц
       public void tableform2()
        {
            try
            {
                Crews.Columns[5].HeaderText = "Работа"; 
                Crews.Columns[8].HeaderText = "Количество"; Crews.Columns[8].Width = 100;
                Crews.Columns[9].HeaderText = "Единица измерения"; Crews.Columns[9].Width = 100;
                Crews.Columns[13].HeaderText = "Код работы"; Crews.Columns[13].DisplayIndex = 1; Crews.Columns[13].Width = 100;
                Crews.Columns[0].Visible = false;
                Crews.Columns[1].Visible = false;
                Crews.Columns[2].Visible = false;
                Crews.Columns[3].Visible = false;
                Crews.Columns[4].Visible = false;
                Crews.Columns[6].Visible = false;
                Crews.Columns[7].Visible = false;
                Crews.Columns[10].Visible = false;
                Crews.Columns[11].Visible = false;
                Crews.Columns[12].Visible = false;


            }
            catch { }
        }
        public void tableform3()
        {
            try
            {
                
                dgv_crew.Columns[0].Visible = false;
                dgv_crew.Columns[2].Visible = false;
                dgv_crew.Columns[12].Visible = false;
                dgv_crew.Columns[13].Visible = false;

                dgv_crew.Columns[1].HeaderText = "Бригада"; dgv_crew.Columns[1].Width = 75;
                dgv_crew.Columns[3].HeaderText = "Нач.раб.план.";
                dgv_crew.Columns[4].HeaderText = "Кон.раб.план.";
                dgv_crew.Columns[5].HeaderText = "Работа"; dgv_crew.Columns[5].Width = 350;
                dgv_crew.Columns[6].HeaderText = "Нач.раб.факт.";
                dgv_crew.Columns[7].HeaderText = "Кон.раб.факт.";
                dgv_crew.Columns[8].HeaderText = "Количество"; dgv_crew.Columns[8].Width = 75;
                dgv_crew.Columns[9].HeaderText = "Единица измерения"; dgv_crew.Columns[9].Width = 75;
                dgv_crew.Columns[10].HeaderText = "Сделано"; dgv_crew.Columns[10].Width = 75;
                dgv_crew.Columns[11].HeaderText = "Процент выполнения"; dgv_crew.Columns[11].Width = 75;



            }
            catch { }
        }
        public void tableinf()
        {
            ct = new CrewTable();
            cl = new CrewLog();
            Thread th1 = new Thread(cl.createdata);
            th1.Start();
            th1.Join();
            Thread th = new Thread(ct.createdata);
            th.Start();
            th.Join();




            try
            {
                dgv_mat.DataSource = part;
                dgv_wor.DataSource = t.works.Table;
                mat_datatable.DataSource = t.materials;
                dgv_part.DataSource = part;
                Works.DataSource = t.works;
                Crews.DataSource = t.crews;
                filterfirst();
                //Crew_list.DataSource = ct.crew;
                tableform2();
                
                try
                {
                    //dgv_crew.DataSource = cl.getbyObject(this_obj.name);
                }
                catch { }
                colors();
                price();

                /* Crews.Columns[0].Visible = false;
                 Crews.Columns[5].Visible = false;
                 Crews.Columns[1].Width = 400;
                 Crews.Columns[6].DisplayIndex = 2;*/

                mat_datatable.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                mat_datatable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgv_wor.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgv_wor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                Works.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                Works.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                Crews.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                Crews.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //Crew_list.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //Crew_list.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                mat_datatable.Columns[0].HeaderText = "Код"; mat_datatable.Columns[0].Width = 70;
                mat_datatable.Columns[1].HeaderText = "Название материала";
                mat_datatable.Columns[2].HeaderText = "Количество"; mat_datatable.Columns[2].Width = 70;
                mat_datatable.Columns[3].HeaderText = "Единица измерения"; mat_datatable.Columns[3].Width = 90;
                mat_datatable.Columns[4].HeaderText = "Цена за единицу"; mat_datatable.Columns[4].Width = 70;
                mat_datatable.Columns[5].HeaderText = "Общая цена"; mat_datatable.Columns[5].Width = 80;

                Works.Columns[0].HeaderText = "Код"; Works.Columns[0].Width = 70;
                Works.Columns[1].HeaderText = "Наименование";
                Works.Columns[2].HeaderText = "Тариф"; Works.Columns[2].Width = 60;
                Works.Columns[3].HeaderText = "Количество"; Works.Columns[3].Width = 60;
                Works.Columns[4].HeaderText = "Единица измерения"; Works.Columns[4].Width = 50;
                Works.Columns[5].HeaderText = "Цена работы"; Works.Columns[5].Width = 60;
                Works.Columns[6].HeaderText = "Общая цена"; Works.Columns[6].Width = 80;


                dgv_mat.Columns[0].HeaderText = "№"; dgv_mat.Columns[0].Width = 30;
                dgv_mat.Columns[1].HeaderText = "Этап";
                dgv_mat.Columns[2].HeaderText = "Процент выполнения";

                dgv_part.Columns[0].HeaderText = "№"; dgv_part.Columns[0].Width = 30;
                dgv_part.Columns[1].HeaderText = "Этап";
                dgv_part.Columns[2].Visible = false;


                dgv_wor.Columns[0].HeaderText = "Код"; 
                dgv_wor.Columns[1].HeaderText = "Наименование";
                dgv_wor.Columns[2].HeaderText = "Тариф"; 
                dgv_wor.Columns[3].HeaderText = "Количество"; 
                dgv_wor.Columns[4].HeaderText = "Единица измерения"; 
                dgv_wor.Columns[5].HeaderText = "Цена работы"; 
                dgv_wor.Columns[6].HeaderText = "Общая цена";

                //dgv_mat.Columns[0].Width = 50;
                //dgv_mat.Columns[2].Width = 50;
                //dgv_mat.Columns[3].Width = 50;
                //dgv_mat.Columns[4].Width = 50;
                //dgv_mat.Columns[5].Width = 80;

                //dgv_wor.Columns[0].Width = 50;
                //dgv_wor.Columns[2].Width = 30;
                //dgv_wor.Columns[3].Width = 30;
                //dgv_wor.Columns[4].Width = 30;
                //dgv_wor.Columns[5].Width = 40;
                //dgv_wor.Columns[6].Width = 80;
                CrewsFormat();
                tableform3();

                colors();
            }
            catch { }
           
        }       
       
        //создание Объекто по id  с целью дальнейшего разброса данных из объекта класса в конструкторе выше.
        public BDObject Download(string id)
        {
            //выгрузка данных из БД в объект класса BDObject используя временную таблицу
            BDObject i = new BDObject();
            DataTable dataTable = new DataTable();
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dataTable = dbConn.getData("SELECT * FROM `Object` WHERE id='" + id + "'");
            i.name = dataTable.Rows[0][1].ToString();
            i.address = dataTable.Rows[0][2].ToString();
            i.workstype = Convert.ToString(dataTable.Rows[0][3].ToString());
            i.workskind = Convert.ToString(dataTable.Rows[0][13].ToString());
            i.d_auction = Convert.ToDateTime(dataTable.Rows[0][4].ToString());
            i.d_contract = Convert.ToDateTime(dataTable.Rows[0][5].ToString());
            i.d_planned = Convert.ToDateTime(dataTable.Rows[0][6].ToString());
            i.d_real = Convert.ToDateTime(dataTable.Rows[0][7].ToString());
            i.d_payment = Convert.ToDateTime(dataTable.Rows[0][8].ToString());
            i.crew = dataTable.Rows[0][9].ToString();
            i.info = dataTable.Rows[0][14].ToString();
            i.crew_list =  dataTable.Rows[0][15].ToString();
            i.part_list = dataTable.Rows[0][16].ToString();
            i.parts = dataTable.Rows[0][17].ToString();

            return i;
        }
        public string reload_Crew(string id)
        {
            DataTable dataTable = new DataTable();
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dataTable = dbConn.getData("SELECT `Crew` FROM `Object` WHERE id='" + id + "'");           
            return  dataTable.Rows[0][0].ToString();
          
        }

        //действие формы при закрытии
        private void Main_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormCollection formlist = Application.OpenForms;
            formlist[1].Show();
        }
        //выбираем по какому фильтру форматируем таблицу
        private void Main_panel_TC_Selected(object sender, TabControlEventArgs e)
        {
            if (Main_panel_TC.SelectedIndex == 1) Changed();
            if (Main_panel_TC.SelectedIndex == 2) Changed2();
            try
            {
                tableinf();
            }
            catch { }
        }

        //вычисление общей суммы, обновление лейбла
        void price()
        {
            try
            {
                //i - ценник материалов j - ценник работ
                double i = 0;
                double j = 0;
                double k = 0;
                double l = 0;
                foreach (DataRow row in t.materials.ToTable().Rows)
                {
                    i += Math.Round(Convert.ToDouble(row[5]), 2);
                }
                foreach (DataRow row in t.works.ToTable().Rows)
                {
                    j += Math.Round(Convert.ToDouble(row[6]), 2);
                }
                foreach (DataRow row in t.materials.Table.Rows)
                {
                    k += Math.Round(Convert.ToDouble(row[5]), 2);
                }
                foreach (DataRow row in t.works.Table.Rows)
                {
                    l += Math.Round(Convert.ToDouble(row[6]), 2);
                }
                Finalprice.Text = String.Format("Итого: {0} руб.", i);
                Finalwprice.Text = String.Format("Итого: {0} руб.", j);


                mat_price.Text = String.Format("Стоимость материалов: {0} руб.", k);
                Workprice.Text = String.Format("Стоимость работы: {0} руб.", l);
                final_price.Text = String.Format("Итоговая сумма заказа: {0} руб.", k + l);
            }
            catch { }
        }
       
        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                //если объект уже существующий то обновим данные
                if (this_id != "")
                {
                    t.get_name_obj(name_box.Text);
                    dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                    dbConn.updateDataById("Object", Convert.ToInt32(this_id), "name", name_box.Text);
                    dbConn.updateDataById("Object", Convert.ToInt32(this_id), "address", addres.Text);
                    dbConn.updateDataById("Object", Convert.ToInt32(this_id), "date_auction", Convert.ToDateTime(Date_auc_MTB.Text).ToString("yyyy-MM-dd"));
                    dbConn.updateDataById("Object", Convert.ToInt32(this_id), "date_contract", Convert.ToDateTime(Date_contract_MTB.Text).ToString("yyyy-MM-dd"));
                    dbConn.updateDataById("Object", Convert.ToInt32(this_id), "date_plan", Convert.ToDateTime(Date_plan_MTB.Text).ToString("yyyy-MM-dd"));
                    dbConn.updateDataById("Object", Convert.ToInt32(this_id), "date_real", Convert.ToDateTime(Date_real_MTB.Text).ToString("yyyy-MM-dd"));
                    dbConn.updateDataById("Object", Convert.ToInt32(this_id), "date_payment", Convert.ToDateTime(Date_payment_MTB.Text).ToString("yyyy-MM-dd"));
                    dbConn.updateDataById("Object", Convert.ToInt32(this_id), "manager", user.login);
                    dbConn.updateDataById("Object", Convert.ToInt32(this_id), "jobkind", t.materials_XML());
                    dbConn.updateDataById("Object", Convert.ToInt32(this_id), "workskind", t.works_XML());
                    dbConn.updateDataById("Object", Convert.ToInt32(this_id), "crew", t.crew_XML());                    
                    dbConn.updateDataById("Object", Convert.ToInt32(this_id), "info", info.Text);
                    dbConn.updateDataById("Object", Convert.ToInt32(this_id), "part_list", getXML(part));
                    this.Close();
                }
                else
                {
                    //создадим новый объект 
                    try
                    {
                        dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                        BDObject objec = new BDObject();
                        t.get_name_obj(name_box.Text);
                        objec.name = name_box.Text;
                        objec.address = addres.Text;
                        objec.info = info.Text;
                        objec.workstype = t.materials_XML();
                        objec.workskind = t.works_XML();
                        objec.crew = t.crew_XML();
                        objec.part_list = getXML(part);
                        try
                        {
                            objec.d_auction = Convert.ToDateTime(Date_auc_MTB.Text.ToString());
                            objec.d_contract = Convert.ToDateTime(Date_contract_MTB.Text.ToString());
                            objec.d_payment = Convert.ToDateTime(Date_payment_MTB.Text.ToString());
                            objec.d_planned = Convert.ToDateTime(Date_plan_MTB.Text.ToString());
                            objec.d_real = Convert.ToDateTime(Date_real_MTB.Text.ToString());
                        }
                        catch { MessageBox.Show("Неправильный формат внесенных данных дат объекта\nПроект будет сохранен с текущими данными автозаполнением."); }
                        objec.manager = user.login;
                        dbConn.insertDataToObjects(objec);
                        this.Close();
                    }
                    catch {
                        MessageBox.Show("Не удалось создать объект");
                    }
                }                
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        //создание пдф файла материалов
        private void button7_Click(object sender, EventArgs e)
        {
            PDFs item = new PDFs(user);
            int length = name_box.Text.Length;
            if (name_box.Text.IndexOf('"') > 0) length = name_box.Text.IndexOf('"') - 1;
            item.materials1(t.materials.ToTable(), String.Format("Krov/{0}/PDF/{1}_материалы с ценой.pdf", user.login, name_box.Text.Substring(0, length)), mat_price.Text.ToString(), name_box.Text);
            item.materials2(t.materials.ToTable(), String.Format("Krov/{0}/PDF/{1}_материалы.pdf", user.login, name_box.Text.Substring(0, length)), mat_price.Text.ToString(), name_box.Text);
            MessageBox.Show("Сформировано!");
        }

        public void colors()
        {
            try
            {
                for (int i = 0; i < dgv_crew.Rows.Count; i ++)
                {
                    if (Convert.ToInt16(dgv_crew.Rows[i].Cells[11].Value) >= 100) dgv_crew.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                    else if (Convert.ToInt16(dgv_crew.Rows[i].Cells[11].Value) == 0) dgv_crew.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                    else if (Convert.ToInt16(dgv_crew.Rows[i].Cells[11].Value) >= 50) dgv_crew.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (Convert.ToInt16(dgv_crew.Rows[i].Cells[11].Value) >= 25) dgv_crew.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                    else dgv_crew.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
            catch { }
        }
        //кнопка загрузки из excell файла. грузит данные из экселя, дб, загоняет в одну таблицу
        private void button8_Click(object sender, EventArgs e)
        {
            
            t = new BudgetTable();
            t.generateExcellTable();
            clb1.Items.Clear();
            clb2.Items.Clear();
            clb_crew.Items.Clear();
            using (WaitingForm frm = new WaitingForm(t.createdata))
            {
                frm.ShowDialog(this);
            }

            t.get_name_obj(name_box.Text);
            try
            {
                foreach (string a in t.l_mat)
                {
                    clb1.Items.Add(a);
                }
            }
            catch { }
            try
            {
                foreach (string a in t.l_wor)
                {
                    clb2.Items.Add(a);
                    clb_crew.Items.Add(a);
                }
            }
            catch { }
            tableinf();
            price();
            if (t.errors.Count > 0)
                ShMess();

        }
      
        //кнопочка письма. появляется когда есть отсутствующие данные
        private void button5_Click_1(object sender, EventArgs e)
        {
            ShMess();            
        }
        //вывод сообщения об отсутствующих материалах
        public void ShMess()
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            tableinf();

            result = MessageBox.Show(String.Format("В базе отсутствуют {0} позиций из сметы\nДобавить новые позиции в БД?", t.errors.Count), "", buttons);
            
            //если все успешно инициализирует процесс заполнения данных в БД запуская форму материалов
            if (result == System.Windows.Forms.DialogResult.Yes)
            {                
                Form main = new AddMatherial(t.errors);
                //при закрытии формы редактирования обновляет таблицу материалов в основной форме
                //main.FormClosed += updateDB;
                main.Show();
            }
        }
        /*
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * ВОТ ТУТ ЕСТЬ ФУНКЦИЯ ЧТО Я ИСКАЛЪ LMAO НЕ ЗАБЫТЬ ПРО НЕЕ 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * */
        //функция обновления данных в БД при закрытии формы с добавлением материалов
        private void updateDB(object sender, FormClosedEventArgs e)
        {
            //перегружает данные из БД
            using (WaitingForm frm = new WaitingForm(t.createdata))
            {
                frm.ShowDialog(this);
            }
            tableinf();           
            //после перегрузки есть ошибки?  Ave рекурсия
            if (t.errors.Count > 0)
            {
                button5.Visible = true;
                ShMess();
            }           
        }
        //генерация pdf "Материалы" и запуск окна Отправить письмо
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                PDFs item = new PDFs(user);
                int length = name_box.Text.Length;
                if (name_box.Text.IndexOf('"') > 0) length = name_box.Text.IndexOf('"') - 1;
                item.materials1(t.materials.ToTable(), String.Format("Krov/{0}/PDF/{1}_материалы.pdf", user.login, name_box.Text.Substring(0, length)), mat_price.Text.ToString(), name_box.Text);
               
                Form mail = new Mailform(String.Format("Krov/{0}/PDF/{1}_материалы.pdf", user.login, name_box.Text.Substring(0, length)), user);
                mail.Show();
            }
            catch(Exception ex){ MessageBox.Show(ex.ToString()); }
        }
          
        //отслеживание изменения в сомбобоксе Материалов
        private void clb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Changed();
        }     

        private void clb1_MouseClick(object sender, MouseEventArgs e)
        {
           Changed();
        }
        public void Changed()
        {

            try
            {
                string s;
                //в зависимости от количества добавленных элементов фильтра дописывает стрингу фильтра
                if (clb1.CheckedItems.Count > 0)
                {
                    s = String.Format("code LIKE '{0}-*' ", clb1.CheckedItems[0].ToString().Substring(0, clb1.CheckedItems[0].ToString().IndexOf('.')));
                    if (clb1.CheckedItems.Count > 1)
                        for (int i = 1; i < clb1.CheckedItems.Count; i++)
                            s += String.Format(" OR code LIKE '{0}-*' ", clb1.CheckedItems[i].ToString().Substring(0, clb1.CheckedItems[i].ToString().IndexOf('.')));
                }
                else
                    //если комбобокс не выбран - очищает фильтр
                    s = "";
                t.materials.RowFilter = s;
                mat_datatable.DataSource = t.materials;
            }
            catch { }
        }
        public void CrewFilter()
        {

            try
            {
                string s;
                string s1;
                //в зависимости от количества добавленных элементов фильтра дописывает стрингу фильтра
                if (clb_crew.CheckedItems.Count > 0)
                {
                    s = String.Format("code LIKE '{0}-*' ", clb_crew.CheckedItems[0].ToString().Substring(0, clb_crew.CheckedItems[0].ToString().IndexOf('.')));
                    if (clb_crew.CheckedItems.Count > 1)
                        for (int i = 1; i < clb_crew.CheckedItems.Count; i++)
                            s += String.Format(" OR code LIKE '{0}-*' ", clb_crew.CheckedItems[i].ToString().Substring(0, clb_crew.CheckedItems[i].ToString().IndexOf('.')));

                    s1 = String.Format("type LIKE '*{0}*'", clb_crew.CheckedItems[0].ToString().Substring(0, clb_crew.CheckedItems[0].ToString().IndexOf('.')));
                    if (clb_crew.CheckedItems.Count > 1)
                        for (int i = 1; i < clb_crew.CheckedItems.Count; i++)
                            s1 += String.Format(" OR type LIKE '*{0}*'", clb_crew.CheckedItems[i].ToString().Substring(0, clb_crew.CheckedItems[i].ToString().IndexOf('.')));
                    s += " AND part = 0";
                }
                else
                {
                    //если комбобокс не выбран - очищает фильтр
                    s = "part = 0";
                    s1 = "";
                }
              
                t.crews.RowFilter = s;
                
                Crews.DataSource = t.crews;
                //Crew_list.DataSource = ct.crew;

            }
            catch { }
        }
        //все тоже самое что и выше, но для вкладки Работы
        public void Changed2()
        {
            try
            {
                string s;
                //в зависимости от количества добавленных элементов фильтра дописывает стрингу фильтра
                if (clb2.CheckedItems.Count > 0)
                {
                    s = String.Format("code LIKE '{0}-*' ", clb2.CheckedItems[0].ToString().Substring(0, clb2.CheckedItems[0].ToString().IndexOf('.')));
                    if (clb2.CheckedItems.Count > 1)
                        for (int i = 1; i < clb2.CheckedItems.Count; i++)
                            s += String.Format(" OR code LIKE '{0}-*' ", clb2.CheckedItems[i].ToString().Substring(0, clb2.CheckedItems[i].ToString().IndexOf('.')));
                }
                else
                    s = "";
                t.works.RowFilter = s;
                mat_datatable.DataSource = t.materials;
            }
            catch { }
        }
        //обновление фильтра при движении мыши
        private void clb1_MouseMove(object sender, MouseEventArgs e)
        {
            try { clb1.SetSelected(clb1.IndexFromPoint(e.X, e.Y), true); }
            catch { }
            Changed();
            price();
        }
        private void clb2_MouseMove(object sender, MouseEventArgs e)
        {
            try { clb2.SetSelected(clb2.IndexFromPoint(e.X, e.Y), true); }
            catch { }
            Changed2();
            price();
        }
        private void clb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Changed2();
        }
        private void clb2_MouseClick(object sender, MouseEventArgs e)
        {
            Changed2();
        }
     
        //создание тестового PDF Работы
        private void button9_Click(object sender, EventArgs e)
        {
            PDFs item = new PDFs(user);
            int length = name_box.Text.Length;
            if (name_box.Text.IndexOf('"') > 0) length = name_box.Text.IndexOf('"') - 1;
            item.workers(t.works.ToTable(), String.Format( "Krov/{0}/PDF/{1}_работа.pdf", user.login, name_box.Text.Substring(0,length)), Workprice.Text.ToString(), name_box.Text);            
        }
        //обновление ценника при изменении ячеек в таблице В идеале сюда же дописать и обновление данных финальных в БД ну или их динамообновление
      
        //кнопка "Отправить письмо" для вкладки Работа
        private void button4_Click_2(object sender, EventArgs e)
        {
            try
            {
                PDFs item = new PDFs(user);
                int length = name_box.Text.Length;
                string[] arr =
                   {
                    name_box.Text,
                    addres.Text,
                    Date_plan_MTB.Text,
                    "Авансирование предусмотрено",
                    "Оплата по завершению объекта в течение 18 дней "
                     };
                if (name_box.Text.IndexOf('"') > 0) length = name_box.Text.IndexOf('"') - 1;
                item.workers(t.works.ToTable(), String.Format("Krov/{0}/PDF/{1}_работа.pdf", user.login, name_box.Text.Substring(0, length)), Workprice.Text.ToString(), name_box.Text);
                Form mail = new Mailform(String.Format("Krov/{0}/PDF/{1}_работа.pdf", user.login, name_box.Text.Substring(0, length)), user, arr);
                mail.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        /*
         * 
         * 
         * 
         * 
         * 
         * ЗАГЛУШГКА В ПОЧТЕ ПОПРАВИТЬ ПОТОМ
         *  МАССИВ
         * 
         * 
         * 
         * 
         * 
         */
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
               
                Form mail = new Mailform("Krov/" + user.login + "/Договора/Карточка предприятия ООО КРОВЛЯ163.doc" , user);
                mail.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
          
        }

        private void Works_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            WorksChange();
           
            
        }
        private void WorksChange()
        {
            try {

                t.works.Table.PrimaryKey = new DataColumn[] { t.works.Table.Columns["code"] };
                int i = t.works.Table.Rows.IndexOf(t.works.Table.Rows.Find(Works.Rows[Works.SelectedRows[0].Index].Cells[0].Value.ToString()));
                t.works.Table.Rows[i][0] = Works.SelectedCells[0].Value;
                t.works.Table.Rows[i][1] = Works.SelectedCells[1].Value;
                t.works.Table.Rows[i][2] = Works.SelectedCells[2].Value;
                t.works.Table.Rows[i][3] = Works.SelectedCells[3].Value;
                t.works.Table.Rows[i][4] = Works.SelectedCells[4].Value;
                t.works.Table.Rows[i][5] = Works.SelectedCells[5].Value;
                t.works.Table.Rows[i][6] = Math.Round(Convert.ToDouble(Works.SelectedCells[5].Value) * Convert.ToDouble(Works.SelectedCells[2].Value) * Convert.ToDouble(Works.SelectedCells[3].Value), 2);
                Works.DataSource = t.works;
                Crews.DataSource = t.crews;
                colors();
                price();
                }
            catch { }
        }
        private void matmodChange()
        {
            try
            {

                t.materials.Table.PrimaryKey = new DataColumn[] { t.materials.Table.Columns["code"] };
                int i = t.materials.Table.Rows.IndexOf(t.materials.Table.Rows.Find(mat_datatable.Rows[mat_datatable.SelectedRows[0].Index].Cells[0].Value.ToString()));
                t.materials.Table.Rows[i][0] = mat_datatable.SelectedCells[0].Value;
                t.materials.Table.Rows[i][1] = mat_datatable.SelectedCells[1].Value;
                t.materials.Table.Rows[i][2] = mat_datatable.SelectedCells[2].Value;
                t.materials.Table.Rows[i][3] = mat_datatable.SelectedCells[3].Value;
                t.materials.Table.Rows[i][4] = mat_datatable.SelectedCells[4].Value;
                t.materials.Table.Rows[i][5] = Convert.ToDouble(mat_datatable.SelectedCells[4].Value) * Convert.ToDouble(mat_datatable.SelectedCells[2].Value);
                mat_datatable.DataSource = t.materials;
                price();
            }
            catch { }
        }
        private void mat_datatable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            matmodChange();
        }

        private void but_del1_Click(object sender, EventArgs e)
        {
            try
            {
                t.materials.Table.PrimaryKey = new DataColumn[] { t.materials.Table.Columns["code"] };
                int i = t.materials.Table.Rows.IndexOf(t.materials.Table.Rows.Find(mat_datatable.Rows[mat_datatable.SelectedRows[0].Index].Cells[0].Value.ToString()));
                t.materials.Table.Rows[i].Delete();
                price();
                reloadLists();
            }
            catch { }
        }

        private void name_box_TextChanged(object sender, EventArgs e)
        {
            this.Text = name_box.Text + " " + addres.Text;
        }

        private void but_del2_Click(object sender, EventArgs e)
        {
            try
            {
                t.works.Table.PrimaryKey = new DataColumn[] { t.works.Table.Columns["code"] };
                int i = t.works.Table.Rows.IndexOf(t.works.Table.Rows.Find(Works.Rows[Works.SelectedRows[0].Index].Cells[0].Value.ToString()));
                t.works.Table.Rows[i].Delete();
                reloadLists();
                price();
            }
            catch { }
        }

        private void reloadLists()
        {
            if (t.materials.ToTable().Rows.Count == 0 || t.works.ToTable().Rows.Count == 0)
            {
                using (WaitingForm frm = new WaitingForm(t.reloadLists))
                {
                    frm.ShowDialog(this);
                }                
                clb1.Items.Clear();
                clb2.Items.Clear();
                foreach (string a in t.l_mat)
                {
                    clb1.Items.Add(a);
                }
                foreach (string a in t.l_wor)
                {
                    clb2.Items.Add(a);
                }
                Changed();
                Changed2();
                CrewFilter();
            }
        }
        private void addres_TextChanged(object sender, EventArgs e)
        {
            this.Text = name_box.Text + " " + addres.Text;
        }

        private void Crews_MouseMove(object sender, MouseEventArgs e)
        {

            colors();
        }

        private void clb_crew_SelectedIndexChanged(object sender, EventArgs e)
        {
            CrewFilter();
        }

        private void clb_crew_MouseMove(object sender, MouseEventArgs e)
        {
            try { clb_crew.SetSelected(clb_crew.IndexFromPoint(e.X, e.Y), true); }
            catch { }
            CrewFilter();
            colors();
            price();
        }

        private void Crews_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
           
            
        }

        private void Crews_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Works_RowLeave(object sender, DataGridViewCellEventArgs e)
        {           
        }

        private void Works_MouseMove(object sender, MouseEventArgs e)
        {           
        }

        private void Main_panel_TC_MouseDown(object sender, MouseEventArgs e)
        {        
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {

                if (this_obj == null || this_id == "")
                {
                    MessageBox.Show(String.Format("Перед выполнением данной процедуры сохраните проект\nс корректными наименованиями названия и дат."));
                }
                else
                {
                    
                    Form obj = new Object_crew(Convert.ToInt16(Crews.SelectedCells[0].Value), Convert.ToInt16(dgv_part.SelectedCells[0].Value), dgv_part.SelectedCells[1].Value.ToString(), this_id, t.crews);
                    obj.FormClosed += updateDBCrew;
                    obj.Show();
                }
            }
            catch { }
              
        }
        private void updateDBCrew(object sender, FormClosedEventArgs e)
        {           
            tableinf();
            colors();
            filterfirst();
        }       
        private void filterfirst()
        {
            try
            {
                string filter = "part = 0";
                t.crews.RowFilter = filter;
                Crews.DataSource = t.crews;
            }
            catch(Exception exepc){ MessageBox.Show(exepc.ToString()); }
        }
        private void filtersecond()
        {
            try
            {
                string filter = String.Format("part = {0}", comboBox1.SelectedIndex+1);
                t.crews.RowFilter = filter;
                dgv_crew.DataSource = t.crews;
                tableform3();
            }
            catch (Exception exepc) { MessageBox.Show(exepc.ToString()); }
        }
        private void CrewsFormat()
        {
          Crews.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            Crews.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            /*Crews.Columns[1].HeaderText = "Название"; Crews.Columns[1].Width = 350;
            Crews.Columns[6].HeaderText = "Даты"; Crews.Columns[6].Width = 230;
            Crews.Columns[2].HeaderText = "Количество";
            Crews.Columns[3].HeaderText = "Ед. измерения";
            Crews.Columns[4].HeaderText = "Процент готовности";*/
        }
       
       

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(dgv_crew.SelectedRows[0].Cells[0].Value);
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                tableinf();

                result = MessageBox.Show(String.Format("Удалить выбранную запись?"), "", buttons);

                //если все успешно инициализирует процесс заполнения данных в БД запуская форму материалов
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                    dbConn.deleteRawDataById("Crew_log", id);
                    Thread th = new Thread(update);
                    th.Start();
                    th.Join();
                    Crews.DataSource = t.crews;
                    dgv_crew.DataSource = t.crews;
                    tableform3();
                }
            }
            catch { }
        }
        private void update()
        {
            cl = new CrewLog();
            cl.createdata();
            
            for(int i = 1; i < t.crews.Table.Rows.Count; i+=2 )
            {
                DataTable temp = cl.getbyWork(t.crews.Table.Rows[i][1].ToString());
                t.crews.Table.Rows[i][6] = "";
                t.crews.Table.Rows[i][2] = 0;
                t.crews.Table.Rows[i][4] = 0;
                if (temp.Rows.Count > 0)
                {                   
                    for (int j = 0; j < temp.Rows.Count; j++)
                    {
                        t.crews.Table.Rows[i][6] = t.crews.Table.Rows[i][6] + Convert.ToDateTime(temp.Rows[j][3].ToString()).ToShortDateString() + " - " + Convert.ToDateTime(temp.Rows[j][4].ToString()).ToShortDateString() + " " + temp.Rows[j][2].ToString() + "\n";
                        t.crews.Table.Rows[i][2] = Convert.ToDouble(t.crews.Table.Rows[i][2]) + Convert.ToDouble(temp.Rows[j][6].ToString());
                        t.crews.Table.Rows[i][4] = Convert.ToInt16(100 * Convert.ToDouble(t.crews.Table.Rows[i][2]) / Convert.ToDouble(t.crews.Table.Rows[i - 1][2]));
                    }
                }
            }
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
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            tableinf();

            result = MessageBox.Show(String.Format("Вы хотите добавить этап \n<<{0}>>?", tb_part.Text), "", buttons);

            //если все успешно инициализирует процесс заполнения данных в БД запуская форму материалов
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                part.Rows.Add(part.Rows.Count + 1, tb_part.Text, 0);
                dgv_part.DataSource = part;
                cblist();
                countpart();
                tb_part.Text = "";
            }
        }

        private void tabPage3_MouseEnter(object sender, EventArgs e)
        {
            filtersecond();
            colors();
            countpart();
            dgv1();
        }

        private void tabPage3_MouseMove(object sender, MouseEventArgs e)
        {
            filtersecond();
            colors();
            countpart();
            dgv1();
        }

        private void dgv_crew_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {

                t.crews.Table.PrimaryKey = new DataColumn[] { t.crews.Table.Columns["num"] };
                int i = t.crews.Table.Rows.IndexOf(t.crews.Table.Rows.Find(dgv_crew.Rows[dgv_crew.SelectedRows[0].Index].Cells[6].Value.ToString()));
                t.crews.Table.Rows[i][6] = dgv_crew.SelectedCells[6].Value;
                t.crews.Table.Rows[i][7] = dgv_crew.SelectedCells[7].Value;
                t.crews.Table.Rows[i][10] = Convert.ToDouble(dgv_crew.SelectedCells[10].Value);
                int a = Convert.ToInt16(100 * Convert.ToDouble(dgv_crew.SelectedCells[10].Value.ToString().Replace(".", ",")) / Convert.ToDouble(dgv_crew.SelectedCells[8].Value));
                t.crews.Table.Rows[i][12] = a;
                dgv_crew.DataSource = t.crews;
                price();
            }
            catch { }
            colors();
        }

        private void dgv_crew_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                t.crews.Table.PrimaryKey = new DataColumn[] { t.crews.Table.Columns["id"] };

                int i = Convert.ToInt16(dgv_crew.SelectedCells[0].Value.ToString());
                t.crews.Table.Rows[i][6] = dgv_crew.SelectedCells[6].Value;
                t.crews.Table.Rows[i][7] = dgv_crew.SelectedCells[7].Value;
                t.crews.Table.Rows[i][10] = Convert.ToDouble(dgv_crew.SelectedCells[10].Value.ToString().Replace(".", ","));
                int a = Convert.ToInt16(100 * Convert.ToDouble(dgv_crew.SelectedCells[10].Value.ToString().Replace(".", ",")) / Convert.ToDouble(dgv_crew.SelectedCells[8].Value.ToString().Replace(".", ",")));
                if (a > 100) a = 100;
                t.crews.Table.Rows[i][11] = a;
                dgv_crew.DataSource = t.crews;
                price();
                countpart();
                
            }
            catch(Exception qw) { MessageBox.Show(qw.ToString()); }
            colors();
        }
        private void countpart()
        {
            try
            {
                int a = 0;
                for (int i = 0; i < t.crews.ToTable().Rows.Count; i++)
                {
                    a += Convert.ToInt16(t.crews.ToTable().Rows[i][11]);
                }
                a = a / t.crews.ToTable().Rows.Count;
                part.Rows[comboBox1.SelectedIndex][2] = a;
                label7.Text = a + "%";
                
            }
            catch { }
        }
        private void dgv1()
        {
            try
            {
                partstable.DataSource = part;
                partstable.Columns[0].HeaderText = "№"; partstable.Columns[0].Width = 30;
                partstable.Columns[1].HeaderText = "Этап";
                partstable.Columns[2].HeaderText = "Процент выполнения";
            }
            catch { }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                
            }
            catch { }
        }

        private void dgv_crew_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                t.crews.Table.PrimaryKey = new DataColumn[] { t.crews.Table.Columns["id"] };
                int i = Convert.ToInt16(dgv_crew.SelectedCells[0].Value.ToString());
                t.crews.Table.Rows[i][10] = Convert.ToDouble(dgv_crew.SelectedCells[10].Value.ToString().Replace(".", ","));
            }
            catch { }
        }
    }
}
/*
 
    ВХОДИ СТРАННИК. ТЫ ПОКИДАЕШЬ ЗОНУ ТЕСТОВОГО НО РАБОЧЕГО КОДА И ВХОДИШЬ НА ЗЕМЛЮ УМЕРШЕГО ЗАКОММЕНТИРОВАННОГО КОДА
    ТУТ ХРАНЯТСЯ СПОСОБНЫЕ В ТЕОРИИ ПРИГОДИТСЯ КУСКИ КОДА. НО ЭТО НЕ ТОЧНО
    DEUS VULT
     
     */

//глобальные переменные
//логин манагера что делает проект
//таблица выводимых в таблицы данных
//DataView Shown = new DataView();
//список недостающих записей в БД Материалы
//List<DataRow> errors;
//таблица данных о типах работ
//DataTable jobKind = new DataTable();
//таблица данных выгружаемых из excell
//DataTable excellData = new DataTable();
//глобальная переменная id текущего объекта. Для нового - пустой
//тестовый пдфник. формат наобум
//public void createPDF(string name, int testing_value)
//{
//    //1 или 2 - выбор что генерировать 1 - материалы, 2 - работы
//    int last_row = 4;
//    string table_name = "";
//    string price = "";

//    if (testing_value == 1)
//    {
//        last_row = 4;
//        table_name = "Стоимость материалов";
//        price = mat_price.Text.ToString();
//    }
//    if (testing_value == 2)
//    {
//        last_row = 6;
//        table_name = "Стоимость работ";
//        price = Workprice.Text.ToString();
//    }

//    Directory.CreateDirectory("Krov/" + user.login + "/Фото");
//    Directory.CreateDirectory("Krov/" + user.login + "/Чеки");
//    Directory.CreateDirectory("Krov/" + user.login + "/Отчеты");
//    Directory.CreateDirectory("Krov/" + user.login + "/Договора");
//    Directory.CreateDirectory("Krov/" + user.login + "/PDF");

//    Document document = new Document();
//    FileStream fs = new FileStream(name, FileMode.Create);
//    PdfWriter writer = PdfWriter.GetInstance(document, fs);
//    document.Open();
//    //настройки шрифта для русского текста
//    BaseFont baseFont = BaseFont.CreateFont(@"arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
//    iTextSharp.text.Font font5 = new iTextSharp.text.Font(baseFont, 5, iTextSharp.text.Font.NORMAL);
//    PdfPTable table = new PdfPTable(3);
//    PdfPRow row = null;
//    float[] widths = new float[] { 4f, 4f, 4f };
//    table.SetWidths(widths);
//    table.WidthPercentage = 100;
//    //создание таблицы в PDF
//    table.AddCell(new Phrase("Наименование", font5));
//    table.AddCell(new Phrase("Количество", font5));
//    table.AddCell(new Phrase(table_name, font5));
//    //ее наполнение
//    //foreach (DataRow r in Shown.ToTable().Rows)
//    //{
//    //    if (Shown.ToTable().Rows.Count > 0)
//    //    {
//    //        table.AddCell(new Phrase(r[1].ToString(), font5));
//    //        table.AddCell(new Phrase(r[2].ToString(), font5));
//    //        table.AddCell(new Phrase(r[last_row].ToString(), font5));
//    //    }
//    //}
//    //засовывание таблицы в PDF
//    document.Add(table);
//    //засовывание суммарной цены в PDF
//    Paragraph par = new Paragraph("\n\n\n" + price , font5);
//    document.Add(par);
//    //закрытие всего
//    document.CloseDocument();
//    document.Close();
//    fs.Close();
//    writer.Close();
//}
//зачем-то дублировала данные из Shown
//DataTable result = new DataTable();        
//таблица с данными далее заносимыми в PDF ныне не используется.
//DataTable matherials = new DataTable();
//mat_datatable.Columns[1].Width = 480;
//mat_datatable.Columns[0].HeaderText = "Код";
//mat_datatable.Columns[1].HeaderText = "Наименование";
//mat_datatable.Columns[2].HeaderText = "Количество";
//mat_datatable.Columns[3].HeaderText = "Цена за единицу";
//mat_datatable.Columns[4].HeaderText = "Общая цена";
//matherials.Columns.Add("Name", typeof(String)); 
//matherials.Columns.Add("Count", typeof(Double));
//matherials.Columns.Add("Price", typeof(Double));

//DG_matherials.Columns[0].HeaderText = "Наименование";
//DG_matherials.Columns[1].HeaderText = "Количество";
//DG_matherials.Columns[2].HeaderText = "Цена";

//matdblist.Columns[0].HeaderText = "Наименование";
//matdblist.Columns[1].HeaderText = "Количество";
//matdblist.Columns[2].HeaderText = "Цена";

//matdblist.Columns[0].Width = 495;
// DG_matherials.Columns[0].Width = 525;
//private void button10_Click_1(object sender, EventArgs e)
//{
//   
//}

//открытия кнопок и таблицы редактирования материалов
//////private void button9_Click(object sender, EventArgs e)
//////{
//////    Form main = new AddMatherial("sdfgdgdf");
//////    main.Show();
//////    //mat_datatable.Height = 581;
//////    //matdblist.Visible = false;
//////    //panel2.Visible = false;
//////    //mat_datatable.SelectionMode = DataGridViewSelectionMode.CellSelect;
//////    //mat_datatable.ReadOnly = false;
//////    //button9.Visible = false;
//////    //DeleteBut.Visible = false;
//////    //editOC.Visible = true;
//////    //editCancel.Visible = true;

//////}

//конец редактирования положительный. Обновление данных в БД
//private void editOC_Click(object sender, EventArgs e)
//{
//    mat_datatable.Height = 293;
//    matdblist.Visible = true;

//    panel2.Visible = true;
//    mat_datatable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
//    mat_datatable.ReadOnly = true;


//    try
//    {
//        dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
//        DataTable table = dataTable.ToTable();
//        Matherials item = new Matherials();
//        List<Matherials> list = new List<Matherials>();
//        string query;
//        dbConn.deleteDataAll("Matherials");

//        foreach (DataRow row in table.Rows)
//        {
//            item = new Matherials(row.ItemArray[1].ToString(), row.ItemArray[2].ToString(), row.ItemArray[3].ToString(), row.ItemArray[4].ToString(), row.ItemArray[5].ToString(), row.ItemArray[6].ToString(), row.ItemArray[7].ToString());
//            list.Add(item);
//        }   

//        foreach (Matherials items in list)
//        {
//            query = String.Format("INSERT INTO `Matherials` " +
//            "(`id`, `code`, `name`, `mat_measure`, `mat_price`, `measure`, `mat_for_one`, `full_price`) " +
//            "VALUES (NULL, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
//           items.code, items.name, items.mat_measure, items.mat_price, items.measure, items.mat_for_one, items.full_price);

//            dbConn.getData(query);
//        }
//        MessageBox.Show("Обновление данных в базе завершено");
//    }
//    catch (Exception ex)
//    {
//        // Выводим ошибку
//        MessageBox.Show(ex.Message.ToString());
//    }
//}
////конец редактирования. Отрицательный. Выгрузка прошлых данных из БД с целью отката данных
//private void editCancel_Click(object sender, EventArgs e)
//{
//    mat_datatable.Height = 293;
//    matdblist.Visible = true;
//    panel2.Visible = true;
//    mat_datatable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
//    mat_datatable.ReadOnly = true;


//    try
//    {
//        dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
//        dataTable = new DataView(dbConn.getData("SELECT * FROM `Matherials`"));
//        mat_datatable.DataSource = dataTable;
//        mat_datatable.Columns[0].Visible = false;
//        mat_datatable.Columns[2].Width = 480;
//    }
//    catch (Exception exep)
//    {
//        MessageBox.Show("Невозможно получить данные из БД");
//    }
//}
////кнопка удаления данных из БД
//private void DeleteBut_Click(object sender, EventArgs e)
//{

//    try
//    {
//        dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
//        dbConn.deleteRawDataById("Matherials", Convert.ToInt16(mat_datatable.SelectedCells[0].Value));
//        dataTable = new DataView(dbConn.getData("SELECT * FROM `Matherials`"));
//        mat_datatable.DataSource = dataTable;
//        mat_datatable.Columns[0].Visible = false;
//        mat_datatable.Columns[2].Width = 480;
//    }
//    catch (Exception exep)
//    {
//        MessageBox.Show("Невозможно получить данные из БД");
//    }
//}
//неработающая кнопка(
//private void button10_Click(object sender, EventArgs e)
//{
//    foreach(DataGridViewColumn col in matdblist.Columns)
//    {
//        matherials.Columns.Add();
//    }

//    DG_matherials.DataSource = matherials;
//}

//мертвая кнопка ведущая на вызов читалки пдф-xls сейчас привязана к кнопке редактирования 
//private void button2_Click(object sender, EventArgs e)
//{
//    DataTable dataTable = new DataTable();
//    dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
//    //dataTable = dbConn.getData("SELECT * FROM `Matherials`");
//    //dataGridView1.DataSource = dataTable;
//    Form main = new PDFandEXCEL();
//    main.Show();
//    MessageBox.Show("Complete");
//}
//подсчет общей суммы и выгрузка данных в таблицу вторых данных
//private void button3_Click(object sender, EventArgs e)
//{

//    try
//    {
//        //item = new Matherials(mat_datatable.SelectedCells[1].Value.ToString(), mat_datatable.SelectedCells[2].Value.ToString(), mat_datatable.SelectedCells[3].Value.ToString(), mat_datatable.SelectedCells[4].Value.ToString(), mat_datatable.SelectedCells[5].Value.ToString(), mat_datatable.SelectedCells[6].Value.ToString(), mat_datatable.SelectedCells[7].Value.ToString());
//        matherials.Rows.Add(mat_datatable.SelectedCells[1].Value.ToString(), mat_datatable.SelectedCells[2].Value.ToString(), mat_datatable.SelectedCells[4].Value.ToString());
//        price();
//        /* lname.Text = item.name;
//         double value = Convert.ToDouble(tbcount.Text) * Convert.ToDouble(item.full_price);
//         mat_datatable.SelectedCells[0].Value.ToString(), 
//         , 
//         mat_datatable.SelectedCells[2].Value.ToString(), 
//         mat_datatable.SelectedCells[3].Value.ToString(), 
//         mat_datatable.SelectedCells[4].Value.ToString(), 
//         mat_datatable.SelectedCells[5].Value.ToString(),
//         mat_datatable.SelectedCells[6].Value.ToString();
//         lsum.Text = value.ToString();
//     }*/
//    }
//    catch { }

//    /*try
//    {
//        if (lsum.Text != "")
//        {

//            matdblist.DataSource = matherials;
//            lname.Text = "";
//            lsum.Text = "";
//            tbcount.Text = "1";
//            price();
//            item = new Matherials();
//        }
//    }
//    catch { }*/
//}
//try
//{
//    double value = Convert.ToDouble(tbcount.Text) * Convert.ToDouble(item.full_price);
//    lsum.Text = value.ToString();
//}
//catch { }
//public void updateResult()
//{
//    //создание таблицы с данными из Shown
//    result = new DataTable();
//    result.Columns.Add("Code", typeof(String));
//    result.Columns.Add("Name", typeof(String));
//    result.Columns.Add("Count", typeof(Double));
//    result.Columns.Add("Price", typeof(Double));
//    result.Columns.Add("Fulprice", typeof(Double));

//    foreach (DataRow row in Shown.ToTable().Rows)
//    {
//        result.Rows.Add(row);
//    }

//}

//создание таблицы "Смета"
//Shown.ToTable().Columns.Add("Code", typeof(String));
//Shown.ToTable().Columns.Add("Name", typeof(String));
//Shown.ToTable().Columns.Add("Count", typeof(Double));
//Shown.ToTable().Columns.Add("Price", typeof(Double));
//Shown.ToTable().Columns.Add("Fulprice", typeof(Double));
//
//DataTable budget = new DataTable();
//DataTable test = new DataTable();
//проходная таблица для выгрузки данных из БД. Сейчас выгружает данные из Object и Materials
//DataView dataTable;
//dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
//dataTable = new DataView(dbConn.getData("SELECT * FROM `Matherials`"));
//переконвертация xml таблицы в таблицу нужного формата. 
//try
//{
//    DataSet set = new DataSet();
//    byte[] buffer = Encoding.UTF8.GetBytes(this_obj.workstype);
//    using (MemoryStream stream = new MemoryStream(buffer))
//    {
//        XmlReader reader = XmlReader.Create(stream);
//        set.ReadXml(reader);
//    }
//    создание и заполнение временной таблицы с данными
//    DataTable test = new DataTable();
//    test.Columns.Add("Code", typeof(String));
//    test.Columns.Add("Name", typeof(String));
//    test.Columns.Add("Count", typeof(Double));
//    test.Columns.Add("Price", typeof(Double));
//    test.Columns.Add("Fulprice", typeof(Double));
//    test.Columns.Add("Workprice", typeof(Double));
//    test.Columns.Add("FullWorkprice", typeof(Double));
//    test.Columns.Add("measure_name", typeof(String));
//    test.Columns.Add("tar", typeof(Double));
//    foreach (DataRow row in set.Tables[0].Rows)
//    {
//        try
//        {
//            test.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8]);
//        }
//        catch { }
//    }
//временная таблица загоняется в таблицу для вывода на экран
////Shown = new DataView(test);
////mat_datatable.DataSource = Shown;
//    ////DG_matherials.DataSource = Shown;
//    ////Works.DataSource = Shown;            
//    //генерируются списки с текущими используемыми материалами
//    comboboxadd(test);
//    //форматирование таблиц. 
//    tableinf();
//}
//catch { MessageBox.Show("Для данного объекта не существует таблиц сметы. Добавьте их."); }
// //заполнение данных в списки с видами материалов
//public void comboboxadd(DataTable val)
// {

// }
//добавляем нужные коды для видов материалов (по первым 2 или 3 цифрам)

//заполнение таблицы нужных данных из БД по шифрам полученным из экселя ¯\_(ツ)_/¯ вынесено отдельно для того чтобы работала форма ожидания
//public void ExcellData()
//{   
//    //создание таблицы "Смета" 
//    //budget = budgetTable(excellData);
//    //Shown = new DataView(budgetTable(excellData));
//}
//смотри коммент выше
//public DataTable budgetTable(DataTable bud)
//{
//    //генерация таблицы
//    DataTable res = new DataTable();
//    errors = new List<DataRow>();
//    res.Columns.Add("Code", typeof(String));
//    res.Columns.Add("Name", typeof(String));
//    res.Columns.Add("Count", typeof(Double));
//    res.Columns.Add("Price", typeof(Double));
//    res.Columns.Add("Fullprice", typeof(Double));
//    res.Columns.Add("Workprice", typeof(Double));
//    res.Columns.Add("FullWorkprice", typeof(Double));
//    res.Columns.Add("measure_name", typeof(String));
//    res.Columns.Add("tar", typeof(Double));
//    foreach (DataRow row in bud.Rows)
//    {
//        DataTable dt = new DataTable();
//        dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
//        try
//        {
//            //поиск по шифру
//            string Query = String.Format("SELECT * FROM `Matherials` WHERE `code` LIKE '%{0}%'", row[0].ToString());
//            dt = dbConn.getData(Query);
//            //если шифра нет, добавляем в списаок отсутствующих материалов
//            if (dt.Columns.Count == 0)
//            {
//                errors.Add(row);
//            }
//            else
//            {
//                //добавляем с перезаписью на нужные материалы
//                double count = Convert.ToDouble(dt.Rows[0].ItemArray[7].ToString());
//                double pr = Convert.ToDouble(row[3]) * count;
//                double workpr = Convert.ToDouble(dt.Rows[0].ItemArray[8].ToString());
//                double fullwpr = workpr* Convert.ToDouble(row[3]);
//                res.Rows.Add(row[0], dt.Rows[0].ItemArray[2].ToString(), row[3], count, pr, workpr,fullwpr, dt.Rows[0].ItemArray[9].ToString(), 1.00);
//            }
//        }
//        catch
//        {

//        }
//    }
//    return res;
//}

////выгрузка данных из Excel
//public int DownloadData()
//{
//    using (OpenFileDialog OFD = new OpenFileDialog() { Filter = "Excel Files|*.xls;*.xlsx;*.xlsm", ValidateNames = true, Multiselect = false })
//    {
//        DataSet result = new DataSet();
//        //пытаемся выгрузить данные
//        if (OFD.ShowDialog() == DialogResult.OK)
//        {
//            try
//            {
//                FileStream fStream = File.Open(OFD.FileName, FileMode.Open, FileAccess.Read);
//                string ext = Path.GetExtension(OFD.FileName);
//                IExcelDataReader excelReader;
//                //для каждого формата таблиц Excel
//              if (ext == ".xls")
//                {
//                    excelReader = ExcelReaderFactory.CreateBinaryReader(fStream);
//                }
//              else
//                {
//                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(fStream);
//                }                                 
//                excelReader.IsFirstRowAsColumnNames = true;
//                result = excelReader.AsDataSet();
//                excelReader.Close();
//            }
//            catch (Exception ex)
//            {
//                // Выводим ошибку
//               // MessageBox.Show(ex.Message.ToString());
//               //если возникла ошибка возвращаам 1
//                return 1;                        
//            }
//        }
//        try
//        {
//            //заполняем таблицу по данным из таблицы Excek 
//            DataView test = new DataView(result.Tables[0]);
//            test.RowFilter = "Column0 IS NOT NULL AND Column0 <> '' AND Column1 IS NOT NULL AND Column1 <> ''";
//            DataTable table = new DataTable();
//            table.Columns.Add("code", typeof(String));
//            table.Columns.Add("name", typeof(String));
//            table.Columns.Add("mat_measure", typeof(String));
//            table.Columns.Add("count", typeof(Double));
//            for (int i = 3; i < test.ToTable().Rows.Count; i++)
//                if (Convert.ToDouble(test.ToTable().Rows[i][4]) > 0)
//                {
//                    bool c = true;
//                    for (int j = 0; j < table.Rows.Count; j++)
//                    {
//                        if (table.Rows[j][0] == test.ToTable().Rows[i][1])
//                        {
//                            double old = Convert.ToDouble(table.Rows[j][3]);
//                            double adding = Convert.ToDouble(test.ToTable().Rows[i][4]);
//                            table.Rows[j][3] = Math.Round(old + adding,4);
//                            double news = Convert.ToDouble(table.Rows[j][3]);
//                            c = false;
//                        }
//                    }
//                    if(c)
//                        table.Rows.Add(test.ToTable().Rows[i][1], test.ToTable().Rows[i][2], test.ToTable().Rows[i][3], test.ToTable().Rows[i][4]);
//                }
//            excellData = table;
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message.ToString());
//        }
//        return 0;
//    }
//}