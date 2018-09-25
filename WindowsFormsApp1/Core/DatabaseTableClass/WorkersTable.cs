using Krov;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Forms;

namespace WindowsFormsApp1.Core.DatabaseTableClass
{
    public class WorkersTable : TableCore
    {
        public WorkersTable()
        {
            
        }
        public override void createdata()
        {
            try
            {
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                DataTable info = dbConn.getData("SELECT * FROM `workers`");
                view = new DataView(info);
            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.Message);
            }
        }      
        public void Filter(string _filter)
        {
            try
            {
                if (filter != _filter)
                {
                    if (_filter != "") filter = String.Format("crew = {0}", Convert.ToInt16(_filter));
                    else filter = _filter;
                }
                view.RowFilter = filter;
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        public List<string> list_workers()
        {
            Filter("0");
            List<string> temp = new List<string>();
            foreach (DataRow r in view.ToTable().Rows)
            {
                temp.Add(String.Format("{0}. {1} \tСтавка:  {2} \tДоп. инфо:  {3} ",r.ItemArray[0].ToString(),r.ItemArray[2].ToString(), r.ItemArray[3].ToString(), r.ItemArray[5].ToString()));
            }
            return temp;
        }
        public Workers getabout(int id)
        {            
            return new Workers(Convert.ToInt16(view.ToTable().Rows[id][0].ToString()),Convert.ToInt16(view.ToTable().Rows[id][1].ToString()), view.ToTable().Rows[id][2].ToString(), Convert.ToDouble(view.ToTable().Rows[id][3].ToString()), Convert.ToDouble(view.ToTable().Rows[id][4].ToString()), view.ToTable().Rows[id][5].ToString());
        }   
        public void clear_crew(string val)
        {
            string id = val.Substring(0, 2);
            Filter(id);
            DataTable temp = view.ToTable();
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            foreach (DataRow Rows in view.ToTable().Rows)
            {
                dbConn.updateDataByNumericKey("workers", "crew", id, "crew", "0");
            }
        }
        public void set_new_crew(string val, string crew_id)
        {
            string id = val.Substring(0, val.IndexOf('.'));
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dbConn.updateDataById("workers", Convert.ToInt32(id),"crew",crew_id);
        }
        public void delete(int index)
        {
            Workers i = getabout(index);
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            dbConn.deleteRawDataById("workers", i.id);
        }
    }
}
