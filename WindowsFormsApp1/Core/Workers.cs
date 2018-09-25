using Krov;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Core
{
    public class Workers
    {
        public int id { get; set; }
        public int crew { get; set; }
        public string name { get; set; }
        public double rate { get; set; }
        public double addit { get; set; }
        public string info { get; set; }

        public Workers()
        {

        }
        public Workers(int _crew, string _name, double _rate, double _addit, string _info)
        {            
            crew = _crew;
            name = _name;
            rate = _rate;
            addit = _addit;
            info = _info;
        }
        public Workers(int _id, int _crew, string _name, double _rate, double _addit, string _info)
        {
            id = _id;
            crew = _crew;
            name = _name;
            rate = _rate;
            addit = _addit;
            info = _info;
        }
        public void getinfo(int id)
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            DataTable i = dbConn.getData(String.Format("SELECT * FROM `workers` WHERE `workers`.`id` = {0};",id));
            crew = Convert.ToInt16(i.Rows[0].ItemArray[1].ToString());
            name = i.Rows[0].ItemArray[2].ToString();
            rate = Convert.ToDouble(i.Rows[0].ItemArray[3].ToString());
            addit = Convert.ToDouble(i.Rows[0].ItemArray[4].ToString());
            info = i.Rows[0].ItemArray[5].ToString();
        }
        public void add_worker()
        {
            string queryCommand = String.Format("INSERT INTO `workers` (`id`, `crew`, `name`, `rate`, `addit`, `info`) VALUES(NULL, '{0}', '{1}', '{2}', '{3}', '{4}');",
                crew,name,rate,addit,info);
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dbConn.getData(queryCommand);
        }
        public void edit_worker()
        {
            string queryCommand = String.Format("UPDATE `workers` SET `crew` = '{1}', `name` = '{2}', `rate` = '{3}', `addit` = '{4}', `info` = '{5}' WHERE `workers`.`id` = {0};",
                id, crew, name, rate, addit, info);
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dbConn.getData(queryCommand);
        }
    }
}
