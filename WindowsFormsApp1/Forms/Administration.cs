using Krov;
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

namespace WindowsFormsApp1.Forms
{
    public partial class Administration : Form
    {
        DataTable dt_user;
        Manager user = new Manager();
        public Administration(Manager _user)
        {
            InitializeComponent();
            user = _user;
            update();
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns[0].HeaderText = "Логин";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Ф.И.О.";
            dataGridView1.Columns[3].HeaderText = "Счет";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Уровень доступа";

        }

        private void Add_Click(object sender, EventArgs e)
        {
            Form main = new EditManager();
            main.FormClosed += updateDB;
            main.Show();
        }
        private void updateDB(object sender, FormClosedEventArgs e)
        {
            update();
        }
        private void update()
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dt_user = dbConn.getData("SELECT * FROM `Manager`");
            dataGridView1.DataSource = dt_user;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {

                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                DataTable dt_user = dbConn.getData(String.Format("SELECT * FROM `Manager` WHERE `login` = '{0}' ", dataGridView1.SelectedCells[0].Value.ToString()));
                if (dt_user.Rows.Count > 0)
                {
                    Manager user = new Manager(dt_user.Rows[0].ItemArray[0].ToString(), dt_user.Rows[0].ItemArray[1].ToString(), dt_user.Rows[0].ItemArray[2].ToString(), Convert.ToDouble(dt_user.Rows[0].ItemArray[3]), dt_user.Rows[0].ItemArray[4].ToString(), dt_user.Rows[0].ItemArray[5].ToString(), dt_user.Rows[0].ItemArray[6].ToString(), Convert.ToInt16(dt_user.Rows[0].ItemArray[7]));
                    Form main = new EditManager(user);
                    main.FormClosed += updateDB;
                    main.Show();
                }               
            }
            catch { }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(String.Format("Вы точно хотите удалить выделенного пользователя?"), "Удаление пользователя", buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (dataGridView1.SelectedCells[0].Value.ToString() == "admin")
                        MessageBox.Show("Невозможно удалить базовый аккаунт администратора");
                    else if(dataGridView1.SelectedCells[0].Value.ToString() == user.login)
                        MessageBox.Show("Невозможно удалить аккаунт с которого вы зашли");
                    else
                    {
                        dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                        dbConn.deleteRawDataBykey("Manager", "login", dataGridView1.SelectedCells[0].Value.ToString());
                        update();
                    }
                }
                catch (Exception exep)
                {
                    MessageBox.Show("Невозможно получить данные из БД");
                }
            }
        }

        private void Administration_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormCollection formlist = Application.OpenForms;
            formlist[0].Show();
        }
    }
}

