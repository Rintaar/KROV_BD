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
using WindowsFormsApp1.Core;

namespace WindowsFormsApp1.Forms
{
    public partial class Mailform : Form
    {
        //глобальные переменные: имя входящего PDF файла и список элементов выпадающего окна получателей
        string name = "test.pdf";
        List<string> items;
        Manager u;

        //базовый конструктор
        public Mailform()
        {
            InitializeComponent();
            getstartedinfo();
        }
        //конструктор с получением имени PDF ФАЙЛА
        public Mailform(string _name, Manager _user, string[] arr)
        {
            InitializeComponent();
            getstartedinfo();
            name = _name;
            u = _user;
            tb_text.Text = String.Format("Объект: {0}\r\nАдрес: {1}\r\nПланируемая дата окончания: {2}\r\n{3}\r\n{4}\r\n", arr[0],arr[1],arr[2],arr[3],arr[4]); 
        }
        public Mailform(string _name, Manager _user)
        {
            InitializeComponent();
            getstartedinfo();
            name = _name;
            u = _user;
           
        }
        //выгрузка данных из БД, получение списка получателей
        public void getstartedinfo()
        {
            items = new List<string>();
            try
            {
                //получение данных из БД
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                DataTable info = dbConn.getData("SELECT `name` FROM `mails`");
                //заполнение списка
                foreach (DataRow rows in info.Rows)
                {
                    items.Add(rows.ItemArray[0].ToString());
                }
                //привязка списка к ComboBox на форме
                cb_adr.DataSource = items;               
            } 
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
}
        //Кнопка отправить
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mailClass test = new mailClass();
                string message = test.sendMail(u.m_server, u.m_login, u.m_password, cb_adr.Text, tb_sub.Text, tb_text.Text, name);
                MessageBox.Show(message);
                string temp = cb_adr.Text;
                //если такого пользователя еще не было и письмо было отправлено, то добавить его в БД
                if ((!items.Contains(temp)) && (message == "Письмо отправлено"))
                {
                    dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                    dbConn.insertData(String.Format("INSERT INTO `mails` (`id`, `name`) VALUES (NULL, '{0}')", temp));
                }
                //удаление скомпилированного PDF ника
                //File.Delete(name);
                this.Close();
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
}
        //закрытие формы. Кнопка отмены
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //фильтр текста при начале письма 
        private void cb_adr_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                //берем текущее введенное значение. на его основе фильтруем список получателей. Новый список вносим в combobox
                //string filter_param = cb_adr.Text;
                //List<string> filteredItems = items.FindAll(x => x.Contains(filter_param));
                //cb_adr.DataSource = filteredItems;
                ////если фильтр пуст - вносим значения всего списка
                //if (String.IsNullOrWhiteSpace(filter_param))
                //{
                //    cb_adr.DataSource = items;
                //}
                //cb_adr.DroppedDown = true;
                //cb_adr.IntegralHeight = true;
                //cb_adr.SelectedIndex = -1;
                //cb_adr.Text = filter_param;
                //cb_adr.SelectionStart = filter_param.Length;
                //cb_adr.SelectionLength = 0;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        //кнопка удаления текущего почтового получателя
        private void Del_but_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            //если подтверждено удаление - из Бд удаляется пользователь и перегружается новый список из БД с очисткой текущего текста в CB
            result = MessageBox.Show(String.Format("Вы точно хотите удалить текущий\n почтовый адрес из базы данных??"), "Подтверждение удаления", buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                    dbConn.deleteRawDataBykey("mails", "name", cb_adr.Text);
                    cb_adr.Text = "";
                    getstartedinfo();
                }
                catch (Exception exep)
                {
                    MessageBox.Show("Невозможно получить данные из БД");
                }
            }
        }

        private void cb_adr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_adr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string temp = cb_adr.Text;
                items.Add(temp);
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                dbConn.insertData(String.Format("INSERT INTO `mails` (`id`, `name`) VALUES (NULL, '{0}')", temp));
                cb_adr.DataSource = items;                
                cb_adr.Text = temp;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }

        }                     
    }
}
