using Krov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Core
{
    public class Manager
    {
    ////ПЕРЕМЕННЫЕ////
        //FIO
        public string Fio { get; set; }
        //логин он же id
        public string login { get; set; }
        //пароль
        public string password { get; set; }
        //рассчетный счет, его остаток
        public double bill { get; set; }
        //логин почты
        public string m_login { get; set; }
        //пароль почты
        public string m_password { get; set; }
        //какой сервер
        public string m_server { get; set; }
        //какой сервер
        public int access { get; set; }

        public Manager(string _login, string _pass, string _fio, double _bill,string _m_log, string _m_pass, string _m_serv, int _acc)
        {
            login = _login;
            password = _pass;
            Fio = _fio;
            bill = _bill;
            m_login = _m_log;
            m_password = _m_pass;
            m_server = _m_serv;
            access = _acc;                
        }
        public Manager()
        {
          
        }

        ////МЕТОДЫ////
        //редактирование счета
        public void redact_bill(double count, bool stat)
        {
            //stat: true - добавляем деньги, false - убавляем
            if (stat) bill += count;
            else
            {
                bill -= count;
                if(bill < 0)
                {
                    bill = 0;
                    MessageBox.Show("Ваш счет пуст");
                }
            }
        }
        //смена ФИО
        public void redact_FIO(string new_FIO)
        { 
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dbConn.changeManager(login, "FIO", new_FIO);
            Fio = new_FIO;
        }
        //смена емейла
        public void redact_mail(string new_mail)
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dbConn.changeManager(login, "Em_Server", new_mail);
            m_server = new_mail;
        }
        //смена пароля
        public void redact_password(string new_password)
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dbConn.changeManager(login, "password", new_password);
            password = new_password;
        }
        //смена пароля почты
        public void redact_m_password(string new_password)
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dbConn.changeManager(login, "Em_password", new_password);
            m_password = new_password;
        }
        //смена логина почты
        public void redact_m_login(string new_login)
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dbConn.changeManager(login, "Em_login", new_login);
            m_login = new_login;
        }
        //изменение проектов


    }
}
