using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Krov.Core
{
    public class Configs
    {
        // Свойства класса для задачи, пути, имени, логина и пароля для БД.
        public string login { get; set; }
        public string password { get; set; }
        public string serverID { get; set; }
        public string database { get; set; }

        public string path { get; set; } = "config.config";
        //конструктор для изменения конфига
        public Configs(string _Base, string _Source, string _Login, string _Password)
        {
            serverID = _Source;
            database = _Base;
            login = _Login;
            password = _Password;
        }
        public Configs()
        { }
        //изменения пути конфигурационного файла. на всякий.
        public void SetPath(string new_path)
        {
            path = new_path;
        }

        public void Update()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("appSettings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        switch (node.Attributes[0].Value)
                        {
                            case "serverID":
                                node.Attributes[1].Value = this.serverID;
                                break;
                            case "database":
                                node.Attributes[1].Value = this.database;
                                break;
                            case "login":
                                node.Attributes[1].Value = this.login;
                                break;
                            case "password":
                                node.Attributes[1].Value = this.password;
                                break;

                        }
                       
                    }
                }
            }

            xmlDoc.Save(path);
            ConfigurationManager.RefreshSection("appSettings");

        }

        public void GetConfig()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("appSettings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        switch (node.Attributes[0].Value)
                        {
                            case "serverID":
                                this.serverID = node.Attributes[1].Value;
                                break;
                            case "database":
                                this.database = node.Attributes[1].Value;
                                break;
                            case "login":
                                this.login = node.Attributes[1].Value;
                                break;
                            case "password":
                                this.password = node.Attributes[1].Value;
                                break;

                        }

                    }
                }
            }
            
        }
    }
}
