using Excel;
using Krov;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using WindowsFormsApp1.Forms;

namespace WindowsFormsApp1.Core.DatabaseTableClass
{

    public class BudgetTable : TableCore
    {
        public DataView materials;
        public DataView works;
        public DataView crews;
        public DataView crews_list;
        public List<string> l_mat;
        public List<string> l_wor;
        public List<DataRow> errors;
        private DataTable bud;
        public BudgetTable()
        {
        }
        public void generateExcellTable()
        {
            bud = DownloadData();
        }
        public override void createdata()
        {
            Thread th = new Thread(generateTables);
            th.Start();
            th.Join();
            Thread th1 = new Thread(Lists);
            th1.Start();
            th1.Join();
        }
        public void reloadLists()
        {
            Thread th1 = new Thread(Lists);
            th1.Start();
            th1.Join();
        }
        public void get_name_obj(string name)
        {
            for (int i = 0; i < crews.Table.Rows.Count; i++)
            {
                crews.Table.Rows[i][2] = name;
            }
        }
        private void generateTables()
        {
            errors = new List<DataRow>();           
            DataTable cre = new DataTable();    
            cre.Columns.Add("id", typeof(Int16));       //id для привязки строк
            cre.Columns.Add("name", typeof(String));    //наименование бригады
            cre.Columns.Add("object", typeof(String));  //наименование объекта
            cre.Columns.Add("dsp", typeof(String));     //date start planned дата начала работ по плану
            cre.Columns.Add("dep", typeof(String));     //date end planned дата окончания работ по плану
            cre.Columns.Add("works", typeof(String));   //выполняемые работы
            cre.Columns.Add("dsr", typeof(String));     //date start real
            cre.Columns.Add("der", typeof(String));     //date end real
            cre.Columns.Add("countp", typeof(Double));  //count planned количество по плану
            cre.Columns.Add("measure", typeof(String)); //единица наименования
            cre.Columns.Add("countr", typeof(Double));  //count real количество выполненное
            cre.Columns.Add("proc", typeof(Double));    //процент готовности работы
            cre.Columns.Add("part", typeof(Int16));     //номер этапа к которому привязано
            cre.Columns.Add("code", typeof(String));

            DataTable mat = new DataTable();
            mat.Columns.Add("Code", typeof(String));
            mat.Columns.Add("Name", typeof(String));
            mat.Columns.Add("Count", typeof(Double));
            mat.Columns.Add("measure", typeof(String));
            mat.Columns.Add("Price", typeof(Double));
            mat.Columns.Add("Fulprice", typeof(Double));
            DataTable wor = new DataTable();
            wor.Columns.Add("Code", typeof(String));
            wor.Columns.Add("Name", typeof(String));
            wor.Columns.Add("tar", typeof(Double));
            wor.Columns.Add("count", typeof(Double));
            wor.Columns.Add("measure", typeof(String));
            wor.Columns.Add("Price", typeof(Double));
            wor.Columns.Add("Fulprice", typeof(Double));
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            foreach (DataRow row in bud.Rows)
            {
                DataTable dt = new DataTable();
                try
                {   //поиск по шифру
                    string Query = String.Format("SELECT * FROM `Matherials` WHERE `code` LIKE '%{0}%'", row[0].ToString());
                    dt = dbConn.getData(Query);

                    //если шифра нет, добавляем в список отсутствующих материалов
                    if (dt.Columns.Count == 0)
                    {
                        errors.Add(row);
                    }
                    else
                    {
                        if (row[0].ToString().IndexOf('-') == 2)
                        {
                            //ВКЛЮЧИТЬ ПОТОМ
                            //
                            //
                            //
                            //
                            //
                            //
                            if (/*dt.Rows[0][9].ToString() != "" && */Math.Round(Convert.ToDouble(row[3]), 2) > 0 && Math.Round(Convert.ToDouble(row[3]) * Convert.ToDouble(dt.Rows[0][6]), 2) > 0)
                            {
                                mat.Rows.Add(row[0], XMLconverterForMat(dt.Rows[0][9].ToString()), Math.Round(Convert.ToDouble(row[3]) * Convert.ToDouble(dt.Rows[0][6]), 2), dt.Rows[0][3], dt.Rows[0][4], Math.Round(Convert.ToDouble(row[3]) * Convert.ToDouble(dt.Rows[0][7]), 2));
                            }
                            wor.Rows.Add(row[0], dt.Rows[0][2], 1, Math.Round(Convert.ToDouble(row[3]),2), dt.Rows[0][5], dt.Rows[0][8], Math.Round(Convert.ToDouble(row[3]) * Convert.ToDouble(dt.Rows[0][8]), 2));
                            cre.Rows.Add(0, "", "", "", "", dt.Rows[0][2], "", "", Math.Round(Convert.ToDouble(row[3]), 2), dt.Rows[0][5], 0, 0, 0, row[0]);

                            //cre.Rows.Add(row[0], dt.Rows[0][2],0, dt.Rows[0][5],0,0,"");
                        }
                    }
                }
                catch
                {

                }
            }
            for(int i = 0; i < cre.Rows.Count; i++)
            {
                cre.Rows[i][0] = i;
            }
            crews = new DataView(cre);
            works = new DataView(wor);
            materials = new DataView(mat);
            works.Table.PrimaryKey = new DataColumn[] { works.Table.Columns["code"] };
            crews.Table.PrimaryKey = new DataColumn[] { crews.Table.Columns["id"] };
            materials.Table.PrimaryKey = new DataColumn[] { materials.Table.Columns["code"] };

        }
        string XMLconverterForMat(string xml)
        {
            string res = "";
            try
            {
                DataSet set1 = new DataSet();
                byte[] buffer1 = Encoding.UTF8.GetBytes(xml);
                using (MemoryStream stream1 = new MemoryStream(buffer1))
                {
                    XmlReader reader = XmlReader.Create(stream1);
                    set1.ReadXml(reader);
                }

                foreach (DataRow row in set1.Tables[0].Rows)
                {
                    try
                    {
                        res += row[0].ToString() + " \n";
                    }
                    catch { }
                }
            }
            catch (Exception ex) { }
            return res;
        }
        public BudgetTable(string mat, string wor, string crew, string c_list)
        {
            try
            {
                try
                {
                    DataSet set1 = new DataSet();
                    byte[] buffer1 = Encoding.UTF8.GetBytes(c_list);
                    using (MemoryStream stream1 = new MemoryStream(buffer1))
                    {
                        XmlReader reader = XmlReader.Create(stream1);
                        set1.ReadXml(reader);
                    }
                    //создание и заполнение временной таблицы с данными
                    DataTable cre = new DataTable();
                    cre.Columns.Add("Name", typeof(String));
                    cre.Columns.Add("Work", typeof(String));
                    cre.Columns.Add("date", typeof(String));

                    foreach (DataRow row in set1.Tables[0].Rows)
                    {
                        try
                        {
                            cre.Rows.Add(row[0], row[1], row[2]);
                        }
                        catch { }
                    }
                   
                    //временная таблица загоняется в таблицу для вывода на экран
                    crews_list = new DataView(cre);
                  //  crews_list.Table.PrimaryKey = new DataColumn[] { crews.Table.Columns["Code"] };
                }
                catch
                {
                    DataTable cre = new DataTable();
                    cre.Columns.Add("Name", typeof(String));
                    cre.Columns.Add("Work", typeof(String));
                    cre.Columns.Add("date", typeof(String));
                    crews_list = new DataView(cre);
                    //crews_list.Table.PrimaryKey = new DataColumn[] { crews.Table.Columns["Code"] };
                    //MessageBox.Show("Произошла ошибка обработки списка работавших на объекте бригад");
                }
                try
                {
                    DataSet set1 = new DataSet();
                    byte[] buffer1 = Encoding.UTF8.GetBytes(crew);
                    using (MemoryStream stream1 = new MemoryStream(buffer1))
                    {
                        XmlReader reader = XmlReader.Create(stream1);
                        set1.ReadXml(reader);
                    }
                    //создание и заполнение временной таблицы с данными
                    DataTable cre = new DataTable();
                    cre.Columns.Add("id", typeof(Int16));       //id для привязки строк
                    cre.Columns.Add("name", typeof(String));    //наименование бригады
                    cre.Columns.Add("object", typeof(String));  //наименование объекта
                    cre.Columns.Add("dsp", typeof(String));     //date start planned дата начала работ по плану
                    cre.Columns.Add("dep", typeof(String));     //date end planned дата окончания работ по плану
                    cre.Columns.Add("works", typeof(String));   //выполняемые работы
                    cre.Columns.Add("dsr", typeof(String));     //date start real
                    cre.Columns.Add("der", typeof(String));     //date end real
                    cre.Columns.Add("countp", typeof(Double));  //count planned количество по плану
                    cre.Columns.Add("measure", typeof(String)); //единица наименования
                    cre.Columns.Add("countr", typeof(Double));  //count real количество выполненное
                    cre.Columns.Add("proc", typeof(Double));    //процент готовности работы
                    cre.Columns.Add("part", typeof(Int16));     //номер этапа к которому привязано
                    cre.Columns.Add("code", typeof(String));

                    foreach (DataRow row in set1.Tables[0].Rows)
                    {
                        try
                        {
                            cre.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6],  row[7], row[8], row[9], row[10], row[11], row[12], row[13]);
                        }
                        catch { }
                    }
                    //временная таблица загоняется в таблицу для вывода на экран
                    crews = new DataView(cre);
                    //назначаем первичный ключ
                    crews.Table.PrimaryKey = new DataColumn[] { crews.Table.Columns["id"] };
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка обработки таблицы бригад объекта");
                }
                try
                {
                    DataSet set = new DataSet();
                    byte[] buffer = Encoding.UTF8.GetBytes(mat);
                    using (MemoryStream stream = new MemoryStream(buffer))
                    {
                        XmlReader reader = XmlReader.Create(stream);
                        set.ReadXml(reader);
                    }
                    //создание и заполнение временной таблицы с данными
                    DataTable t = new DataTable();
                    t.Columns.Add("Code", typeof(String));
                    t.Columns.Add("Name", typeof(String));
                    t.Columns.Add("Count", typeof(Double));
                    t.Columns.Add("measure", typeof(String));
                    t.Columns.Add("Price", typeof(Double));
                    t.Columns.Add("Fulprice", typeof(Double));
                    foreach (DataRow row in set.Tables[0].Rows)
                    {
                        try
                        {
                            t.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5]);
                        }
                        catch { }
                    }
                    //временная таблица загоняется в таблицу для вывода на экран
                    materials = new DataView(t);
                    materials.Table.PrimaryKey = new DataColumn[] { materials.Table.Columns["Сode"] };
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка обработки таблицы материалов объекта");
                }

                try
                {
                    DataSet set1 = new DataSet();
                    byte[] buffer1 = Encoding.UTF8.GetBytes(wor);
                    using (MemoryStream stream1= new MemoryStream(buffer1))
                    {
                        XmlReader reader = XmlReader.Create(stream1);
                        set1.ReadXml(reader);
                    }
                    //создание и заполнение временной таблицы с данными
                    DataTable t1 = new DataTable();
                    t1.Columns.Add("Code", typeof(String));
                    t1.Columns.Add("Name", typeof(String));
                    t1.Columns.Add("tar", typeof(Double));
                    t1.Columns.Add("count", typeof(Double));
                    t1.Columns.Add("measure", typeof(String));
                    t1.Columns.Add("Price", typeof(Double));
                    t1.Columns.Add("Fulprice", typeof(Double));

                    foreach (DataRow row in set1.Tables[0].Rows)
                    {
                        try
                        {
                            t1.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
                        }
                        catch { }
                    }
                    //временная таблица загоняется в таблицу для вывода на экран
                    works = new DataView(t1);
                    materials.Table.PrimaryKey = new DataColumn[] { works.Table.Columns["Сode"] };
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка обработки таблицы работ объекта");
                }
                Thread th1 = new Thread(Lists);
                th1.Start();
                th1.Join();
            }
            catch
            {
               
            }

        }

        public DataView updateCrew(string id)
        {
            try
            {
                try
                {
                    dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
                    DataTable dt = dbConn.getData("SELECT * FROM `Object` WHERE id='" + id + "'");
                    DataSet set1 = new DataSet();
                    byte[] buffer1 = Encoding.UTF8.GetBytes(dt.Rows[0][9].ToString());
                    using (MemoryStream stream1 = new MemoryStream(buffer1))
                    {
                        XmlReader reader = XmlReader.Create(stream1);
                        set1.ReadXml(reader);
                    }
                    //создание и заполнение временной таблицы с данными
                    DataTable cre = new DataTable();
                    cre.Columns.Add("Code", typeof(String));
                    cre.Columns.Add("Name", typeof(String));
                    cre.Columns.Add("count", typeof(Double));
                    cre.Columns.Add("measure", typeof(String));
                    cre.Columns.Add("proc", typeof(String));
                    cre.Columns.Add("num", typeof(Int16));
                    cre.Columns.Add("date", typeof(String));

                    foreach (DataRow row in set1.Tables[0].Rows)
                    {
                        try
                        {
                            cre.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
                        }
                        catch { }
                    }
                    //временная таблица загоняется в таблицу для вывода на экран
                    crews = new DataView(cre);
                    crews.Table.PrimaryKey = new DataColumn[] { crews.Table.Columns["num"] };
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка обработки таблицы бригад объекта");
                }                
            }
            catch
            {

            }
            return crews;

        }


        private DataTable DownloadData()
        {
            DataTable table = new DataTable();
            using (OpenFileDialog OFD = new OpenFileDialog() { Filter = "Excel Files|*.xls;*.xlsx;*.xlsm", ValidateNames = true, Multiselect = false })
            {
                DataSet result = new DataSet();
                //пытаемся выгрузить данные
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileStream fStream = File.Open(OFD.FileName, FileMode.Open, FileAccess.Read);
                        string ext = Path.GetExtension(OFD.FileName);
                        IExcelDataReader excelReader;
                        //для каждого формата таблиц Excel
                        if (ext == ".xls")
                        {
                            excelReader = ExcelReaderFactory.CreateBinaryReader(fStream);
                        }
                        else
                        {
                            excelReader = ExcelReaderFactory.CreateOpenXmlReader(fStream);
                        }
                        excelReader.IsFirstRowAsColumnNames = true;
                        result = excelReader.AsDataSet();
                        
                        excelReader.Close();
                    }
                    catch { }
                }
                try
                {
                    //заполняем таблицу по данным из таблицы Excek 
                    DataView test = new DataView(result.Tables[0]);
                    
                    test.RowFilter = "Column0 IS NOT NULL AND Column0 <> '' AND Column1 IS NOT NULL AND Column1 <> ''";
                    table = new DataTable();
                    table.Columns.Add("code", typeof(String));
                    table.Columns.Add("name", typeof(String));
                    table.Columns.Add("mat_measure", typeof(String));
                    table.Columns.Add("count", typeof(Double));
                    for (int i = 3; i < test.ToTable().Rows.Count; i++)
                        if (Convert.ToDouble(test.ToTable().Rows[i][4].ToString().Replace('.', ',')) > 0)
                        {
                            bool c = true;
                            for (int j = 0; j < table.Rows.Count; j++)
                            {
                                if (table.Rows[j][0] == test.ToTable().Rows[i][1])
                                {
                                    double old = Convert.ToDouble(table.Rows[j][3].ToString().Replace('.', ','));
                                    double adding = Convert.ToDouble(test.ToTable().Rows[i][4].ToString().Replace('.', ','));
                                    table.Rows[j][3] = Math.Round(old + adding, 2);
                                    double news = Convert.ToDouble(table.Rows[j][3].ToString().Replace('.', ','));
                                    c = false;
                                }
                            }
                            if (c)
                                table.Rows.Add(test.ToTable().Rows[i][1], test.ToTable().Rows[i][2], test.ToTable().Rows[i][3], test.ToTable().Rows[i][4].ToString().Replace('.', ','));
                        }                    
                }
                catch
                {
                    try
                    {
                        DataView test = new DataView(result.Tables[0]);

                        test.RowFilter = "Column0 IS NOT NULL AND Column0 <> '' AND Column1 IS NOT NULL AND Column1 <> ''";
                        table = new DataTable();
                        table.Columns.Add("code", typeof(String));
                        table.Columns.Add("name", typeof(String));
                        table.Columns.Add("mat_measure", typeof(String));
                        table.Columns.Add("count", typeof(Double));
                        for (int i = 3; i < test.ToTable().Rows.Count; i++)
                            if (Convert.ToDouble(test.ToTable().Rows[i][3].ToString().Replace('.', ',')) > 0)
                            {
                                bool c = true;
                                for (int j = 0; j < table.Rows.Count; j++)
                                {
                                    if (table.Rows[j][0] == test.ToTable().Rows[i][1])
                                    {
                                        double old = Convert.ToDouble(table.Rows[j][3].ToString().Replace('.', ','));
                                        double adding = Convert.ToDouble(test.ToTable().Rows[i][3].ToString().Replace('.', ','));
                                        table.Rows[j][3] = Math.Round(old + adding, 2);
                                        double news = Convert.ToDouble(table.Rows[j][3].ToString().Replace('.', ','));
                                        c = false;
                                    }
                                }
                                if (c)
                                    table.Rows.Add(test.ToTable().Rows[i][1], test.ToTable().Rows[i][2], test.ToTable().Rows[i][3], test.ToTable().Rows[i][3].ToString().Replace('.', ','));
                            }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                return table;
            }
        }
        private void Lists()
        {
            try
            {
                l_wor = generateLists(works.Table);
            }
            catch { }
            try
            {
                l_mat = generateLists(materials.Table);
            }
            catch { }
        }
        public List<string> generateLists(DataTable table)
        {
            List<string> l = new List<string>();
            List<string> res = new List<string>();
            string item;
            foreach (DataRow rows in table.Rows)
            {
                try
                {
                    item = rows.ItemArray[0].ToString().Substring(0, rows.ItemArray[0].ToString().IndexOf('-'));
                    if (l.Find(x => x == item) == null)
                    {
                        l.Add(item);
                    }
                }
                catch { MessageBox.Show(rows.ItemArray[0].ToString()); }
            }
            l.Sort();
            //выгрузка данных о виде работ из БД 
            dataBaseConnect dbConn = new dataBaseConnect("roofingDB");
            foreach (string a in l)
            {
                int t = 0;
                try
                {                 
                    t = Convert.ToInt16(a);
                    DataTable temp = dbConn.getData(String.Format("SELECT * FROM `JobKind` WHERE `id` = '{0}'", t));
                    string id = "0";
                    if (temp.Rows[0].ItemArray[0].ToString().Length == 1) id += temp.Rows[0].ItemArray[0].ToString();
                    else id = temp.Rows[0].ItemArray[0].ToString();
                    res.Add(id + ". " + temp.Rows[0].ItemArray[1].ToString());                  
                }
                catch
                {
                    MessageBox.Show("неизвестный код услуги: " + t);
                }

            }
            return res;
        }
        public string crew_XML()
        {
            return getXML(crews.Table);
        }
        public string works_XML()
        {
            return getXML(works.Table);
        }
        public string clist_XML()
        {
            return getXML(crews_list.Table);
        }
        public string materials_XML()
        {
            return getXML(materials.Table);
        }
        private string getXML(DataTable t)
        {
            DataSet ds = new DataSet("table");

            ds.Tables.Add(t);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataSet));
                    xmlSerializer.Serialize(streamWriter, ds);
                    string xml = Encoding.UTF8.GetString(memoryStream.ToArray());
                    return xml;
                }
            }
        }
    }
}