using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Core
{
    public class PDFs
    {
        
        public PDFs()
        {

        }
        public PDFs(Manager user)
        {
            Directory.CreateDirectory("Krov/" + user.login + "/Фото");
            Directory.CreateDirectory("Krov/" + user.login + "/Чеки");
            Directory.CreateDirectory("Krov/" + user.login + "/Отчеты");
            Directory.CreateDirectory("Krov/" + user.login + "/Договора");
            Directory.CreateDirectory("Krov/" + user.login + "/PDF");
        }
        public void workers(DataTable workers, string name, string price, string obj)
        {
            Document document = new Document();
            FileStream fs = new FileStream(name, FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            //настройки шрифта для русского текста
            BaseFont baseFont = BaseFont.CreateFont(@"arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font5 = new iTextSharp.text.Font(baseFont, 5, iTextSharp.text.Font.NORMAL);
            PdfPTable table = new PdfPTable(4);
            PdfPRow row = null;
            float[] widths = new float[] { 4f, 4f, 4f, 4f };
            table.SetWidths(widths);
            table.WidthPercentage = 100;
            //создание таблицы в PDF
            table.AddCell(new Phrase("Наименование", font5));
            table.AddCell(new Phrase("Количество", font5));
            table.AddCell(new Phrase("Ед.измер.", font5));
            table.AddCell(new Phrase("Стоимость работ", font5));
            //ее наполнение
            foreach (DataRow r in workers.Rows)
            {
                if (workers.Rows.Count > 0)
                {
                    table.AddCell(new Phrase(r[1].ToString(), font5));
                    table.AddCell(new Phrase(r[3].ToString(), font5));
                    table.AddCell(new Phrase(r[4].ToString(), font5));
                    table.AddCell(new Phrase(r[6].ToString(), font5));
                }
            }
            Paragraph par = new Paragraph("\n\n" + obj+ "\n\n", font5);
            document.Add(par);
            //засовывание таблицы в PDF
            document.Add(table);
            //засовывание суммарной цены в PDF
            par = new Paragraph("\n\n\n" + price, font5);
            document.Add(par);
            //закрытие всего
            document.CloseDocument();
            document.Close();
            fs.Close();
            writer.Close();
        }
        public void materials1(DataTable materials, string name, string price, string obj)
        {
            Document document = new Document();
            FileStream fs = new FileStream(name, FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            //настройки шрифта для русского текста
            BaseFont baseFont = BaseFont.CreateFont(@"arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font5 = new iTextSharp.text.Font(baseFont, 5, iTextSharp.text.Font.NORMAL);
            PdfPTable table = new PdfPTable(4);
            PdfPRow row = null;
            float[] widths = new float[] { 4f, 4f, 4f, 4f };
            table.SetWidths(widths);
            table.WidthPercentage = 100;
            //создание таблицы в PDF
            table.AddCell(new Phrase("Наименование", font5));
            table.AddCell(new Phrase("Количество", font5));
            table.AddCell(new Phrase("Ед.измер.", font5));
            table.AddCell(new Phrase("Стоимость", font5));
            //ее наполнение
            foreach (DataRow r in materials.Rows)
            {
                if (materials.Rows.Count > 0)
                {
                    table.AddCell(new Phrase(r[1].ToString(), font5));
                    table.AddCell(new Phrase(r[2].ToString(), font5));
                    table.AddCell(new Phrase(r[3].ToString(), font5));
                    table.AddCell(new Phrase(r[4].ToString(), font5));
                }
            }
            Paragraph par = new Paragraph("\n\n" + obj + "\n\n", font5);
            document.Add(par);
            //засовывание таблицы в PDF
            document.Add(table);
            //засовывание суммарной цены в PDF
            par = new Paragraph("\n\n\n" + price, font5);
            document.Add(par);
            //закрытие всего
            document.CloseDocument();
            document.Close();
            fs.Close();
            writer.Close();
        }
        public void materials2(DataTable materials, string name, string price, string obj)
        {
            Document document = new Document();
            FileStream fs = new FileStream(name, FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            //настройки шрифта для русского текста
            BaseFont baseFont = BaseFont.CreateFont(@"arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font5 = new iTextSharp.text.Font(baseFont, 5, iTextSharp.text.Font.NORMAL);
            PdfPTable table = new PdfPTable(3);
            PdfPRow row = null;
            float[] widths = new float[] { 4f, 4f , 4f };
            table.SetWidths(widths);
            table.WidthPercentage = 100;
            //создание таблицы в PDF
            table.AddCell(new Phrase("Наименование", font5));
            table.AddCell(new Phrase("Количество", font5));
            table.AddCell(new Phrase("Ед.измер.", font5));
            //ее наполнение
            foreach (DataRow r in materials.Rows)
            {
                if (materials.Rows.Count > 0)
                {
                    table.AddCell(new Phrase(r[1].ToString(), font5));
                    table.AddCell(new Phrase(r[2].ToString(), font5));
                    table.AddCell(new Phrase(r[3].ToString(), font5));
                }
            }
            Paragraph par = new Paragraph("\n\n" + obj + "\n\n", font5);
            document.Add(par);
            //засовывание таблицы в PDF
            document.Add(table);
           
            //закрытие всего
            document.CloseDocument();
            document.Close();
            fs.Close();
            writer.Close();
        }       

    }
}
