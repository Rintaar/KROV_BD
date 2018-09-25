using Krov;
using Krov.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Core;
using WindowsFormsApp1.Forms;

namespace WindowsFormsApp1
{
    public partial class Autorisation : Form
    {
        Configs conf = new Configs();
        public Autorisation()
        {
            InitializeComponent();
            
            conf.GetConfig();
            login_p.Text = conf.login;
            password_p.Text = conf.password;
            host.Text = conf.serverID;
            dbname.Text = conf.database;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conf.login = login_p.Text;
            conf.password = password_p.Text;
            conf.serverID = host.Text;
            conf.database = dbname.Text;
            conf.Update();
                      
            try
            {
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                DataTable dt_user = dbConn.getData(String.Format("SELECT * FROM `Manager` WHERE `login` = '{0}' AND `password` = '{1}'", conf.login, conf.password));
                if (dt_user.Rows.Count > 0)
                {
                    Manager user = new Manager(dt_user.Rows[0].ItemArray[0].ToString(), dt_user.Rows[0].ItemArray[1].ToString(), dt_user.Rows[0].ItemArray[2].ToString(), Convert.ToDouble(dt_user.Rows[0].ItemArray[3]), dt_user.Rows[0].ItemArray[4].ToString(), dt_user.Rows[0].ItemArray[5].ToString(), dt_user.Rows[0].ItemArray[6].ToString(), Convert.ToInt16(dt_user.Rows[0].ItemArray[7]));

                    Form main = new Form();
                    if (user.access == 1) main = new ManagerForm(user);
                    if(user.access == 0) main = new Administration(user);
                    main.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Неправильный логин или пароль");
            }
            catch
            {
                MessageBox.Show("Некорректно введены входные данные.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conf.GetConfig();
            host.Text = conf.database;
            dbname.Text = conf.serverID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conf.database = host.Text;
            conf.serverID = dbname.Text;
            conf.Update();
        }
    }
}
