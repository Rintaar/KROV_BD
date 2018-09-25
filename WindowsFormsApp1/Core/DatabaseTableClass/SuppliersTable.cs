using Krov;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Core.DatabaseTableClass
{
    public class SuppliersTable
    {
        private DataView suppliers;
        private DataTable types;
        public SuppliersTable()
        {
            try
            {
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                suppliers = new DataView(dbConn.getData("SELECT * FROM `suppliers`"));
                types = dbConn.getData("SELECT type FROM `suptypes`");
            }
            catch { }
        }
        public DataTable Filteredsuppliers(List<string> filtervalue)
        {

            suppliers.RowFilter = "";
            if (filtervalue.Count > 0)
            {
                string filter = String.Format("type LIKE '{0}' ", filtervalue[0]);
                if(filtervalue.Count > 1)
                    for (int i = 1; i < filtervalue.Count; i++)
                    {
                        filter += String.Format("OR type LIKE '{0}' ", filtervalue[i]);
                    }
                suppliers.RowFilter = filter;
            }
            return suppliers.ToTable();
        }
        public DataTable FilterById(string value)
        {
            suppliers.RowFilter = "";
            string filter = String.Format("id LIKE '{0}' ", value);            
            return suppliers.ToTable();
        }
        public List<string> type()
        {
            List<string> res = new List<string>();
            for (int i = 0; i < types.Rows.Count; i++)
                res.Add(types.Rows[i][0].ToString());
            return res;
        }
    }
}
