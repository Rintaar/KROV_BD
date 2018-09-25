using System;
using System.IO;
using System.Net.Mail;

namespace Krov
{
    class mailClass : IDisposable
    {

        // ЮРЕ: Выгрузка данных из БД, отладить метод. 

        string mailServer { get; set; }
        string mailPort { get; set; }
        bool mailSSL { get; set; }
        string mailLogin { get; set; }
        string mailPassword { get; set; }
        string mailRecipient { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string sendMail(string key, string login, string password, string to, string subject, string info, string att)
        {
            try
            {
                // Класс сообщения
                using (MailMessage mail = new MailMessage())
                {
                    // Класс Сервера для подключения, каждый сервер соотв. почтовому хостингу
                    using (SmtpClient smtpServer = new SmtpClient())
                    {

                        string address = "";

                        switch (key)
                        {
                            case "gmail":
                                // Хост почтового сервера
                                smtpServer.Host = "smtp.gmail.com";
                                smtpServer.TargetName = "SMTPSVC / " + smtpServer.Host;
                                // Порт (Каждый порт требует соблюдения своих правил (например 587 от GMAIL - требует TLS (авторизация)) 
                                smtpServer.Port = 587;
                                //Адрес, от кого идет письмо
                                address = String.Format("{0}@{1}.com", login, key);
                                break;
                            case "yandex":
                                smtpServer.Host = "smtp.yandex.ru";
                                smtpServer.TargetName = "SMTPSVC / " + smtpServer.Host;
                                smtpServer.Port = 587;
                                address = String.Format("{0}@{1}.ru", login, key);
                                break;
                            case "mail":
                                smtpServer.Host = "smtp.mail.ru";
                                smtpServer.TargetName = "SMTPSVC / " + smtpServer.Host;
                                smtpServer.Port = 587;
                                address = String.Format("{0}@mail.ru", login);
                                break;
                            case "inbox":
                                smtpServer.Host = "smtp.mail.ru";
                                smtpServer.TargetName = "SMTPSVC / " + smtpServer.Host;
                                smtpServer.Port = 587;
                                address = String.Format("{0}@inbox.ru", login);
                                break;
                            case "list":
                                smtpServer.Host = "smtp.mail.ru";
                                smtpServer.TargetName = "SMTPSVC / " + smtpServer.Host;
                                smtpServer.Port = 587;
                                address = String.Format("{0}@list.ru", login);
                                break;
                            case "bk":
                                smtpServer.Host = "smtp.mail.ru";
                                smtpServer.TargetName = "SMTPSVC / " + smtpServer.Host;
                                smtpServer.Port = 587;
                                address = String.Format("{0}@bk.ru", login);
                                break;
                        }

                        // Учётная запись от кого идёт письмо
                        smtpServer.Credentials = new System.Net.NetworkCredential(address, password);
                        // SSL, какие-то требуют, а какие-то нет
                        smtpServer.EnableSsl = true;
                        // Адрес от кого
                        mail.From = new MailAddress(address);
                        // Кому
                        mail.To.Add(to);
                        // Тема письма
                        mail.Subject = subject;
                        // Содержание
                        mail.Body = info;
                        Attachment a = new Attachment(att);
                        a.Name = att.Substring(att.LastIndexOf('/')+1);
                        mail.Attachments.Add(a);
                        
                        // Отправка сообщений
                        smtpServer.Send(mail);
                        a.Dispose();
                        mail.Attachments.Clear();
                        // Возвращаем результат
                        return "Письмо отправлено";
                    }
                }
            }
            catch (Exception ex)
            {
                // Возврат ошибки, .Message. Показывает только контретную ошибку, а не пласт текста
                return ex.Message.ToString();
            }
            
        }

    }


}