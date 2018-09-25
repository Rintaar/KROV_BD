using Excel;
using iTextSharp.text.pdf.parser;
using Krov;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Core;

namespace WindowsFormsApp1
{
    public partial class PDFandEXCEL : Form
    {
        public PDFandEXCEL()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Отслеживаем можно ли открыть файл (открытие и отображение файлов в окне идёт с фильтром на расширение .pdf)
            using (OpenFileDialog OFD = new OpenFileDialog() { Filter = "PDF | *.pdf", ValidateNames = true, Multiselect = false })
            {
                // Файл открывается
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Используем библиотеку для чтения
                        iTextSharp.text.pdf.PdfReader pdfReader = new iTextSharp.text.pdf.PdfReader(OFD.FileName);
                        // Формируем строку
                        StringBuilder stringBuilder = new StringBuilder();
                        // Ходим по странице
                        for (int i = 1; i < pdfReader.NumberOfPages; i++)
                        {
                            // Составляем строку для вывода
                            stringBuilder.Append(PdfTextExtractor.GetTextFromPage(pdfReader, i));
                        }
                        // Выводим
                        richTextBox1.Text = stringBuilder.ToString();
                        // Закрываем поток чтения
                        pdfReader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Выводим ошибку
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
        DataSet result;

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OFD = new OpenFileDialog() { Filter = "Excel | *.xls", ValidateNames = true, Multiselect = false })
            {
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileStream fStream = File.Open(OFD.FileName, FileMode.Open, FileAccess.Read);
                        IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(fStream);
                        excelReader.IsFirstRowAsColumnNames = true;
                        result = excelReader.AsDataSet();
                        excelReader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Выводим ошибку
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                try
                {
                    DataView test = new DataView(result.Tables[0]);                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView test = new DataView(result.Tables[comboBox1.SelectedIndex]);
            test.RowFilter = "Column0 IS NOT NULL AND Column0 <> '' AND Column1 IS NOT NULL AND Column1 <> ''";
            dataGridView1.DataSource = test;         
          


        }
        //полная выгрузка в БД данных из excel полетит к черту на рога при неправильном флормате таблицы, т.к. жестко дергает столбцы оной
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataBaseConnect dbConn = new dataBaseConnect("roofingDB");              
                DataTable test = result.Tables[comboBox1.SelectedIndex];
                Matherials item = new Matherials();
                List<Matherials> list = new List<Matherials>();
                string query;
                dbConn.deleteDataAll("Matherials");

                 foreach (DataRow row in test.Rows)
                  {
                      item = new Matherials(row.ItemArray[0].ToString(), row.ItemArray[1].ToString(), row.ItemArray[2].ToString(), row.ItemArray[3].ToString(), row.ItemArray[4].ToString(), row.ItemArray[5].ToString(), row.ItemArray[6].ToString(), row.ItemArray[7].ToString());
                      list.Add(item);
                  }

                 foreach (Matherials items in list)
                  {
                      query = String.Format("INSERT INTO `Matherials` " +
                      "(`id`, `code`, `name`, `mat_measure`, `mat_price`, `measure`, `mat_for_one`, `full_price`, `work_price`) " +
                      "VALUES (NULL, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                     items.code, items.name, items.mat_measure, items.mat_price, items.measure, items.mat_for_one, items.full_price, items.work_price);

                      dbConn.getData(query);
                  }
                  MessageBox.Show("Обновление данных в базе завершено");
            }
            catch (Exception ex)
            {
                // Выводим ошибку
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
