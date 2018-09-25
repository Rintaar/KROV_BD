using Krov;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Core.DatabaseTableClass
{
    public class TableCore
    {
        public DataTable table;
        public DataView view;
        public string filter;

        public TableCore()
        {

        }
        public virtual void createdata()
        {
          
        }
        public virtual void editdata(int id)
        {

        }

        public DataTable t_data()
        {
            return table;
        }
        public DataView v_data()
        {
            return view;
        }
        public string filter_stat()
        {
            return filter;
        }
        public virtual void updateDB(object sender, FormClosedEventArgs e)
        {
            //Thread th = new Thread(createdata);
            //th.Start();
            //th.Join();
        }
    }
}
