using Krov;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Core.DatabaseTableClass
{
    public class CrewLog :TableCore
    {
        public DataView log;
        DataTable crewlist;
        public CrewLog()
        {
          
        }
        public override void createdata()
        {
            try
            {

                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");             

                log = new DataView(dbConn.getData("SELECT * FROM `Crew_log`"));
                crewlist = dbConn.getData("SELECT `id`,`name` FROM `Crew`");
                log.Table.PrimaryKey = new DataColumn[] { log.Table.Columns["id"] };

            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.Message);
            }
        }
        
        public DataTable getbyCrew(string crew)
        {
            log.RowFilter = "";
            string filter = String.Format("crew LIKE '{0}'", crew);
            log.RowFilter = filter;
            return log.ToTable();
        }
        public DataTable getbyObject(string obj)
        {
            log.RowFilter = "";
            string filter = String.Format("object LIKE '{0}'", obj);
            log.RowFilter = filter;
            return log.ToTable();
        }
        public int labor_obj_by_work(string obj)
        {
            log.RowFilter = "";
            string filter = String.Format("object LIKE '{0}'", obj);
            log.RowFilter = filter;
            return 9;
        }
        public DataTable getbyData(DateTime start, DateTime end)
        {
            log.RowFilter = "";
            string filter = String.Format("start <= '{1}' AND end >= '{0}'", start, end);
            log.RowFilter = filter;
            return log.ToTable();
        }

        public DataTable getbyWork(string info)
        {
            log.RowFilter = "";
            string filter = String.Format("info LIKE '{0}'", info);
            log.RowFilter = filter;
            return log.ToTable();
        }

        public DataTable getbyMonthAndYear(int mounth, int year)
        {
            DateTime start = new DateTime(year,mounth,1);
            DateTime end = new DateTime(year, mounth, DateTime.DaysInMonth(year,mounth)); ;

            log.RowFilter = "";
            string filter = String.Format("start <= '{1}' AND end >= '{0}'", start, end);
            log.RowFilter = filter;
            return log.ToTable();
        }
        /*********************************************************************************
         * 
         * 
         *  поправить проверку на закрытость проекта
         * 
         * 
         * 
         * ****************************************************************************/
        public string obj(string crew)
        {
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            DataTable dt = getbyCrew(crew);
            string s = "";
            foreach(DataRow r in dt.Rows)
            {              
                if(!s.Contains(r[2].ToString()))
                    s += r[2].ToString()+"\n";
            }
            return s;

        }
        private DataTable createMask(int mounth, int year, string crew)
        {
            DateTime start = new DateTime(year, mounth, 1);
            DateTime end = new DateTime(year, mounth, DateTime.DaysInMonth(year, mounth)); ;

            log.RowFilter = "";
            string filter = String.Format("crew LIKE '{2}' AND start <= '{1}' AND end >= '{0}'", start, end, crew);
            log.RowFilter = filter;
            return log.ToTable();
        }
        public DataTable createcalendar(int mounth, int year)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(Int16));
            dt.Columns.Add("name", typeof(String));
            dt.Columns.Add("1", typeof(String));
            dt.Columns.Add("2", typeof(String));
            dt.Columns.Add("3", typeof(String));
            dt.Columns.Add("4", typeof(String));

            string[] arr = new string[4];
            arr[0] = "";
            arr[1] = "";
            arr[2] = "";
            arr[3] = "";

            foreach (DataRow r0 in crewlist.Rows)
            {
                DateTime dat = new DateTime(year, mounth, 1);     
                DayOfWeek dw = dat.DayOfWeek;
                CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
                DayOfWeek fdow = ci.DateTimeFormat.FirstDayOfWeek;                   

                DataTable t = createMask(mounth, year, r0[1].ToString());
                DateTime o1 = dat.AddDays(-(dw - fdow)).Date; 
                DateTime o2 = dat.AddDays(-(dw - fdow)+7).Date; 
                DateTime o3 = dat.AddDays(-(dw - fdow)+14).Date; 
                DateTime o4 = dat.AddDays(-(dw - fdow)+21).Date;
                if (t.Rows.Count > 0)
                {
                    foreach (DataRow r in t.Rows)
                    {
                        DateTime st = Convert.ToDateTime(r[3].ToString());
                        DateTime en = Convert.ToDateTime(r[4].ToString());
                        if (st <= o1 && en >= o1)
                            arr[0] = r[2].ToString();
                        if (st <= o2 && en >= o2)
                            arr[1] = r[2].ToString();
                        if (st <= o3 && en >= o3)
                            arr[2] = r[2].ToString();
                        if (st <= o4 && en >= o4)
                            arr[3] = r[2].ToString();
                    }
                }
                dt.Rows.Add(r0[0].ToString(), r0[1].ToString(), arr[0], arr[1], arr[2], arr[3]);
                arr[0] = "";
                arr[1] = "";
                arr[2] = "";
                arr[3] = "";
            }

            return dt;
        }
       
    }
}
