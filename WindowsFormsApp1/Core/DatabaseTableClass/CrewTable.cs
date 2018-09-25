 using Krov;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace WindowsFormsApp1.Core.DatabaseTableClass
{
    
   
    public class CrewTable : TableCore
    {
        public DataView crew;

        public CrewTable()
        {

        }       
        public override void createdata()
        {
            try
            {
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                table = dbConn.getData("SELECT * FROM `Crew`");               
                crew = new DataView(createCrew(table));
            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.Message);
            }

        }       
       private DataTable createCrew(DataTable info)
        {
            DataTable t = new DataTable();
            t.Columns.Add("Code", typeof(Int16));
            t.Columns.Add("Type", typeof(String));
            t.Columns.Add("Name", typeof(String));
            t.Columns.Add("Workers", typeof(Int16));
            t.Columns.Add("Car", typeof(String));
            t.Columns.Add("Tools", typeof(String));
            t.Columns.Add("National", typeof(String));
            t.Columns.Add("Phone", typeof(String));
            t.Columns.Add("labor", typeof(String));
            try
            {
                for (int i = 0; i < info.Rows.Count; i++)
                {
                    try
                    {
                        string val = "";
                        List<string> l = setXml(info.Rows[i].ItemArray[1].ToString());
                        for (int j = 0; j < l.Count; j++)
                            val += l[j] + "\n";

                        t.Rows.Add(info.Rows[i][0], val, info.Rows[i][2], info.Rows[i][4], info.Rows[i][5], info.Rows[i][6], info.Rows[i][7], info.Rows[i][8], info.Rows[i][12]);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }              
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return t;

        }
      
        private List<string> setXml(string val)
        {
            List<string> temp = new List<string>();
            byte[] buffer1 = Encoding.UTF8.GetBytes(val);
            using (MemoryStream stream1 = new MemoryStream(buffer1))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                XmlReader reader = XmlReader.Create(stream1);
                temp = (List<string>)serializer.Deserialize(reader);
            }
            return temp;
        }
        public void addCrew(string type, string name, int count, string car, string tools, string national, string phone, string mail, string card, string list, double labor )
        {
            DataTable t = new DataTable();
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");        
            
            try
            {
                string s = labor.ToString().Replace(",", ".");
                dbConn.insertData(String.Format("INSERT INTO `Crew` (`id`, `type`, `name`, `calendar`, `workers`, `car`, `tools`, `national`, `phone`, `mail`, `card`, `obj_count`,`labor`) " +
                    "VALUES (NULL, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}','{11}');", type, name, "", count,car, tools, national, phone,mail,card,list,s));
            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.Message);
            }
        }

        public void delete(string val)
        {
            try
            {
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                table = dbConn.getData(String.Format("DELETE FROM `Crew` WHERE `Crew`.`id` = '{0}'", val.Substring(0,2)));
            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.Message);
            }
        }   
      
        public void updateCrew(int id, string type, string name, int count, string car, string tools, string national, string phone, string mail, string card, string list, double labor)
        {
            DataTable t = new DataTable();
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");          
            try
            {
                string s = labor.ToString().Replace(",", ".");
                dbConn.insertData(String.Format("UPDATE `Crew` SET `type` = '{0}', `name` = '{1}', `workers` = '{2}', `car` = '{3}', `tools` = '{4}', `national` = '{5}', `phone` = '{6}', `mail` = '{7}', `card` = '{8}', `obj_count` = '{9}', `labor` = '{11}' WHERE `Crew`.`id` = {10};",
                    type, name, count, car, tools, national, phone, mail, card, list,id, s));

            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.Message);
            }
        }

    }


}
