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
    public partial class EditManager : Form
    {
        Manager user = new Manager();
        public EditManager()
        {
            InitializeComponent();
        }
        public EditManager(Manager item)
        {
            InitializeComponent();
            user = item;
            get_info();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public void get_info()
        {
            try
            {
                string end = ".ru";
                if (user.m_server == "gmail") end = ".com";
                tb_fi.Text = user.Fio;
                tb_lo.Text = user.login;
                tb_pa.Text = user.password;
                tb_ml.Text = user.m_login + "@" + user.m_server + end;
                tb_mp.Text = user.m_password;
                if (user.access == 0) rb_a.Checked = true;
                else rb_u.Checked = true;
            }
            catch { }
        }
        public void set_info()
        {
            try
            {

                user.Fio = tb_fi.Text;
                if(user.login != "admin")
                    user.login = tb_lo.Text;
                user.password = tb_pa.Text;
                user.m_login = tb_ml.Text.Substring(0, tb_ml.Text.IndexOf('@'));
                int a = tb_ml.Text.IndexOf('@')+1;
                int b = tb_ml.Text.LastIndexOf('.');
                user.m_server = tb_ml.Text.Substring(a,b-a);
                user.m_password = tb_mp.Text;
                if (rb_a.Checked) user.access = 0;
                else user.access = 1;
                if (user.login == "admin")
                    user.access = 0;
            }
            catch { }
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dbConn.deleteRawDataBykey("Manager", "login", user.login);            
            set_info();
            string queryCommand = String.Format("INSERT INTO `Manager` (`login`, `password`, `FIO`, `bill`, `Em_login`, `Em_password`, `Em_Server`, `access`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                user.login,user.password,user.Fio,user.bill,user.m_login,user.m_password,user.m_server,user.access);            
            dbConn.insertData(queryCommand);
            Directory.CreateDirectory("Krov/"+user.login+"/Фото");
            Directory.CreateDirectory("Krov/" + user.login + "/Чеки");
            Directory.CreateDirectory("Krov/" + user.login + "/Отчеты");
            Directory.CreateDirectory("Krov/" + user.login + "/Договора");
            Directory.CreateDirectory("Krov/" + user.login + "/PDF");
            this.Close();
        }
    }
}
